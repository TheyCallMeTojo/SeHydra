using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using SeHydra.Models;
using SeHydra.Search;
using SeHydra.Security;
using SeHydra.Settings;

namespace SeHydra.Interface
{
    public partial class FrmMain : Form
    {
        private readonly string _project;
        private ListViewColumnSorter _lvwColumnSorter;
        private Thread[] _threads;
        static ProjectModel _currentProject = new ProjectModel();
        public FrmMain(string project)
        {
            _project = project;
            InitializeComponent();
        }


        private void BtnNewClick(object sender, EventArgs e)
        {
            new FrmNewProject(false).ShowDialog(this);
            LoadProjectsList();
            if (!string.IsNullOrEmpty(Globals.ActiveProject))
                LoadProject();
        }

        private void FrmMainLoad(object sender, EventArgs e)
        {
            _lvwColumnSorter = new ListViewColumnSorter();
            LstResults.ListViewItemSorter = _lvwColumnSorter;
            LstResults.ColumnClick += (o, t) =>
                                          {
                                              if (t.Column == _lvwColumnSorter.SortColumn)
                                              {
                                                  // Reverse the current sort direction for this column.
                                                  _lvwColumnSorter.Order = _lvwColumnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                                              }
                                              else
                                              {
                                                  // Set the column number that is to be sorted; default to ascending.
                                                  _lvwColumnSorter.SortColumn = t.Column;
                                                  _lvwColumnSorter.Order = SortOrder.Ascending;
                                              }

                                              // Perform the sort with these new sort options.
                                              LstResults.Sort();
                                          };
            Closing += (o, t) =>
                           {
                               notifyIcon1.Visible = false;
                               Environment.Exit(0);
                           };

            SizeChanged += (o, t) =>
                               {
                                   if (WindowState == FormWindowState.Minimized)
                                       Hide();
                                   else Show();

                               };
            LoadProjectsList();
            if (string.IsNullOrEmpty(_project)) return;
            Text = @"SeHydra - " + _project;
            Globals.ActiveProject = _project;
            BtnDeleteProject.Visible = true;
            LoadProject();
            BtnStartClick(null, null);
        }

        private void OpenClick(object sender, EventArgs eventArgs)
        {
            var project = ((ToolStripMenuItem)sender).Text;
            Text = @"SeHydra - " + project;
            Globals.ActiveProject = project;
            BtnDeleteProject.Visible = true;
            LoadProject();
        }

        private void BtnDeleteProjectClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Globals.ActiveProject)) return;
            var res = MessageBox.Show(@"Are you sure you want to delete this project?", @"Delete?",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;
            File.Delete(DirStructure.ProjectsDir + Globals.ActiveProject + "\\" + Globals.ActiveProject + ".xml");
            File.Delete(DirStructure.ProjectsDir + Globals.ActiveProject + "\\" + Globals.ActiveProject + "_log.txt");
            Directory.Delete(DirStructure.ProjectsDir + Globals.ActiveProject);
            Globals.ActiveProject = "";
            BtnDeleteProject.Visible = false;
            Text = @"SeHydra";
            LoadProjectsList();
        }

        void LoadProjectsList()
        {
            Text = @"SeHydra - " + Globals.ActiveProject;
            PrgMain.Value = 0;
            PrgMain.Maximum = 0;
            BtnOpen.DropDownItems.Clear();
            var project = Directory.GetDirectories(DirStructure.ProjectsDir);
            //LstProjects.Items.AddRange(project);
            foreach (var item in from s in project
                                 let start = s.LastIndexOf("\\") + 1
                                 select new ToolStripMenuItem
                                 {
                                     Width = 100,
                                     ImageAlign = ContentAlignment.MiddleLeft,
                                     Image = Properties.Resources.project,
                                     Text = s.Substring(start, s.Length - start)
                                 })
            {
                item.Click += OpenClick;
                BtnOpen.DropDownItems.Add(item);
            }
        }

        readonly Stopwatch _watch = new Stopwatch();
        private void BtnStartClick(object sender, EventArgs e)
        {
            _watch.Start();
            timer1.Enabled = true;
            if (string.IsNullOrEmpty(Globals.ActiveProject))
                return;
            //Check for unpause
            if (Globals.Pause)
            {
                Globals.Pause = false;
                BtnStart.Text = @"Start";
                LblStatus.Text = @"Working. . . ";// +uri.Split('|')[1];
                return;
            }

            _threads = new Thread[_currentProject.ThreadCount];
            //Log.AddToLog("Starting project: " + _currentProject.ProjectName, _currentProject.ProjectName);
            LblStatus.Text = @"Work Starting . . ";
            LstResults.Items.Clear();
            for (var l = 1; l <= _currentProject.LoopCount; l++)
            {
                foreach (var domain in _currentProject.Sites)
                {
                    foreach (var keyword in domain.Keywords)
                    {
                        foreach (var engine in _currentProject.Engines)
                        {
                            PrgMain.Maximum++;
                            ThreadPool.Enqueue(domain.Site + "|" + engine.Split('|')[1] + keyword + "+" + domain.Site + "|" + keyword + "|" + engine.Split('|')[0]);
                        }
                    }
                }
            }


            for (var i = 0; i < _currentProject.ThreadCount; i++)
            {
                _threads[i] = new Thread(ThreadFunc)
                {
                    IsBackground = true,
                };
                _threads[i].Start();
            }
            Log.Add2Log("Project started: " + _currentProject.ProjectName, _currentProject.ProjectName);

            LblStatus.Text = @"Working. . . ";// +uri.Split('|')[1];
        }

        private void ThreadFunc()
        {
            while (true)
            {
                if (Globals.Pause)
                {
                    CheckForIllegalCrossThreadCalls = false;
                    Application.DoEvents();
                    Thread.Sleep(1);
                    continue;
                }
                Thread.Sleep(1);
                var uri = ThreadPool.Dequeue();
                ProcessSearch(uri);
            }
            // ReSharper disable FunctionNeverReturns
        }

        private int _count;
        private void ProcessSearch(string uri)
        {
            var searcher = new Actions();
            CheckForIllegalCrossThreadCalls = false;
            if (string.IsNullOrEmpty(uri))
                return;
            var rnd = new Random();
            var sleep = rnd.Next(_currentProject.MaxWait * 30000);
            Thread.Sleep(sleep);

            var split = uri.Split('|');

            //MessageBox.Show(split[0]);

            var domain = split[0];
            string proxy;
            string error;
            //check if we're using proxies
            var useProxies = false;
            if (_currentProject.UsePremiumProxies)
                useProxies = true;
            if (!string.IsNullOrEmpty(_currentProject.ProxyList))
                useProxies = true;
        TryAgain:
            var result = searcher.GoSearch(split[0], split[1], useProxies, out proxy, out error, _currentProject.ClickLinks);
            if (!result && _currentProject.UsePremiumProxies)
            {
                ReportBadProxy(proxy);
                goto TryAgain;
            }
            //Log.AddToLog(split[1], _currentProject.ProjectName);
            var item = new ListViewItem(domain)
            {
                UseItemStyleForSubItems = false
            };
            proxy = "Proxy Used";
            if (_currentProject.UsePremiumProxies)
            {
                var prox2 = proxy.Substring(0, 5);
                proxy = proxy.Replace(prox2, "*****");
            }

            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, split[2], Color.Blue, Color.White, item.Font));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "Proxy Used", Color.Green, Color.White, item.Font));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, split[3], Color.DarkOrange, Color.White, item.Font));
            item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "OK", Color.Green, Color.White, item.Font));
            item.SubItems.Add(error);
            LstResults.Items.Add(item);
            Log.Add2Log(string.Format("Executed: {0} with keyword {1} on engine: {2}", domain, split[2], split[3]), _currentProject.ProjectName);

            _count++;
            LblStatus.Text = @"Working on " + _count + @" of " + PrgMain.Maximum;
            PrgMain.Value++;
            if (PrgMain.Value < PrgMain.Maximum) return;
            _watch.Stop();
            timer1.Enabled = false;
            LblStatus.Text = @"Done";
            PrgMain.Value = 0;
            PrgMain.Maximum = 0;
        }

        private static void ReportBadProxy(string proxy)
        {
            try
            {
                var server = new Server();
                server.ExecuteNonQuery("update proxies set working = 0 where proxy = '" + proxy + "'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void LoadProject()
        {
            if (_threads != null)
            {
                foreach (var thread in _threads)
                {
                    thread.Abort();
                }
            }
            timer1.Enabled = false;
            LblTime.Text = "";
            LblStatus.Text = @"Ready";
            Globals.Pause = false;
            ThreadPool.Queue.Clear();
            BtnStart.Text = @"Start";
            PrgMain.Maximum = 0;
            PrgMain.Value = 0;
            LstResults.Items.Clear();
            Actions.Agents.Clear();
            //Load Project
            _currentProject = ObjectXmlSerializer<ProjectModel>.Load(DirStructure.ProjectsDir + Globals.ActiveProject + "\\" + Globals.ActiveProject + ".xml");
            Log.Add2Log("Project loaded: " + _currentProject.ProjectName, _currentProject.ProjectName);
            if (_currentProject.Sites.Count > 5)
            {
                MessageBox.Show(@"Project has been deleted due to usage violation" +
                    Environment.NewLine + @"Only 5 domains allowed per project!" +
                    Environment.NewLine + @"Please don't alter the project file next time.",
                    @"Usage Violation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                File.Delete(DirStructure.ProjectsDir + Globals.ActiveProject + "\\" + Globals.ActiveProject + ".xml");
                Directory.Delete(DirStructure.ProjectsDir + Globals.ActiveProject);
                Globals.ActiveProject = "";
                BtnDeleteProject.Visible = false;
                Text = @"SeHydra";
                LoadProjectsList();
                return;
            }
            //Load Projects
            if (_currentProject.UsePremiumProxies)
                Proxies.Actions.LoadProxyList();
            if (!_currentProject.UsePremiumProxies && !string.IsNullOrEmpty(_currentProject.ProxyList))
                Proxies.Actions.LoadProxyListFromFile(_currentProject.ProxyList);
        }

        private void BtnSettingsClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Globals.ActiveProject))
            {
                MessageBox.Show(@"Please open a project first", @"Warning - Now Active Project", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            new FrmNewProject(true, _currentProject.ProjectName).ShowDialog(this);
        }


        private void BtnStopClick(object sender, EventArgs e)
        {
            if (_threads == null)
                return;
            Globals.Pause = true;
            LblStatus.Text = @"Paused";
            BtnStart.Text = @"Resume";
        }

        private void BtnAboutClick(object sender, EventArgs e)
        {
            new FrmAbout().ShowDialog(this);
        }

        private void NotifyIcon1MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Focus();
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Environment.Exit(0);
        }

        private void Timer1Tick(object sender, EventArgs e)
        {
            LblTime.Text = @"          Elapsed Time: " + _watch.Elapsed;
        }

        private void LblViewLogLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentProject.ProjectName))
                Process.Start(DirStructure.ProjectsDir + _currentProject.ProjectName + "\\" + _currentProject.ProjectName + "_log.txt");
        }

        private void BtnReleaseClick(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"Are you sure you want to release your license?", @"License Action",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var server = new Server();
                server.ExecuteNonQuery("UPDATE Customers SET KeyCode ='', Active=0 WHERE KeyCode='" + FingerPrint.Value() + "'");
                Environment.Exit(0);
            }
            return;
        }
    }
}
