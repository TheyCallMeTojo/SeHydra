namespace SeHydra.Interface.Controls
{
    partial class DomainControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnRemove = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtDomain = new System.Windows.Forms.TextBox();
            this.TxtKeywords = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnRemove
            // 
            this.BtnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRemove.Location = new System.Drawing.Point(204, 4);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(20, 20);
            this.BtnRemove.TabIndex = 9;
            this.BtnRemove.TabStop = false;
            this.BtnRemove.Text = "X";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemoveClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Keywords, comma seperated";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Domain Name ( example.com )";
            // 
            // TxtDomain
            // 
            this.TxtDomain.Location = new System.Drawing.Point(2, 20);
            this.TxtDomain.Name = "TxtDomain";
            this.TxtDomain.Size = new System.Drawing.Size(159, 20);
            this.TxtDomain.TabIndex = 0;
            // 
            // TxtKeywords
            // 
            this.TxtKeywords.Location = new System.Drawing.Point(6, 63);
            this.TxtKeywords.Multiline = true;
            this.TxtKeywords.Name = "TxtKeywords";
            this.TxtKeywords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtKeywords.Size = new System.Drawing.Size(218, 65);
            this.TxtKeywords.TabIndex = 1;
            // 
            // DomainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtDomain);
            this.Controls.Add(this.TxtKeywords);
            this.Name = "DomainControl";
            this.Size = new System.Drawing.Size(229, 136);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtDomain;
        private System.Windows.Forms.TextBox TxtKeywords;
    }
}
