﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TextEditor.managers;
using TextEditor.Models;
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
                return _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(SignUpExecute, SignInCanExecute));
            }
        }

        #endregion
        #endregion

        #region ConstructorAndInit
        internal LoginViewModel()
        {

        }
        #endregion

        private void SignInExecute(object obj)
        {
            if (_isAutoLogin) return;

            User currentUser;
            try
            {
                currentUser = DbManager.Instance.GetUser(_login);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Resources.SignIn_FailedToGetUser, Environment.NewLine,
                    ex.Message));
                return;
            }
            if (currentUser == null)
            {
                MessageBox.Show(String.Format(Resources.SignIn_UserDoesntExist, _login));
                return;
            }
            //TODO: fix exception with Encrypting
            /*
            try
            {
                if (!currentUser.CheckPassword(_password))
                {
                    MessageBox.Show(Resources.SignIn_WrongPassword);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Resources.SignIn_FailedToValidatePassword, Environment.NewLine,
                    ex.Message));
                return;
            }
            */
            UserManager.Instance.CurrentUser = currentUser;
            saveToXml(currentUser);
            NavigationManager.Instance.Navigate(ModesEnum.TextEditor);
        }

        private bool SignInCanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_login) && !String.IsNullOrWhiteSpace(_password);
        }

        private void SignUpExecute(object obj)
        {
            if (_isAutoLogin) return;

            try
            {
                if (DbManager.Instance.DoesUserExist(_login))
                {
                    MessageBox.Show(String.Format(Resources.SignUp_UserAlreadyExists, _login));
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Resources.SignUp_FailedToValidateData, Environment.NewLine,
                    ex.Message));
                return;
            }
            try
            {
                UserManager.Instance.CurrentUser = DbManager.Instance.CreateUser(_login, _password);
                saveToXml(UserManager.Instance.CurrentUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Resources.SignUp_FailedToCreateUser, Environment.NewLine,
                    ex.Message));
                return;
            }

            MessageBox.Show(String.Format(Resources.SignUp_UserSuccessfulyCreated, _login));
            NavigationManager.Instance.Navigate(ModesEnum.TextEditor);
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
