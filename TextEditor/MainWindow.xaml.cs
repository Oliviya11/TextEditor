using System.Windows.Controls;
using TextEditor.managers;
using TextEditor.utils;

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
            var navigationModel = new NavigationModel(this);
            NavigationManager.Instance.Initialize(navigationModel);
            if (!AutoLoginManager.Instance.readFromXml())
            {
                navigationModel.Navigate(ModesEnum.LogIn);
            }
        }

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }
    }
}
