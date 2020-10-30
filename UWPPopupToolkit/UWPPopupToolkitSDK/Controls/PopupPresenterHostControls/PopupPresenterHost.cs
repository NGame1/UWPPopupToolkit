using System;
using System.ComponentModel;
using System.Linq;
using UWPPopupToolkit.Controls.PopupControlControls;
using UWPPopupToolkit.Controls.SlideupPopupControls;
using Windows.UI.Xaml.Controls;

namespace UWPPopupToolkit.Controls.PopupPresenterHostControls
{
    public partial class PopupPresenterHost : Grid, INotifyPropertyChanged, IDisposable
    {
        public PopupPresenterHost()
        {
            _hosts.Add(this);
        }

        /// <summary>
        /// Dispose the PopupPresenterHost
        /// </summary>
        public async void Dispose()
        {
            foreach (var item in this.Children)
            {
                if (item is SlideupPopup slideup)
                    await HideSlideupPopupAsync(slideup);
                if (item is PopupControl popup)
                    await HidePopupControlAsync(popup);
            }
            Children.Clear();
            _hosts.Remove(this);
        }

    }
}
