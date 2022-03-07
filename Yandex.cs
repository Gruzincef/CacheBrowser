using System;
using System.Collections.Generic;
using System.IO;

namespace WorkBrowser
{
    class Yandex : WorkBrowser
    {

        //private string[] _NameFindFiles = { "Login Data", "Login Data For Account", "History", "sessionCheckpoints.json", "cookies.sqlite", "Cookies", "Network Persistent State", "Reporting and NEL", "TransportSecurity", "Trust Tokens" };
        private string[] _NameFindFiles = { "Cookies", "Ya Passman Data"};
        public Yandex(string userpath)
        {
            _UserPath = userpath;
            start();
        }

        public Yandex()
        {
            start();
        }
        private void start()
        {
            _ApplicationDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _BrowserPath = Path.Combine(_ApplicationDirectory, "Yandex\\YandexBrowser\\User Data\\Default");
            _NameProcess = "browser";
        }
        public void DeleteData()
        {
            KillProicess();
            DeleteData(FindData(_BrowserPath, _NameFindFiles));
        }
        public void ImportData()
        {
            CopyData(CreateDataInImport(FindData(_BrowserPath, _NameFindFiles)));
        }

        public void ExportData()
        {
            KillProicess();
            List<string> listdir = FindData(Path.Combine(_UserPath, "Yandex"));
            CopyData(CreateDataInExport(listdir));
        }

    }
}
