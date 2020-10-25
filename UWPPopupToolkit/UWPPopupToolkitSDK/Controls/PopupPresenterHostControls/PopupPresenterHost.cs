using System.ComponentModel;
using Windows.UI.Xaml.Controls;

namespace UWPPopupToolkit.Controls.PopupPresenterHostControls
{
    public partial class PopupPresenterHost : Grid, INotifyPropertyChanged
    {
        public PopupPresenterHost()
        {
            _hosts.Add(this);
        }
    }
}
