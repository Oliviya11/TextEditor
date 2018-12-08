using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DBModels;
using DBAdapter;

namespace TextEditor.managers
{
    public class DbManager
    {
        static DbManager _instance = null;

        private DbManager() {
            
        }

        public User GetUser(string login)
        {
            User user = null;
            using (TextEditorDbContext db = new DBAdapter.TextEditorDbContext())
            {
                user = db.Users.FirstOrDefault(u => u.Login == login);
            }
            return user;
        }

        public void CreateUser(User user)
        {
            using (TextEditorDbContext db = new DBAdapter.TextEditorDbContext())
            {
                user.EditingInfos = new List<EditingInfo>();
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public bool DoesUserExist(string login)
        {
            return GetUser(login) != null;
        }

        public EditingInfo CreateEditingInfo(User user, string filePath, bool isFileChanged, DateTime editingDate) {
            EditingInfo info = null;
            using (TextEditorDbContext db = new TextEditorDbContext())
            {
                User dbUser = db.Users.FirstOrDefault(u => u.Id == user.Id);
                info = new EditingInfo(filePath, isFileChanged, editingDate);
                if (dbUser.EditingInfos == null)
                {
                    dbUser.EditingInfos = new List<EditingInfo>();
                }
                dbUser.EditingInfos.Add(info);
                info.User = dbUser;
                db.EditingInfos.Add(info);
                db.SaveChanges();
            }

            return info;
        }

        public List<EditingInfo> GetEditingInfoes(string filePath)
        {
            List<EditingInfo> result = null;
            using (TextEditorDbContext db = new TextEditorDbContext())
            {
                result = db.EditingInfos.Include(e => e.User).Where(i => i.FilePath == filePath).ToList();
            }
            return result;
        }

        public static DbManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DbManager();
                }

                return _instance;
            }
        }
    }
    
}
