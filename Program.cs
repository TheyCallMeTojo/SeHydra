using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using SeHydra.Interface;
using SeHydra.Settings;

namespace SeHydra
{
    static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            //Accept SSL - Really don't need this anymore since I've made it open source. I was using this
            //with a custom API served over HTTPS
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
