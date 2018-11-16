using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.Models;

namespace TextEditor.managers
{
    public class UserManager
    {
        static UserManager _instance = null;

        User _currentUser;

        private UserManager() { }

        public void Init()
        {

        }

        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                if (value != null)
                {
                    _currentUser = value;
                }
            }
        }

        public static UserManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserManager();
                }

                return _instance;
            }
        }
    }
}
