using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SeHydra.Interface.Controls;
using SeHydra.Models;
using SeHydra.Settings;

namespace SeHydra.Interface
{
    public partial class FrmNewProject : Form
    {
        private readonly OpenFileDialog _openProxyListDlg = new OpenFileDialog();

        private readonly bool _load;
        private readonly string _name;
        public FrmNewProject(bool load, string name = "")
        {
            _load = load;
            _name = name;
            InitializeComponent();
        }

        private void ShowEstimates()
        {
            var loops = TrkLoopCount.Value;
            var engine = LstEngines.CheckedItems.Count;
            var domains = PnlDomains.Controls.Cast<DomainControl>().Count(contol => !string.IsNullOrEmpty(contol.Domain));
            var keywords = PnlDomains.Controls.Cast<DomainControl>().Sum(control => control.Keywords.Count);
            var totalSearches = loops * engine * domains * keywords;
            var seconds = totalSearches * TrkMaxWait.Value / 60;
            var t = TimeSpan.FromSeconds(seconds * 2);

            var answer = string.Format("{0:D2}d:{1:D2}h:{2:D2}m:{3:D2}s",
                t.Days,
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds);
            const string txt = @"Running {0} loops with {1} domains and {2} keywords on {3} search engines will yield {4} searches and will take approximately {5} to complete! If using proxies this estimate could be lower then actual time.";
            LblEstimates.Text = string.Format(txt, loops, domains, keywords, engine, totalSearches, answer);
        }

        private void FrmNewProjectLoad(object sender, EventArgs e)
        {
            foreach (var engine in Engines.List)
            {
                LstEngines.Items.Add(new CheckListBoxItem
                {
                    Text = engine.Split('|')[0],
                    Tag = engine.Split('|')[1]
                });
            }

            if (_load)
            {
                LoadSettings();
            }
        }

        #region Button Clicks
        private void BtnAddDomainClick(object sender, EventArgs e)
        {
            if (PnlDomains.Controls.Count >= 5)
            {
                MessageBox.Show(@"Max domains in use", @"Max Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PnlDomains.Controls.Add(new DomainControl());
        }

        private void BtnSelectAllLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (var i = 0; i <= LstEngines.Items.Count - 1; i++)
            {
                LstEngines.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void BtnSelectNoneLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (var i = 0; i <= LstEngines.Items.Count - 1; i++)
            {
                LstEngines.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void BtnRefreshClick(object sender, EventArgs e)
        {
            ShowEstimates();
        }
        #endregion

        private void LoadSettings()
        {
            TxtProjectName.Enabled = false;
            var result = ObjectXmlSerializer<ProjectModel>.Load(DirStructure.ProjectsDir + _name + "\\" + _name + ".xml");

            TxtProjectName.Text = result.ProjectName;
            TrkMaxWait.Value = result.MaxWait;
            TrkThreadCount.Value = result.ThreadCount;
            TrkLoopCount.Value = result.LoopCount;
            ChkClickMyLinks.Checked = result.ClickLinks;
            TxtProxyList.Text = result.ProxyList;
            ChkPremiumProxies.Checked = result.UsePremiumProxies;
            //if (!string.IsNullOrEmpty(result.AgentList))
            //GetAgentCount(result.AgentList);
            //if (!string.IsNullOrEmpty(result.ProxyList))
            // GetProxyCount(result.ProxyList);
            //_openAgentListDlg.FileName = result.AgentList;

            foreach (var contro in result.Sites.Select(site => new DomainControl { Domain = site.Site, Keywords = site.Keywords }))
            {
                PnlDomains.Controls.Add(contro);
            }

            foreach (var engine in result.Engines.Select(item => item.Split('|')[0]))
            {
                for (var i = 0; i <= LstEngines.Items.Count - 1; i++)
                {
                    if ((LstEngines.Items[i].ToString().Contains(engine)))
                    {
                        LstEngines.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
        }

        private void SaveSettings()
        {
            if (PnlDomains.Controls.Cast<DomainControl>().Any(control => control.Keywords.Count > 3))
            {
                MessageBox.Show(@"Only 3 keywords per domain!");
                return;
            }

            if (PnlDomains.Controls.Cast<DomainControl>().Any(control => !control.Domain.Contains(".")))
            {
                MessageBox.Show(@"Please check your domains for proper TLD's", @"Warning - Check TLD's", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (PnlDomains.Controls.Cast<DomainControl>().Any(control => control.Keywords.Count < 1))
            {
                MessageBox.Show(@"Please enter at least 1 keyword for each domain", @"Warning - Check Keywords", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(TxtProjectName.Text))
            {
                MessageBox.Show(@"Please enter a project name!");
                return;
            }

            if (LstEngines.CheckedItems.Count < 1)
            {
                MessageBox.Show(@"Please select at least 1 search engine", @"Warning - Check Search Engines", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (PnlDomains.Controls.Count < 1)
            {
                MessageBox.Show(@"Please add at least 1 domain");
                return;
            }

            if (!_load)
            {
                if (Directory.Exists(DirStructure.ProjectsDir + TxtProjectName.Text))
                {
                    MessageBox.Show(@"Project name already exist, choose a new name please", @"Error - Project Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var sites = (from DomainControl domain in PnlDomains.Controls
                         where !string.IsNullOrEmpty(domain.Domain) && domain.Keywords != null
                         select new SiteModel
                         {
                             Keywords = domain.Keywords,
                             Site = domain.Domain
                         }).ToList();

            Directory.CreateDirectory(DirStructure.ProjectsDir + TxtProjectName.Text);

            var engines = (from CheckListBoxItem item in LstEngines.CheckedItems select item.Text + "|" + item.Tag).ToList();

            var project = new ProjectModel
            {
                ProjectName = TxtProjectName.Text,
                ClickLinks = ChkClickMyLinks.Checked,
                ThreadCount = TrkThreadCount.Value,
                LoopCount = TrkLoopCount.Value,
                MaxWait = TrkMaxWait.Value,
                Engines = engines,
                Sites = sites,
                ProxyList = TxtProxyList.Text,
                UsePremiumProxies = ChkPremiumProxies.Checked
            };
            //Save project settings file
            ObjectXmlSerializer<ProjectModel>.Save(project, DirStructure.ProjectsDir + project.ProjectName + "\\" + project.ProjectName + ".xml");
            //Globals.OpenProjectName = project.ProjectName;
            Close();
        }

        private void BtnCreateClick(object sender, EventArgs e)
        {
            if (!_load)
                Globals.ActiveProject = TxtProjectName.Text;
            SaveSettings();
        }

        private void BtnLoadProxyListClick(object sender, EventArgs e)
        {
            _openProxyListDlg.Filter = @"ALL FILES(*.*)|*.*";
            _openProxyListDlg.InitialDirectory = Application.StartupPath;
            _openProxyListDlg.ShowDialog(this);
            if (string.IsNullOrEmpty(_openProxyListDlg.FileName)) return;
            TxtProxyList.Text = _openProxyListDlg.FileName;
        }

        private void TrkThreadCountScroll(object sender, EventArgs e)
        {
            TtMain.SetToolTip(TrkThreadCount, TrkThreadCount.Value.ToString());
        }

        private void TrkLoopCountScroll(object sender, EventArgs e)
        {
            TtMain.SetToolTip(TrkLoopCount, TrkLoopCount.Value.ToString());
        }

        private void TrkMaxWaitScroll(object sender, EventArgs e)
        {
            TtMain.SetToolTip(TrkMaxWait, TrkMaxWait.Value.ToString());
        }

        private void ChkPremiumProxiesCheckedChanged(object sender, EventArgs e)
        {
            PnlProxy.Enabled = !ChkPremiumProxies.Checked;
        }
    }

    public class CheckListBoxItem
    {
        public object Tag;
        public string Text;

        public override string ToString() { return Text; }
    }
}
