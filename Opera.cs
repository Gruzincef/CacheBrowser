﻿using System;
using System.Collections.Generic;
using System.IO;

namespace WorkBrowser
{
    class Opera : WorkBrowser
    {
        private string[] _NameFindFiles = { "Login Data", "bookmarks", "Cookies", "Reporting and NEL" };

        public Opera(string userpath)
        {
            _ApplicationDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _UserPath = userpath;
            _BrowserPath = Path.Combine(_ApplicationDirectory, "Opera Software\\Opera Stable");
            _NameProcess = "opera";
        }

        public Opera()
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
        public void ImportData()
        {
            CopyData(CreateDataInImport(FindData(_BrowserPath, _NameFindFiles)));
            CopyData(CreateDataInImport(FindData(Path.Combine(_BrowserPath, "Network"), _NameFindFiles)));
        }

        public void ExportData()
        {
            KillProicess();
            List<string> listdir = FindData(Path.Combine(_UserPath, "Opera Software"));
            CopyData(CreateDataInExport(listdir));
        }
    }
}
