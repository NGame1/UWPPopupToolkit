using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPPopupToolkit.Controls.PopupPresenterHost
{
    public partial class PopupPresenterHost : Grid, INotifyPropertyChanged
    {
        public PopupPresenterHost()
        {
            _hosts.Add(this);
        }
    }
}
