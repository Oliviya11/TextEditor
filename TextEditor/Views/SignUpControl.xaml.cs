using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TextEditor.ViewModels;

namespace TextEditor.Views
{
    /// <summary>
    /// Interaction logic for SignUpControl.xaml
    /// </summary>
    public partial class SignUpControl : UserControl
    {
        public SignUpControl()
        {
            InitializeComponent();
            var signUpViewModel = new SignUpViewModel();
            DataContext = signUpViewModel;
        }
    }
}
