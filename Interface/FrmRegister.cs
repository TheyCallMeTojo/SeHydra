using System;
using System.Diagnostics;
using System.Windows.Forms;
using SeHydra.Security;

namespace SeHydra.Interface
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void BtnRegisterClick(object sender, EventArgs e)
        {
            var server = new Server();
            if (!string.IsNullOrEmpty(TxtEmail.Text))
            {
                try
                {
                    var res = server.ExecuteNonQuery("UPDATE Customers SET Active=1, KeyCode='" +
                    TxtSerial.Text + "' WHERE Active=0 AND Email='" + TxtEmail.Text + "'");
                    if (res != 1)
                    {
                        MessageBox.Show(@"Activation failed, check your email and try again");
                        return;
                    }
                    new FrmMain(null).Show();
                    Hide();
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Please check your details and try again.");
                }
            }
            else
            {
                MessageBox.Show(@"Please enter an email address");
            }
        }

        private void FrmRegisterLoad(object sender, EventArgs e)
        {
            TxtSerial.Text = FingerPrint.Value();
        }

        private static void BtnBuyClick(object sender, EventArgs e)
        {
            Process.Start("https://www.plimus.com/jsp/buynow.jsp?contractId=3037670");
        }
    }
}
