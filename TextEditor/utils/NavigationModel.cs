using System;
using TextEditor.Views;

namespace TextEditor.utils
{
    internal enum ModesEnum
    {
        LogIn,
        SignUp,
        TextEditor
    }

    internal class NavigationModel
    {
        private LogInControl _loginControl;
        private IContentWindow _contentWindow;
        private TextEditorControl _textEditorControl;
        private SignUpControl _signUpControl;

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
                case ModesEnum.SignUp:
                    _contentWindow.ContentControl.Content = _signUpControl ?? (_signUpControl = new SignUpControl());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
}
