using System;
using System.IO;

namespace SeHydra.Settings
{
    public class Log
    {
        public static void Add2Log(string entry, string project)
        {
            project = DirStructure.ProjectsDir + project + "\\" + project + "_log.txt";
            using (var write = new StreamWriter(project,true))
            {
                write.WriteLine(DateTime.Now + ": " + entry);
            }
        }
    }
}