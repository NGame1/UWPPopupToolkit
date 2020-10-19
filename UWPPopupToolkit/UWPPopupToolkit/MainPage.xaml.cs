using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPPopupToolkit.Controls.PopupPresenterHost;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPPopupToolkit
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ShowSlideupPopupNormalSize(object sender, RoutedEventArgs e)
        {
            var g = PopupPresenterHost.ShowSlideupPopup(typeof(ListPage));
        }

        private void ShowSlideupPopupHeight200(object sender, RoutedEventArgs e)
        {
            var g = PopupPresenterHost.ShowSlideupPopup(typeof(ListPage), 300);
        }

        private async void ShowSlideupPopupNormalSizeAsync(object sender, RoutedEventArgs e)
        {
            var g = await PopupPresenterHost.ShowSlideupPopupAsync(typeof(ListPage));
            await new MessageDialog(g.ToString()).ShowAsync();
        }

        private async void ShowSlideupPopupHeight200Async(object sender, RoutedEventArgs e)
        {
            var g = await PopupPresenterHost.ShowSlideupPopupAsync(typeof(ListPage), 300);
            await new MessageDialog(g.ToString()).ShowAsync();
        }
    }
}
