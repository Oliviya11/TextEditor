using DBModels;
using TextEditor.utils;

namespace TextEditor.managers
{
    public class AutoLoginManager
    {
        static AutoLoginManager _instance = null;

        private AutoLoginManager() {}

        public bool isAutoLogin()
        {
            return readFromXMLAndRedirect();
        }

        public bool readFromXMLAndRedirect()
        {
            User user = SerializeManager.Instance.DeSerializeObject<User>(FilePathHolder.SaveUserFile);

            if (user != null && user.Login != null)
            {
                ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                User dbUser = client.GetUser(user.Login);

                if (dbUser == null)
                {
                    return false;
                }

                UserManager.Instance.CurrentUser = dbUser;
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
