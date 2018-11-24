using DBModels;
using System;
using System.IO;
using TextEditor.utils;

namespace TextEditor.managers
{
    internal class StorageManager
    {
        static StorageManager _instance = null;

        private StorageManager()
        {

        }

        public void saveToXml(User user)
        {
            if (user != null)
            {
                try
                {
                    SerializeManager.Instance.SerializeObject<User>(user, FilePathHolder.SaveUserFile);
                }
                catch (Exception ex)
                {
                    Logger.Log("Failed to serialize user to file!", ex);
                }
            }
        }

        public void ClearUserStorage()
        {
            try
            {
                if (FilePathHolder.CheckFileExists(FilePathHolder.SaveUserFile))
                {
                    File.Delete(FilePathHolder.SaveUserFile);
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Failed to clear storage!", ex);
            }
            
        }

        public static StorageManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StorageManager();
                }

                return _instance;
            }
        }
    }
}
