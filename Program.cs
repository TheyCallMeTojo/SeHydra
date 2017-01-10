using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using SeHydra.Interface;
using SeHydra.Security;
using SeHydra.Settings;

namespace SeHydra
{
    static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            //Accept SSL
            ServicePointManager.ServerCertificateValidationCallback = (obj, certificate, chain, errors) => (true);

            if (!Directory.Exists(DirStructure.BaseDir))
            {
                Directory.CreateDirectory(DirStructure.BaseDir);
                Directory.CreateDirectory(DirStructure.ProjectsDir);
            }
            Application.EnableVisualStyles();

            Application.Run(new FrmMain(null));

        }
    }
}
