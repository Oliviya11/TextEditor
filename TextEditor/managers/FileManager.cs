using System.IO;
using System.Windows.Forms;

namespace TextEditor.managers
{
    public class FileManager
    {
        static FileManager _instance;
        string _currentFileName = null;
        string _fileContent = null;

        private FileManager() { }

        public string OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text|*.txt|All|*.*";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CurrentFileName = openFileDialog.FileName;
                StreamReader sr = new StreamReader(CurrentFileName);
                _fileContent = sr.ReadToEnd();
                sr.Close();
            }

            return _fileContent;
        }

        public bool SaveFile(string newFileContent)
        {
            if (_fileContent == newFileContent || string.IsNullOrEmpty(CurrentFileName))
            {
                return false;
            }

            using (StreamWriter writer = new StreamWriter(CurrentFileName))
            {
                writer.Write(newFileContent);
            }

            return true;
        }

        public string CurrentFileName
        {
            get
            {
                return _currentFileName;
            }

            set
            {
                _currentFileName = value;
            }
        }

        public static FileManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FileManager();
                }

                return _instance;
            }
        }
    }
}
