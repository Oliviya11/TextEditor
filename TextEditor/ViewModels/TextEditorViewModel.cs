﻿using DBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TextEditor.managers;
using TextEditor.Properties;
using TextEditor.utils;

namespace TextEditor.ViewModels
{
    class TextEditorViewModel : INotifyPropertyChanged
    {
        #region
        private string _fileContent;
        private string _editingInfo;

        #region Commands
        private ICommand _openFileCommand;
        private ICommand _saveFileCommand;
        private ICommand _logoutCommand;
        private ICommand _closeCommand;
        #endregion
        #endregion

        #region Properties
        public string FileContent
        {
            get
            {
                return _fileContent;
            }

            set
            {
                _fileContent = value;
                OnPropertyChanged();
            }
        }

        public string EditingInfo
        {
            get
            {
                return _editingInfo;
            }

            set
            {
                _editingInfo = value;
                OnPropertyChanged();
            }
        }
        #region Commands
        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseExecute));
            }
        }

        public ICommand OpenFileCommand
        {
            get
            {
                return _openFileCommand ?? (_openFileCommand = new RelayCommand<object>(OpenFileExecute));
            }
        }

        public ICommand SaveFileCommand
        {
            get
            {
                return _saveFileCommand ?? (_saveFileCommand = new RelayCommand<object>(SaveFileExecute));
            }
        }

        public ICommand LogoutCommand
        {
            get
            {
                return _logoutCommand ?? (_logoutCommand = new RelayCommand<object>(LogOutExecute));
            }
        }

        #endregion
        #endregion


        private void CloseExecute(object obj)
        {
            saveToXml(UserManager.Instance.CurrentUser);
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }

        private void saveToXml(User user)
        {
            try
            {
                SerializeManager.Instance.SerializeObject(user, FilePathHolder.SaveUserFile);
            }
            catch (Exception ex)
            {
                Logger.Log("Failed to serialize user to file!", ex);
            }
        }

        private void OpenFileExecute(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            try
            {
                FileManager.Instance.OpenFile();
                VoidDelegate deg = delegate ()
                {
                    initFileContent(FileManager.Instance.FileContent);

                    try
                    {
                        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                        List<EditingInfo> editingInfos = new List<EditingInfo>(client.GetEditingInfoes(FileManager.Instance.CurrentFileName));
                        if (editingInfos != null)
                        {
                            string result = "";
                            foreach (EditingInfo editingInfo in editingInfos)
                            {
                                result += editingInfo.User.Login + " " + editingInfo.EditingDate.ToString() + System.Environment.NewLine;
                            }
                            EditingInfo = result;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format(Resources.EditingInfo_FailedToRead, Environment.NewLine,
                            ex.Message));
                    }
                };
                FileManager.Instance.signalOnRead.AddListener(deg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Resources.OpenFile_FailedToRead, Environment.NewLine,
                    ex.Message));
                MessageBox.Show(ex.Message);
            }

            LoaderManager.Instance.HideLoader();
        }

        private void initFileContent(string content)
        {
            if (content != null)
            {
                FileContent = content;
            }
        }

        private async void SaveFileExecute(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            bool res = await Task.Run(() =>
            {
                try
                {
                    bool isSaved = FileManager.Instance.SaveFile(FileContent);
                    DateTime now = DateTime.Now;
                    ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                    EditingInfo info = client.CreateEditingInfo(UserManager.Instance.CurrentUser, FileManager.Instance.CurrentFileName, isSaved, now);
                    string result = info.User.Login + " " + info.EditingDate.ToString() + System.Environment.NewLine;
                    EditingInfo += result;
                    MessageBox.Show(Resources.SaveFile_Success);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format(Resources.OpenFile_FailedToSave, Environment.NewLine,
                        ex.Message));
                    return false;
                }
                return true;
            });
            LoaderManager.Instance.HideLoader();
        }

        private void LogOutExecute(object obj)
        {
            StorageManager.Instance.ClearUserStorage();
            NavigationManager.Instance.Navigate(ModesEnum.LogIn);
            EraseValues();
            FileManager.Instance.ClearFileManager();

        }

        private void EraseValues()
        {
            FileContent = null;
            EditingInfo = null;
        }

        #region EventsAndHandlers
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion
    }
}
