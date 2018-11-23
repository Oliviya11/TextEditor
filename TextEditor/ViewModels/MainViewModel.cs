using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TextEditor.managers;
using TextEditor.utils;

namespace TextEditor.ViewModels
{
    class MainViewModel : ILoaderOwner
    {
        private Visibility _visibility = Visibility.Hidden;
        private bool _isEnabled = true;


        public Visibility LoaderVisibility {
            get
            {
                return _visibility;
            }
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabled {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }

        internal void StartApplication(MainWindow window)
        {
            var navigationModel = new NavigationModel(window);
            NavigationManager.Instance.Initialize(navigationModel);
            if (!AutoLoginManager.Instance.readFromXml())
            {
                navigationModel.Navigate(ModesEnum.LogIn);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
