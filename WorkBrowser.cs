using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace WorkBrowser
{
    public abstract class WorkBrowser
    {
        protected string _UserPath;
        protected string _ApplicationDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        protected string _BrowserPath;
        protected string _NameProcess;
        public void DeleteData(List<string> pathFiles)
        {
            foreach (string entry in pathFiles)
            {
                File.Delete(entry);
            }
            
        }
        public void CopyData(Dictionary<string, string> pathFiles)
        {
          foreach (KeyValuePair<string, string> entry in pathFiles)
            {
                if (File.Exists(entry.Value))
                    File.Delete(entry.Value);
                File.Copy(entry.Key, entry.Value);
            }
        }

       //Поиск поддиректорий для последующего импорта 
        protected List<string> AllSubDirectory(string directory)
        {
            List<string> listdir = new List<string>();
            if (Directory.Exists(directory))
            {
                string[] dirs = Directory.GetDirectories(directory);
                foreach (string dir in dirs)
                {
                    var di = new DirectoryInfo(dir);
                    if (di.Exists)
                    {
                        if ((!di.Attributes.HasFlag(FileAttributes.System)) && (!di.Attributes.HasFlag(FileAttributes.Temporary)) && (!di.Attributes.HasFlag(FileAttributes.Temporary)))
                        {
                            listdir.Add(dir);
                            listdir.AddRange(AllSubDirectory(dir));
                        }
                    }
                }
            }
            return listdir;
        }
       
        protected List<string> FindData(string directory)
        {
            List<string> endlistfiles = new List<string>();
            List<string> directories = AllSubDirectory(directory);
            foreach (string pathdata in directories)
            {
                string[] files = Directory.GetFiles(pathdata);
                foreach (string file in files)
                {
                    endlistfiles.Add(file);
                }
            }
            return endlistfiles;
        }
        
        protected Dictionary<string, string> CreateDataInImport(List<string> listfile)
        {
            Dictionary<string, string> endlistfiles = new Dictionary<string, string>();
            string pathsave;
            WorkPath workpath = new WorkPath();
            foreach (string file in listfile)
            {
                pathsave = _UserPath + file.Substring(_ApplicationDirectory.Length, file.Length- _ApplicationDirectory.Length);
                endlistfiles.Add(file, pathsave);
                workpath.CreatePath(Path.GetFullPath(pathsave));
            }
           return endlistfiles;
        }
        protected Dictionary<string, string> CreateDataInExport(List<string> listfile)
        {
            Dictionary<string, string> endlistfiles = new Dictionary<string, string>();
            string pathsave;
            WorkPath workpath = new WorkPath();
            foreach (string file in listfile)
            {
                pathsave = _ApplicationDirectory + file.Substring(_UserPath.Length, file.Length - _UserPath.Length);
                endlistfiles.Add(file, pathsave);
                workpath.CreatePath(Path.GetFullPath(pathsave));
            }
            return endlistfiles;
        }

        protected List<string> FindData(string dir, string[] listnamefile)
        {
            List<string> endlistfiles = new List<string>();
            if (Directory.Exists(dir))
            {
                foreach (string name in listnamefile)
                {
                    string[] files = Directory.GetFiles(dir, name);
                    foreach (string file in files)
                    {
                        endlistfiles.Add(file);
                    }
                }
                string[] pathdatas = Directory.GetDirectories(dir);
                foreach (string pathdata in pathdatas)
                {
                    foreach (string name in listnamefile)
                    {
                        string[] files = Directory.GetFiles(pathdata, name);
                        foreach (string file in files)
                        {
                            endlistfiles.Add(file);
                        }
                    }
                }
            }
            return endlistfiles;
        }

        protected void KillProicess()
        {
            Process[] ps1 = System.Diagnostics.Process.GetProcessesByName(_NameProcess);
            foreach (Process p1 in ps1)
                p1.Kill();
            while (ifProcessIsRunning(_NameProcess))
            { }

        }

        private static bool ifProcessIsRunning(string processName)
        {
            Process[] procs = Process.GetProcessesByName(processName);
            if (procs.Length > 0)
            {
                return true;
            }
            return false;
        }
    }
}
