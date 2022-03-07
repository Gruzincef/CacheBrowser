using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkBrowser
{
    WorkRegistry wr = new WorkRegistry("CurrentUser", @"Software\Microsoft\Windows\CurrentVersion\Internet Settings\");
    wr.ReadChapter();
    class reg
    {
        public string _Type;
        public string _Value;
        public string _Name;
    }
    class WorkRegistry
    {
        
        private RegistryKey _MachineKey;
        private string _Directory;
        private List<string> _Chapters = new List<string>();
        private Dictionary<string, List<reg>> _Value = new Dictionary<string, List<reg>>();
        public WorkRegistry(string registry,string directory)
        {
            if      (registry == "ClassesRoot")     _MachineKey = Registry.ClassesRoot;
            else if (registry == "CurrentConfig")   _MachineKey = Registry.CurrentConfig;
            else if (registry == "CurrentUser")     _MachineKey = Registry.CurrentUser;
            else if (registry == "LocalMachine")    _MachineKey = Registry.LocalMachine;
            else if (registry == "Users")           _MachineKey = Registry.Users;
            else if (registry == "PerformanceData") _MachineKey = Registry.PerformanceData;
            _Directory = directory;
        }

        public List<string> ReadDirectory(string directory)
        {
            List<string> registrykey = new List<string>();
            List<string> subNames = _MachineKey.OpenSubKey(directory, true).GetSubKeyNames().ToList();
            foreach (string subName in subNames)
            {
                registrykey.Add(Path.Combine(directory, subName));
                registrykey.AddRange(ReadDirectory(Path.Combine(directory ,subName)));
            }
            return registrykey;
       }
        public void ReadChapter()
        {
            _Chapters = ReadDirectory(_Directory);
            _Value=ListKey();
            Save("name");
        }
        private string ConvertToHex(Object txt)
        {
            // byte[] ba = Encoding.Default.GetBytes(txt);
            byte[] ba = (byte[])txt;
            StringBuilder st = new StringBuilder();
            foreach(byte a in ba)
            {
                st.Append(a.ToString()+" ");

            }
            return st.ToString(); ;
        }
        public Dictionary<string, List<reg>> ListKey()
        {
            reg rg ;
            List<string> keys = new List<string>();
            Dictionary<string, List<reg>> vl = new Dictionary<string, List<reg>>();
            foreach (string subName in _Chapters)  {
                RegistryKey key = _MachineKey.OpenSubKey(subName, true);
                List<string> k= key.GetValueNames().ToList();
                List<reg> sd = new List<reg>();
                foreach (string f in k)
                {
                    rg = new reg();
                    rg._Name = f;
                    rg._Type = key.GetValueKind(f).ToString().ToLower();
                    rg._Value = key.GetValue(f).ToString();
                    if (rg._Type == "expandstring")
                    {
                        rg._Type = "hex(2)";
                        rg._Value = ConvertToHex(key.GetValue(f));
                    }
                    
                    sd.Add(rg);
                }
                vl.Add(subName, sd);
            }
            return vl;
        }

        public void Save(string name)
        {
            StringBuilder sv = new StringBuilder();
            foreach (KeyValuePair<string, List<reg>> vl in _Value)
            {
                sv.Append("["+vl.Key +"]\r\n");
                foreach(reg v in vl.Value)
                {
                    if (v._Type == "string")
                        sv.Append("\"" + v._Name + "\"=\"" + v._Value + "\"\r\n");
                    else
                        sv.Append("\"" + v._Name + "\"="+ v._Type+":" + v._Value + "\r\n");
                }
            }
            File.WriteAllText(name, sv.ToString());
        }

    }
}
