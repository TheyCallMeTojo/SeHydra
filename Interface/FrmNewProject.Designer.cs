namespace SeHydra.Interface
{
    partial class FrmNewProject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewProject));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PnlProxy = new System.Windows.Forms.Panel();
            this.BtnLoadProxyList = new System.Windows.Forms.Button();
            this.TxtProxyList = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChkPremiumProxies = new System.Windows.Forms.CheckBox();
            this.BtnSelectNone = new System.Windows.Forms.LinkLabel();
            this.BtnSelectAll = new System.Windows.Forms.LinkLabel();
            this.TrkMaxWait = new System.Windows.Forms.TrackBar();
            this.TrkLoopCount = new System.Windows.Forms.TrackBar();
            this.TrkThreadCount = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.LstEngines = new System.Windows.Forms.CheckedListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ChkClickMyLinks = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtProjectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PnlDomains = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnAddDomain = new System.Windows.Forms.Button();
            this.BtnCreate = new System.Windows.Forms.Button();
            this.LblEstimates = new System.Windows.Forms.Label();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.TtMain = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.PnlProxy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrkMaxWait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrkLoopCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrkThreadCount)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PnlProxy);
            this.groupBox1.Controls.Add(this.ChkPremiumProxies);
            this.groupBox1.Controls.Add(this.BtnSelectNone);
            this.groupBox1.Controls.Add(this.BtnSelectAll);
            this.groupBox1.Controls.Add(this.TrkMaxWait);
            this.groupBox1.Controls.Add(this.TrkLoopCount);
            this.groupBox1.Controls.Add(this.TrkThreadCount);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.LstEngines);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.ChkClickMyLinks);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtProjectName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 433);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project Settings";
            // 
            // PnlProxy
            // 
            this.PnlProxy.Controls.Add(this.BtnLoadProxyList);
            this.PnlProxy.Controls.Add(this.TxtProxyList);
            this.PnlProxy.Controls.Add(this.label3);
            this.PnlProxy.Enabled = false;
            this.PnlProxy.Location = new System.Drawing.Point(18, 213);
            this.PnlProxy.Name = "PnlProxy";
            this.PnlProxy.Size = new System.Drawing.Size(281, 50);
            this.PnlProxy.TabIndex = 29;
            // 
            // BtnLoadProxyList
            // 
            this.BtnLoadProxyList.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnLoadProxyList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLoadProxyList.Image = ((System.Drawing.Image)(resources.GetObject("BtnLoadProxyList.Image")));
            this.BtnLoadProxyList.Location = new System.Drawing.Point(224, 7);
            this.BtnLoadProxyList.Name = "BtnLoadProxyList";
            this.BtnLoadProxyList.Size = new System.Drawing.Size(40, 36);
            this.BtnLoadProxyList.TabIndex = 5;
            this.BtnLoadProxyList.UseVisualStyleBackColor = true;
            this.BtnLoadProxyList.Click += new System.EventHandler(this.BtnLoadProxyListClick);
            // 
            // TxtProxyList
            // 
            this.TxtProxyList.Location = new System.Drawing.Point(6, 15);
            this.TxtProxyList.Name = "TxtProxyList";
            this.TxtProxyList.Size = new System.Drawing.Size(213, 20);
            this.TxtProxyList.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, -2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Proxy List";
            // 
            // ChkPremiumProxies
            // 
            this.ChkPremiumProxies.AutoSize = true;
            this.ChkPremiumProxies.Checked = true;
            this.ChkPremiumProxies.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkPremiumProxies.Location = new System.Drawing.Point(18, 177);
            this.ChkPremiumProxies.Name = "ChkPremiumProxies";
            this.ChkPremiumProxies.Size = new System.Drawing.Size(119, 17);
            this.ChkPremiumProxies.TabIndex = 28;
            this.ChkPremiumProxies.Text = "Use Hosted Proxies";
            this.ChkPremiumProxies.UseVisualStyleBackColor = true;
            this.ChkPremiumProxies.CheckedChanged += new System.EventHandler(this.ChkPremiumProxiesCheckedChanged);
            // 
            // BtnSelectNone
            // 
            this.BtnSelectNone.AutoSize = true;
            this.BtnSelectNone.Location = new System.Drawing.Point(63, 409);
            this.BtnSelectNone.Name = "BtnSelectNone";
            this.BtnSelectNone.Size = new System.Drawing.Size(66, 13);
            this.BtnSelectNone.TabIndex = 23;
            this.BtnSelectNone.TabStop = true;
            this.BtnSelectNone.Text = "Select None";
            this.BtnSelectNone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnSelectNoneLinkClicked);
            // 
            // BtnSelectAll
            // 
            this.BtnSelectAll.AutoSize = true;
            this.BtnSelectAll.Location = new System.Drawing.Point(6, 409);
            this.BtnSelectAll.Name = "BtnSelectAll";
            this.BtnSelectAll.Size = new System.Drawing.Size(51, 13);
            this.BtnSelectAll.TabIndex = 22;
            this.BtnSelectAll.TabStop = true;
            this.BtnSelectAll.Text = "Select All";
            this.BtnSelectAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BtnSelectAllLinkClicked);
            // 
            // TrkMaxWait
            // 
            this.TrkMaxWait.AutoSize = false;
            this.TrkMaxWait.LargeChange = 1;
            this.TrkMaxWait.Location = new System.Drawing.Point(82, 109);
            this.TrkMaxWait.Maximum = 500;
            this.TrkMaxWait.Minimum = 1;
            this.TrkMaxWait.Name = "TrkMaxWait";
            this.TrkMaxWait.Size = new System.Drawing.Size(221, 29);
            this.TrkMaxWait.TabIndex = 21;
            this.TrkMaxWait.Value = 1;
            this.TrkMaxWait.Scroll += new System.EventHandler(this.TrkMaxWaitScroll);
            // 
            // TrkLoopCount
            // 
            this.TrkLoopCount.AutoSize = false;
            this.TrkLoopCount.LargeChange = 1;
            this.TrkLoopCount.Location = new System.Drawing.Point(81, 74);
            this.TrkLoopCount.Maximum = 100;
            this.TrkLoopCount.Minimum = 1;
            this.TrkLoopCount.Name = "TrkLoopCount";
            this.TrkLoopCount.Size = new System.Drawing.Size(221, 29);
            this.TrkLoopCount.TabIndex = 20;
            this.TrkLoopCount.Value = 10;
            this.TrkLoopCount.Scroll += new System.EventHandler(this.TrkLoopCountScroll);
            // 
            // TrkThreadCount
            // 
            this.TrkThreadCount.AutoSize = false;
            this.TrkThreadCount.BackColor = System.Drawing.SystemColors.Control;
            this.TrkThreadCount.LargeChange = 1;
            this.TrkThreadCount.Location = new System.Drawing.Point(80, 42);
            this.TrkThreadCount.Minimum = 1;
            this.TrkThreadCount.Name = "TrkThreadCount";
            this.TrkThreadCount.Size = new System.Drawing.Size(222, 29);
            this.TrkThreadCount.TabIndex = 19;
            this.TrkThreadCount.Value = 5;
            this.TrkThreadCount.Scroll += new System.EventHandler(this.TrkThreadCountScroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Select Engines";
            // 
            // LstEngines
            // 
            this.LstEngines.CheckOnClick = true;
            this.LstEngines.FormattingEnabled = true;
            this.LstEngines.Location = new System.Drawing.Point(9, 282);
            this.LstEngines.Name = "LstEngines";
            this.LstEngines.Size = new System.Drawing.Size(290, 124);
            this.LstEngines.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Max Wait";
            // 
            // ChkClickMyLinks
            // 
            this.ChkClickMyLinks.AutoSize = true;
            this.ChkClickMyLinks.Location = new System.Drawing.Point(19, 149);
            this.ChkClickMyLinks.Name = "ChkClickMyLinks";
            this.ChkClickMyLinks.Size = new System.Drawing.Size(128, 17);
            this.ChkClickMyLinks.TabIndex = 3;
            this.ChkClickMyLinks.Text = "Enable Deep Clicking";
            this.ChkClickMyLinks.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Loop Count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Thread Count";
            // 
            // TxtProjectName
            // 
            this.TxtProjectName.Location = new System.Drawing.Point(81, 19);
            this.TxtProjectName.Name = "TxtProjectName";
            this.TxtProjectName.Size = new System.Drawing.Size(218, 20);
            this.TxtProjectName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Project Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PnlDomains);
            this.groupBox2.Location = new System.Drawing.Point(323, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 345);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Domains && Keywords";
            // 
            // PnlDomains
            // 
            this.PnlDomains.AutoScroll = true;
            this.PnlDomains.AutoSize = true;
            this.PnlDomains.BackColor = System.Drawing.SystemColors.Control;
            this.PnlDomains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlDomains.Location = new System.Drawing.Point(3, 16);
            this.PnlDomains.Name = "PnlDomains";
            this.PnlDomains.Size = new System.Drawing.Size(257, 326);
            this.PnlDomains.TabIndex = 0;
            // 
            // BtnAddDomain
            // 
            this.BtnAddDomain.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnAddDomain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddDomain.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddDomain.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddDomain.Image")));
            this.BtnAddDomain.Location = new System.Drawing.Point(323, 360);
            this.BtnAddDomain.Name = "BtnAddDomain";
            this.BtnAddDomain.Size = new System.Drawing.Size(75, 42);
            this.BtnAddDomain.TabIndex = 11;
            this.BtnAddDomain.Text = "Add";
            this.BtnAddDomain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAddDomain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAddDomain.UseVisualStyleBackColor = true;
            this.BtnAddDomain.Click += new System.EventHandler(this.BtnAddDomainClick);
            // 
            // BtnCreate
            // 
            this.BtnCreate.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCreate.Image = ((System.Drawing.Image)(resources.GetObject("BtnCreate.Image")));
            this.BtnCreate.Location = new System.Drawing.Point(484, 394);
            this.BtnCreate.Name = "BtnCreate";
            this.BtnCreate.Size = new System.Drawing.Size(99, 42);
            this.BtnCreate.TabIndex = 10;
            this.BtnCreate.Text = "Create";
            this.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnCreate.UseVisualStyleBackColor = true;
            this.BtnCreate.Click += new System.EventHandler(this.BtnCreateClick);
            // 
            // LblEstimates
            // 
            this.LblEstimates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblEstimates.ForeColor = System.Drawing.Color.Chocolate;
            this.LblEstimates.Location = new System.Drawing.Point(37, 449);
            this.LblEstimates.Name = "LblEstimates";
            this.LblEstimates.Size = new System.Drawing.Size(546, 45);
            this.LblEstimates.TabIndex = 12;
            this.LblEstimates.Text = "Project Estimates";
            this.LblEstimates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Image = global::SeHydra.Properties.Resources.refresh;
            this.BtnRefresh.Location = new System.Drawing.Point(1, 458);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(30, 27);
            this.BtnRefresh.TabIndex = 13;
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefreshClick);
            // 
            // TtMain
            // 
            this.TtMain.BackColor = System.Drawing.SystemColors.Highlight;
            this.TtMain.ForeColor = System.Drawing.Color.White;
            // 
            // FrmNewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 448);
            this.Controls.Add(this.BtnAddDomain);
            this.Controls.Add(this.BtnRefresh);
            this.Controls.Add(this.LblEstimates);
            this.Controls.Add(this.BtnCreate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNewProject";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Project";
            this.Load += new System.EventHandler(this.FrmNewProjectLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PnlProxy.ResumeLayout(false);
            this.PnlProxy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrkMaxWait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrkLoopCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrkThreadCount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel BtnSelectNone;
        private System.Windows.Forms.LinkLabel BtnSelectAll;
        private System.Windows.Forms.TrackBar TrkMaxWait;
        private System.Windows.Forms.Button BtnLoadProxyList;
        private System.Windows.Forms.TrackBar TrkLoopCount;
        private System.Windows.Forms.TrackBar TrkThreadCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox LstEngines;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ChkClickMyLinks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtProjectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel PnlDomains;
        private System.Windows.Forms.Button BtnAddDomain;
        private System.Windows.Forms.Button BtnCreate;
        private System.Windows.Forms.Label LblEstimates;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.TextBox TxtProxyList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip TtMain;
        private System.Windows.Forms.CheckBox ChkPremiumProxies;
        private System.Windows.Forms.Panel PnlProxy;
    }
}