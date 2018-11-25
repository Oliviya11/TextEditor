using System;
using System.Collections.Generic;
using System.ServiceModel;
using DBModels;
using TextEditor.managers;

namespace TextEditorWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public EditingInfo CreateEditingInfo(User user, string filePath, bool isFileChanged, DateTime editingDate)
        {
            EditingInfo editingInfo = DbManager.Instance.CreateEditingInfo(user, filePath, isFileChanged, editingDate);
            return editingInfo;
        }

        public void CreateUser(User user)
        {
            DbManager.Instance.CreateUser(user);
        }

        public bool DoesUserExist(string login)
        {
            return DbManager.Instance.DoesUserExist(login);
        }

        public List<EditingInfo> GetEditingInfoes(string filePath)
        {
            List<EditingInfo> editingInfos = DbManager.Instance.GetEditingInfoes(filePath);
            return editingInfos;
        }

        public User GetUser(string login)
        {
            using (var myChannelFactory = new ChannelFactory<IService1>("DBConnection"))
            {
                IService1 client = myChannelFactory.CreateChannel();
                return client.GetUser(login);
            }
        }
    }
}
