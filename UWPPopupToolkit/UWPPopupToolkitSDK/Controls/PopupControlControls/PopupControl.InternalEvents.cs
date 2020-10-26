using Windows.UI.Xaml;

namespace UWPPopupToolkit.Controls.PopupControlControls
{
    public partial class PopupControl
    {
        /// <summary>
        /// Sets the correct margin for the content
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Not important</param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _content.Margin = ContentMargin;
        }
    }
}
