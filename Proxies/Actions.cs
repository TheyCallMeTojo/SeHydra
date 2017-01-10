using System;
using System.Data;
using System.IO;
using System.Net;

namespace SeHydra.Proxies
{
    class Actions
    {
        public static void LoadProxyList()
        {
            Settings.Globals.Proxies.Clear();
            const string q = "TnNlQqlu+jXyOyOva/JK9KfIPeBOfKf9yrM4Io7NLIh9TMlIx2z0VMOVewnoNI8yaQnAYW8h1W4V/4fmtdngsw==";
            var server = new Security.Server();
            var results = server.GetDataTable(Security.Cryptor.DecryptStringAes(q, "109237sddsdDD"));
            foreach (DataRow row in results.Rows)
            {
                Settings.Globals.Proxies.Add(row[1].ToString());
            }
        }

        public static void LoadProxyListFromFile(string proxyList)
        {
            string line;
            var file = new StreamReader(proxyList);
            while ((line = file.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(line))
                    Settings.Globals.Proxies.Add(line);
            }
        }

        public static bool CheckProxy(string proxyport)
        {
            var proxy = new WebProxy(proxyport);
            try
            {
                string data;
                using (var client = new WebClient())
                {
                    client.Proxy = proxy;
                    data = client.DownloadString("http://extremefarmer.com/test.php");
                    client.Dispose();
                }
                return data.Contains("hit");
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
