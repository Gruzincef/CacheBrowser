using System;
using System.Collections.Generic;
using System.IO;

namespace WorkBrowser
{
    class Opera : WorkBrowser
    {
        private string[] _NameFindFiles = { "Login Data", "Login Data For Account", "History", "sessionCheckpoints.json", "cookies.sqlite", "Cookies", "Network Persistent State", "Reporting and NEL", "TransportSecurity", "Trust Tokens" };

        public Opera(string userpath)
        {
            _ApplicationDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _UserPath = userpath;
            _BrowserPath = Path.Combine(_ApplicationDirectory, "Google\\Chrome\\User Data\\Default");
            _NameProcess = "opera";
        }

        public Opera()
        {
            _ApplicationDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _BrowserPath = Path.Combine(_ApplicationDirectory, "Google\\Chrome\\User Data\\Default");
            _NameProcess = "opera";
        }
        public void DeleteData()
        {
            KillProicess();
            DeleteData(FindData(_BrowserPath, _NameFindFiles));
            DeleteData(FindData(Path.Combine(_BrowserPath, "Network"), _NameFindFiles));
        }
        public void ImportData()
        {
            CopyData(CreateDataInImport(FindData(_BrowserPath, _NameFindFiles)));
            CopyData(CreateDataInImport(FindData(Path.Combine(_BrowserPath, "Network"), _NameFindFiles)));
        }

        public void ExportData()
        {
            KillProicess();
            List<string> listdir = FindData(Path.Combine(_UserPath, "Google"));
            CopyData(CreateDataInExport(listdir));
        }
    }
}
