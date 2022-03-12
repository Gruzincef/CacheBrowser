using System;
using System.Collections.Generic;
using System.IO;

namespace WorkBrowser
{
    class Opera : WorkBrowser
    {
        private string[] _NameFindFiles = { "Login Data", "Bookmarks", "Cookies", "Reporting and NEL","History" };

        public Opera(string userpath)
        {
            _UserPath = userpath;
            start();
        }

        public Opera()
        {
            start();
        }
        private void start()
        {
            _ApplicationDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _BrowserPath = Path.Combine(_ApplicationDirectory, "Opera Software\\Opera Stable");
            _NameProcess = "opera";
        }
        public void DeleteData()
        {
            KillProicess();
            DeleteData(FindData(_BrowserPath, _NameFindFiles));
            DeleteData(FindData(Path.Combine(_BrowserPath, "Network"), _NameFindFiles));
        }
        public void SetConfig()
        {
            CopyData(CreateDataInImport(FindData(_BrowserPath, _NameFindFiles)));
            CopyData(CreateDataInImport(FindData(Path.Combine(_BrowserPath, "Network"), _NameFindFiles)));
        }

        public void GetConfig()
        {
            KillProicess();
            List<string> listdir = FindData(Path.Combine(_UserPath, "Opera Software"));
            CopyData(CreateDataInExport(listdir));
        }
    }
}
