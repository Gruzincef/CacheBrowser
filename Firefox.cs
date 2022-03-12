using System.Collections.Generic;
using System.IO;
using System;
namespace WorkBrowser
{
    class Firefox : WorkBrowser
    {
        private string[] _NameFindFiles = { "logins.json", "key3.db" , "key4.db", "signons.sqlite", "sessionCheckpoints.json", "cookies.sqlite", "profiles.ini","places.sqlite", "installs.ini" };
        public Firefox(string userpath)
        {

         _ApplicationDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
         _BrowserPath = Path.Combine(_ApplicationDirectory, "Mozilla\\Firefox\\");
         _UserPath = userpath;
         _NameProcess = "firefox";
        }

        public Firefox()
        {
            _ApplicationDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _BrowserPath = Path.Combine(_ApplicationDirectory, "Mozilla\\Firefox\\");
            _NameProcess = "firefox";
        }
        public void DeleteData()
        {
            KillProicess();
            DeleteData(FindData(Path.Combine(_BrowserPath, "Profiles"), _NameFindFiles));
            DeleteData(FindData(_BrowserPath, _NameFindFiles));
        }
        public  void GetConfig()
        {

            CopyData(CreateDataInImport(FindData(Path.Combine(_BrowserPath, "Profiles"), _NameFindFiles)));
            CopyData(CreateDataInImport(FindData(_BrowserPath, _NameFindFiles)));
        }

        public void SetConfig()
        {
            KillProicess();
            string oldprofiles=Path.Combine(_BrowserPath, "Profiles");
            if (Directory.Exists(oldprofiles))
            {
                Directory.Delete(oldprofiles, true);
                Directory.CreateDirectory(oldprofiles);
            }
            List<string> listdir = FindData(Path.Combine(_UserPath, "Mozilla"));
            Dictionary<string,string> listfile= CreateDataInExport(listdir);
            CopyData(listfile);

        }

    }
}
