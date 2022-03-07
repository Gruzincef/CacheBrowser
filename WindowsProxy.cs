using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;


namespace WorkBrowser
{
    class WindowsProxy
    {
        string _UserPath;
        public WindowsProxy(string userpath)
        {
            _UserPath = userpath;
        }
        public void GetProxi()
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\");
            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
            start.FileName = Environment.GetFolderPath(Environment.SpecialFolder.Windows)+"\\regedit.exe /e " + Path.Combine(_UserPath, "Proxi") + " " + reg.ToString();
            //start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; 
            start.CreateNoWindow = true;
            Process processTemp = new Process();
            processTemp.StartInfo = start;
            processTemp.EnableRaisingEvents = true;
         //   processTemp.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processTemp.Start();
            //Process.Start("regedit.exe", "/e " + Path.Combine(_UserPath, "Proxi") + " " + reg.ToString());
        }
        public void SetProxi()
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\");
            Process.Start("regedit.exe", "/e " + Path.Combine(_UserPath, "Proxi") + " " + reg.ToString());
        }

    }
}
