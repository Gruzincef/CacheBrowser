using System.Collections.Generic;
using System.IO;
using System;
namespace CacheBrowser
{
    class Hrome : WorkBrowser
    {

        private string[] _NameFindFiles = { "Login Data", "Login Data For Account", "History", "sessionCheckpoints.json", "cookies.sqlite", "Cookies", "Network Persistent State", "Reporting and NEL", "TransportSecurity", "Trust Tokens", "Bookmarks"};
        
        public Hrome(string userpath)
        {
            
            _UserPath = userpath;
            start();
        }

        public Hrome()
        {
            start();
        }
        private void start()
        {
            _ApplicationDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _BrowserPath = Path.Combine(_ApplicationDirectory, "Google\\Chrome\\User Data\\Default");
            _NameProcess = "chrome";
        }
        public void DeleteData()
        {
            KillProicess();
            DeleteData(FindData(_BrowserPath, _NameFindFiles));
            DeleteData(FindData(Path.Combine(_BrowserPath, "Network"), _NameFindFiles));
        }
        public void GetConfig()
        {
            CopyData(CreateDataInImport(FindData(_BrowserPath, _NameFindFiles)));
            CopyData(CreateDataInImport(FindData(Path.Combine(_BrowserPath, "Network"), _NameFindFiles)));
        }

        public void SetConfig()
        {
            KillProicess();
            List<string> listdir = FindData(Path.Combine(_UserPath, "Google"));
            CopyData(CreateDataInExport(listdir));
        }
     
    }
}
