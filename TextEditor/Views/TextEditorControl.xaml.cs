using System.Windows.Controls;
using TextEditor.ViewModels;

namespace TextEditor
{
    /// <summary>
    /// Логика взаимодействия для TextEditorControl.xaml
    /// </summary>
    public partial class TextEditorControl : UserControl
    {
        public TextEditorControl()
        {
            InitializeComponent();
            var textEditorViewModel = new TextEditorViewModel();
            DataContext = textEditorViewModel;
        }
    }
}
