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
            //DB syntax removed
            Settings.Globals.Proxies.Clear();
            const string q = "";
            var server = new Security.Server();
            var results = server.GetDataTable("");
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
                    data = client.DownloadString("http://extremefarmer.com/test.php"); //This isn't live anymore. It just allowed to test if proxy worked
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
