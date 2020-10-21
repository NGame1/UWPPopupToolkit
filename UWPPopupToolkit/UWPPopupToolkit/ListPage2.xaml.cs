using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPPopupToolkit.Controls.PopupControl;
using UWPPopupToolkit.Controls.PopupPresenterHost;
using UWPPopupToolkit.Helpers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPPopupToolkit
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListPage2 : Page
    {
        public ListPage2()
        {
            this.InitializeComponent();
        }

        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            PopupPresenterHost.HidePopupControl(this);
        }
    }
}
