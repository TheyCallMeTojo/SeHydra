using System;
using System.Collections.Generic;
using System.Net;

namespace SeHydra.Search
{
    class Actions
    {
        public static List<string> Agents = new List<string>();


        public bool GoSearch(string site, string url, bool useProxies, out string usedp,
            out string error, bool deepclick = false)
        {
            GC.Collect();
            var newProx = "";
            url = url.Replace(site, "");
            var client = new WebClient();

            try
            {
                client.Headers.Add("user-agent", GetAgent());
                client.Headers.Add("referer", site);

                if (useProxies)
                {
                    newProx = GetProxy();
                    //MessageBox.Show(newProx);
                    var proxy = new WebProxy(newProx, true);
                    client.Proxy = proxy;
                }
                client.DownloadString(url);

                if (deepclick)
                {
                    site = site.Replace("http://", "").Replace("www.", "");
                    site = "http://" + site;
                    client.Headers.Add("referer", url);
                    client.DownloadString(new Uri(site));
                }
                //MessageBox.Show(content);
                client.Dispose();
                usedp = newProx;
                error = "None";
                return true;
            }
            catch (Exception e)
            {
                client.Dispose();
                Console.WriteLine(e.Message);
                usedp = newProx;
                error = e.Message;
                return false;
            }
            finally
            {
                client.Dispose();
            }
        }

        private static string GetAgent()
        {
            return "Mozilla Generic";
        }

        private static string GetProxy()
        {
            var rnd = new Random();
            if (Settings.Globals.UsedProxies.Count >= 2000)
            {
                Settings.Globals.UsedProxies.Clear();
            }

        Start:
            var inx = rnd.Next(0, Settings.Globals.Proxies.Count);
            var theProx = Settings.Globals.Proxies[inx];
            foreach (var item in Settings.Globals.UsedProxies)
            {
                if (item == theProx)
                    goto Start;
            }
            Settings.Globals.UsedProxies.Add(theProx);
            return theProx;
        }
    }
}
