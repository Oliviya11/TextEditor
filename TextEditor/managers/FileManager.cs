using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditor.utils;

namespace TextEditor.managers
{
    public class FileManager
    {
        static FileManager _instance;
        string _currentFileName = null;
        string _fileContent = null;
        public Signal signalOnRead = new Signal();

        private FileManager() { }

        public void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text|*.txt|All|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var reult = Task.Run(() =>
                {
                    CurrentFileName = openFileDialog.FileName;
                    StreamReader sr = new StreamReader(CurrentFileName);
                    _fileContent = sr.ReadToEnd();
                    sr.Close();
                    signalOnRead.Invoke();
                });
            }
        }

        public string FileContent
        {
            get
            {
                return _fileContent;
            }
            private set { }
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
