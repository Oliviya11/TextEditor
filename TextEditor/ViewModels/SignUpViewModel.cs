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
    class SignUpViewModel : INotifyPropertyChanged
    {
        private string _login;
        private string _name;
        private string _surname;
        private string _password;
        private string _email;

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private ICommand _signUpCommand;

        public ICommand SignUpCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(SignUpExecute, SignUpCanExecute));
            }
        }

        private ICommand _closeCommand;

        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseExecute));
            }
        }

        private ICommand _backCommand;

        public ICommand BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand<object>(BackExecute));
            }
        }

        private async void SignUpExecute(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            bool result = await Task.Run(() =>
            {
                try
                {
                    ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                    if (client.DoesUserExist(_login))
                    {
                        MessageBox.Show(String.Format(Resources.SignUp_UserAlreadyExists, _login));
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format(Resources.SignUp_FailedToValidateData, Environment.NewLine,
                        ex.Message));
                    return false;
                }
                try
                {
                    User user = new User(Login, Name, Surname, Password, Email);
                    UserManager.Instance.CurrentUser = user;
                    ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                    client.CreateUser(user);
                    StorageManager.Instance.saveToXml(UserManager.Instance.CurrentUser);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format(Resources.SignUp_FailedToCreateUser, Environment.NewLine,
                        ex.Message));
                    return false;
                }
                MessageBox.Show(String.Format(Resources.SignUp_UserSuccessfulyCreated, _login));
                return true;
            }
            );
            LoaderManager.Instance.HideLoader();
            if (result)
            {
                NavigationManager.Instance.Navigate(ModesEnum.TextEditor);
            }

            EraseValues();
        }

        private void EraseValues()
        {
            Login = null;
            Name = null;
            Surname = null;
            Password = null;
            Email = null;
        }

        private bool SignUpCanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_login) && !String.IsNullOrWhiteSpace(_password) 
                && !String.IsNullOrWhiteSpace(_email) && !String.IsNullOrWhiteSpace(_name)
                && !String.IsNullOrWhiteSpace(_surname);
        }

        private void CloseExecute(object obj)
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }

        private void BackExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.LogIn);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
