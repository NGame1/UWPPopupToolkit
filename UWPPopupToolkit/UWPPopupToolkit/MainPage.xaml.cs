using System;
using System.Threading.Tasks;
using UWPPopupToolkit.Controls.MessageBoxControls;
using UWPPopupToolkit.Controls.PopupControlControls;
using UWPPopupToolkit.Controls.PopupPresenterHostControls;
using UWPPopupToolkit.Helpers;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPPopupToolkit.Sample
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

        private async void ShowPopupControl(object sender, RoutedEventArgs e)
        {
            var g = PopupPresenterHost.ShowPopupControl(typeof(ListPage2));
            await Task.Delay(1000);
            PopupPresenterHost.HidePopupControl(g);
        }

        private async void ShowPopupControlAsync(object sender, RoutedEventArgs e)
        {
            var g = await PopupPresenterHost.ShowPopupControlAsync(typeof(ListPage2));
            PopupPresenterHost.HidePopupControl(g);
        }

        private void ShowPopupControlCustomClose(object sender, RoutedEventArgs e)
        {
            var g = PopupPresenterHost.ShowPopupControl(typeof(ListPage2));
        }

        private async void ShowPopupControlAnimation(object sender, RoutedEventArgs e)
        {
            var g = await PopupPresenterHost.ShowPopupControlAsync(typeof(ListPage2),
                ShowAnimationMode: PopupControlAnimationKind.SlideUp, HideAnimationMode: PopupControlAnimationKind.SlideUp);
            await PopupPresenterHost.HidePopupControlAsync(g);
        }

        private async void ShowShortTextMessageBox(object sender, RoutedEventArgs e)
        {
            await PopupPresenterHost.ShowMessageBoxAsync("This is a short message text sample.", Title: "Test Title");
        }

        private async void ShowLongTextMessageBox(object sender, RoutedEventArgs e)
        {
            var msg = await FileIO.ReadTextAsync(await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///DemoContent/LoremIpsum.txt", UriKind.RelativeOrAbsolute)));
            await PopupPresenterHost.ShowMessageBoxAsync(msg, Title: "Lorem Ipsum");
        }

        private async void SampleDeleteMessageBox(object sender, RoutedEventArgs e)
        {
            await PopupPresenterHost.ShowMessageBoxAsync("Are you sure you want to delete?", Title: "Delete File?",
                Commands: new MessageBoxCommand[] {
                    new MessageBoxCommand("Delete", "\uE74D",async ()=>{ await new MessageDialog("Success message.").ShowAsync(); }) { Background = new SolidColorBrush(Colors.Red), BorderBrush = new SolidColorBrush(Colors.Red), Foreground = new SolidColorBrush(Colors.White) },
                    new MessageBoxCommand("Cancel", "\uE10A") { Foreground = new SolidColorBrush(Colors.White) }
                });
        }

        private async void SampleCopyFileMessageBox(object sender, RoutedEventArgs e)
        {
            await PopupPresenterHost.ShowMessageBoxAsync("Another file with the same name found, How to continue?", Title: "Copy failure",
                Commands: new MessageBoxCommand[] {
                    new MessageBoxCommand("Rename file", "\uE13E",async ()=>{ await new MessageDialog("File renamed and copied.").ShowAsync(); }) { Background = new SolidColorBrush(Colors.Red), BorderBrush = new SolidColorBrush(Colors.Red), Foreground = new SolidColorBrush(Colors.White) },
                    new MessageBoxCommand("Replace", "\uE19C", async ()=>{ await new MessageDialog("File replaced.").ShowAsync(); }) { Foreground = new SolidColorBrush(Colors.White) },
                    new MessageBoxCommand("Cancel", "\uE10A")
                });
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (CoreApplication.Views.Count > 1) return;
            var view = CoreApplication.CreateNewView();
            int id = 0;
            await view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var frame = new Frame();
                frame.Navigate(typeof(MainPage));
                var pph = new PopupPresenterHost();
                pph.Children.Add(frame);
                pph.Id = Guid.NewGuid().ToString();
                pph.Tag = pph.Id;
                Window.Current.Content = pph;
                var nav = SystemNavigationManager.GetForCurrentView();
                nav.BackRequested += (sfb, sfe) => { if (frame.CanGoBack) frame.GoBack(); sfe.Handled = true; };
                frame.Navigated += (sf1, sf2) =>
                {
                    if (frame.CanGoBack)
                        nav.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
                    else nav.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
                };
                view.CoreWindow.KeyDown += (s1, e1) =>
                {
                    if (e1.VirtualKey == Windows.System.VirtualKey.Escape)
                    {
                        if (frame.CanGoBack)
                            frame.GoBack();
                    }
                    e1.Handled = true;
                };
                Window.Current.Activate();
                id = ApplicationView.GetForCurrentView().Id;
            });
            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(id);
        }
    }
}
