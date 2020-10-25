using Windows.UI.Xaml;

namespace UWPPopupToolkit.Controls.PopupControlControls
{
    public partial class PopupControl
    {
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _content.Margin = ContentMargin;
        }
    }
}
