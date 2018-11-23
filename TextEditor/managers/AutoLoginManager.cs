using TextEditor.Models;
using TextEditor.utils;

namespace TextEditor.managers
{
    public class AutoLoginManager
    {
        static AutoLoginManager _instance = null;

        private AutoLoginManager() {}

        public bool isAutoLogin()
        {
            return readFromXml();
        }

        public bool readFromXml()
        {
            User user = SerializeManager.Instance.DeSerializeObject<User>(FilePathHolder.SaveUserFile);
            if (user != null && user.Login != null)
            {
                
                UserManager.Instance.CurrentUser = DbManager.Instance.GetUser(user.Login);
                NavigationManager.Instance.Navigate(ModesEnum.TextEditor);
                return true;
            }

            return false;
        }

        public static AutoLoginManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AutoLoginManager();
                }

                return _instance;
            }
        }
    }
}
