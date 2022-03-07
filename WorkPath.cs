using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkBrowser
{
    class WorkPath
    {
        public WorkPath()
        {
        }

        public string UpdatePath(string correctedpath,string samplepath, int numberdirectory)
        {

            string[] paths = samplepath.Split('\\');
            for (int i = paths.Length - numberdirectory; i < paths.Length; i++)
                correctedpath = Path.Combine(correctedpath, paths[i]);
            return correctedpath;
        }
        //отсчет идет с конца пути 
        public string UpdateAndCreatePath(string correctedpath, string samplepath, int numberdirectory)
        {

            string[] paths = samplepath.Split('\\');
            for (int i = paths.Length-numberdirectory; i < paths.Length; i++)
            {
                correctedpath = Path.Combine(correctedpath, paths[i]);
                if (!Directory.Exists(correctedpath)) Directory.CreateDirectory(correctedpath);
            }
            return correctedpath;
        }

        public bool TestPath(string path)
        {
            string[] paths = path.Split('\\');
            string testpath = "";
            for (int i = 0; i < paths.Length - 1; i++) 
            {
                testpath = Path.Combine(testpath, paths[i]);
                if (!Directory.Exists(testpath)) return false;
            }
            return true;
        }
        public bool CreatePath(string path)
        {
           
            string[] paths = path.Split('\\');
            string testpath = "";
            paths[0] = paths[0] + "\\";
            for (int i = 0; i < paths.Length - 1; i++)
            {
                testpath = Path.Combine(testpath, paths[i]);
                if (!Directory.Exists(testpath)) 
                    Directory.CreateDirectory(testpath);
            }
            return true;
        }

    }
}
