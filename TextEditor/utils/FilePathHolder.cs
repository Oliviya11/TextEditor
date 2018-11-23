using System;
using System.IO;

namespace TextEditor.utils
{
    internal static class FilePathHolder
    {
        internal static string AppLocation = AppDomain.CurrentDomain.BaseDirectory;
        internal static string SaveUserFile = AppLocation + "user.xml";
        internal static readonly string LogFilepath = AppLocation + "log.txt";
        internal static bool CheckFileExists(string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            return file.Exists;
        }
        internal static void CheckAndCreateFile(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (!file.Directory.Exists)
                {
                    file.Directory.Create();
                }
                if (!file.Exists)
                {
                    file.Create().Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
