using System.ComponentModel;
using System.Windows;

namespace TextEditor.utils
{
    interface ILoaderOwner : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsEnabled { get; set; }
    }
}
