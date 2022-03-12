using System;
using System.Collections.Generic;
using System.IO;

namespace WorkBrowser
{
    class Yandex : WorkBrowser
    {

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
        public void UnloadConfig()
        {
            CopyData(CreateDataInImport(FindData(_BrowserPath, _NameFindFiles)));
        }

        public void LoadConfig()
        {
            KillProicess();
            List<string> listdir = FindData(Path.Combine(_UserPath, "Yandex"));
            CopyData(CreateDataInExport(listdir));
        }

    }
}
