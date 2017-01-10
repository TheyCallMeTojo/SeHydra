using System;
using System.Collections.Generic;

namespace SeHydra.Models
{
    [Serializable]
   
    public class ProjectModel
    { 
        public string ProjectName { get; set; }
        public bool ClickLinks { get; set; }
        public bool UsePremiumProxies { get; set; }
        public int ThreadCount { get; set; }
        public int LoopCount { get; set; }
        public string LastRank { get; set; }
        public string ProxyList { get; set; }
        public string NewRank { get; set; }
        public int MaxWait { get; set; }
        public List<SiteModel> Sites { get; set; }
        public List<string> Engines { get; set; }
    }

    public class SiteModel
    {
        public string Site { get; set; }
        public List<string> Keywords { get; set; }
    }
}
