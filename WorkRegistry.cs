using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkBrowser
{
    class WorkRegistry
    {
        private RegistryKey _MachineKey;
        private string _Directory;
        public WorkRegistry(string registry,string directory)
        {
            if      (registry == "ClassesRoot")     _MachineKey = Registry.ClassesRoot;
            else if (registry == "CurrentConfig")   _MachineKey = Registry.CurrentConfig;
            else if (registry == "CurrentUser")     _MachineKey = Registry.CurrentUser;
            else if (registry == "LocalMachine")         _MachineKey = Registry.LocalMachine;
            else if (registry == "Users")           _MachineKey = Registry.Users;
            else if (registry == "PerformanceData") _MachineKey = Registry.PerformanceData;
            _Directory = directory;
        }

        public List<string> ReadDirectory(string directory)
        {
            List<string> registrykey = new List<string>();
            List<string> subNames = _MachineKey.OpenSubKey(directory, true).GetValueNames().ToList();
            foreach (string subName in subNames)
            {
                registrykey.Add(Path.Combine(directory, subName));
                registrykey.AddRange(ReadDirectory(directory + "\\"+subName));
            }
            return registrykey;
       }
        public void lis()
        {
           ReadDirectory(_Directory);
        }

    }
}
