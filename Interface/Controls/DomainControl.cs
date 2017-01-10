using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SeHydra.Interface.Controls
{
    public partial class DomainControl : UserControl
    {
        public DomainControl()
        {
            InitializeComponent();
        }

        private void BtnRemoveClick(object sender, EventArgs e)
        {
            Dispose();
        }

        public List<string> Keywords
        {
            get
            {
                return string.IsNullOrEmpty(TxtKeywords.Text) ? new List<string>() : TxtKeywords.Text.Split(',').ToList();
            }
            set
            {
                foreach (var word in value.Where(word => !string.IsNullOrEmpty(word)))
                {
                    TxtKeywords.Text += word + @",";
                }
                TxtKeywords.Text = TxtKeywords.Text.Substring(0, TxtKeywords.Text.Length - 1);
            }
        }

        public string Domain
        {
            get { return TxtDomain.Text; }
            set { TxtDomain.Text = value; }
        }
    }
}
