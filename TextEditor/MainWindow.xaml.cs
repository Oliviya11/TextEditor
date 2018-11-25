using DBModels;
using System.Windows.Controls;
using TextEditor.managers;
using TextEditor.utils;
using TextEditor.ViewModels;

/*
 * Class MainWindow was made similar to MainWindow from:
 * https://github.com/appleVovan/KMA.APZRPMJ2018.WalletSimulator
 */
namespace TextEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IContentWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
            mainViewModel.StartApplication(this);
        }

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }
    }
}
