using DBModels;
using System;
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
    internal class LoginViewModel : INotifyPropertyChanged
    {
        #region
        private string _password;
        private string _login;

        private bool _isAutoLogin = false;

        #region Commands
        private ICommand _closeCommand;
        private ICommand _signInCommand;
        private ICommand _signUpCommand;
        #endregion
        #endregion

        #region Properties
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
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

        public ICommand SignInCommand
        {
            get
            {
                return _signInCommand ?? (_signInCommand = new RelayCommand<object>(SignInExecute, SignInCanExecute));
            }
        }

        public ICommand SignUpCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(SignUpExecute));
            }
        }

        #endregion
        #endregion

        #region ConstructorAndInit
        internal LoginViewModel()
        {

        }
        #endregion

        private async void SignInExecute(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            User currentUser;
            bool result = await Task.Run(() => {
                if (_isAutoLogin)
                {
                    return true;
                }
                try
                {
                    currentUser = DbManager.Instance.GetUser(_login);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format(Resources.SignIn_FailedToGetUser, Environment.NewLine,
                        ex.Message));
                    return false;
                }
                if (currentUser == null)
                {
                    MessageBox.Show(String.Format(Resources.SignIn_UserDoesntExist, _login));
                    return false;
                }
                UserManager.Instance.CurrentUser = currentUser;
                StorageManager.Instance.saveToXml(currentUser);
                return true;

            });
            LoaderManager.Instance.HideLoader();
            if (result)
            {
                NavigationManager.Instance.Navigate(ModesEnum.TextEditor);
            }
        }

        private bool SignInCanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_login) && !String.IsNullOrWhiteSpace(_password);
        }

        private void SignUpExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.SignUp);
        }

        private void CloseExecute(object obj)
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
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
