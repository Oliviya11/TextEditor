﻿using System.Windows.Controls;
using TextEditor.ViewModels;

namespace TextEditor
{
    /// <summary>
    /// Логика взаимодействия для LogInControl.xaml
    /// </summary>
    public partial class LogInControl : UserControl
    {
        public LogInControl()
        {
            InitializeComponent();
            var loginViewModel = new LoginViewModel();
            DataContext = loginViewModel;

        }
    }
}
