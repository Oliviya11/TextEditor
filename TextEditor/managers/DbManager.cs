using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DBModels;

namespace TextEditor.managers
{
    
    internal class DbManager
    {
        static DbManager _instance = null;

        private DbManager() {
            
        }

        internal User GetUser(string login)
        {
            User user = null;
            using (TextEditorDbContext db = new TextEditorDbContext())
            {
                user = db.Users.FirstOrDefault(u => u.Login == login);
            }
            return user;
        }

        internal void CreateUser(User user)
        {
            using (TextEditorDbContext db = new TextEditorDbContext())
            {
                user.EditingInfos = new List<EditingInfo>();
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        internal bool DoesUserExist(string login)
        {
            return GetUser(login) != null;
        }

        internal EditingInfo CreateEditingInfo(User user, string filePath, bool isFileChanged, DateTime editingDate) {
            EditingInfo info = null;
            using (TextEditorDbContext db = new TextEditorDbContext())
            {
                User dbUser = db.Users.Include(u => u.EditingInfos).FirstOrDefault(u => u.Id == user.Id);
                info = new EditingInfo(filePath, isFileChanged, editingDate);
                dbUser.EditingInfos.Add(info);
                info.User = dbUser;
                db.EditingInfos.Add(info);
                db.SaveChanges();
            }

            return info;
        }

        internal List<EditingInfo> GetEditingInfoes(string filePath)
        {
            List<EditingInfo> result = null;
            using (TextEditorDbContext db = new TextEditorDbContext())
            {
                result = db.EditingInfos.Include(e => e.User).Where(i => i.FilePath == filePath).ToList();
            }
            return result;
        }

        internal static DbManager Instance
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
