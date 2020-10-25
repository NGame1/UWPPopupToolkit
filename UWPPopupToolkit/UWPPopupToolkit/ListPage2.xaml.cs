using UWPPopupToolkit.Controls.PopupPresenterHostControls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPPopupToolkit.Sample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListPage2 : Page
    {
        public ListPage2()
        {
            this.InitializeComponent();
            listpage.InitializeComponent();
        }

        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            PopupPresenterHost.HidePopupControl(this);
        }

    }
}
