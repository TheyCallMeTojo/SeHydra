using System;

namespace SeHydra.Settings
{
    class DirStructure
    {
        public static string BaseDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SeHydra\\";
        public static string ProjectsDir = BaseDir + "Projects\\";
    }
}
