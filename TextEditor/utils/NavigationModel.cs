using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.utils
{
    internal enum ModesEnum
    {
        LogIn,
        TextEditor
    }

    internal class NavigationModel
    {
        private LogInControl _loginControl;
        private IContentWindow _contentWindow;
        private TextEditorControl _textEditorControl;

        internal NavigationModel(IContentWindow contentWindow)
        {
            _contentWindow = contentWindow;
        }

        internal void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.LogIn:
                    _contentWindow.ContentControl.Content = _loginControl ?? (_loginControl = new LogInControl());
                    break;
                case ModesEnum.TextEditor:
                    _contentWindow.ContentControl.Content = _textEditorControl ?? (_textEditorControl = new TextEditorControl());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
}
