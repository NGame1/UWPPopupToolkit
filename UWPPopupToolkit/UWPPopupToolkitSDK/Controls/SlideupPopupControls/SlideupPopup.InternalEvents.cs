using Microsoft.Toolkit.Uwp.UI.Animations;
using UWPPopupToolkit.Controls.PopupPresenterHostControls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace UWPPopupToolkit.Controls.SlideupPopupControls
{
    public partial class SlideupPopup
    {
        private void _popup_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            _startPoint = e.Position;
        }

        /// <summary>
        /// This method will be handle the slideup popup control up/down maniption for helping user to hide the popup
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Not important</param>
        private void _popup_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var Host = (FrameworkElement)this.Parent;
            var _translatetransform = _popup.RenderTransform as CompositeTransform;
            var enddelta = _translatetransform.TranslateY + e.Delta.Translation.Y;
            if (enddelta >= Host.ActualHeight)
                _translatetransform.TranslateY = Host.ActualHeight;
            else if (double.IsNaN(PopupHeight) && enddelta < 100) _translatetransform.TranslateY = 100;
            else if (enddelta < (Host.ActualHeight - PopupHeight)) _translatetransform.TranslateY = (Host.ActualHeight - PopupHeight);
            else _translatetransform.TranslateY += e.Delta.Translation.Y;
        }

        /// <summary>
        /// This event will complete the manipulation of the user. This will completes hide or reverts the slidedown 
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Not important</param>
        private async void _popup_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            var Host = (FrameworkElement)this.Parent;
            var y = e.Position.Y;
            if (e.Cumulative.Translation.Y > 50)
            {
                (HidePopupStoryboard.Children[0] as DoubleAnimation).To = Host.ActualHeight;
                (HidePopupStoryboard.Children[1] as DoubleAnimation).To = 0;
                await HidePopupStoryboard.BeginAsync();
            }
            else await ShowPopupStoryboard.BeginAsync();
        }

        /// <summary>
        /// Initializing some little things of the animations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var Host = (PopupPresenterHost)this.Parent;
            var da = ShowPopupStoryboard.Children[0] as DoubleAnimation;
            da.From = Host.ActualHeight;
            if (!double.IsNaN(PopupHeight))
            {
                var Padding = Host.ActualHeight - PopupHeight;
                (ShowPopupStoryboard.Children[0] as DoubleAnimation).To = Padding;
                ContentPresentationGrid.Margin = new Thickness(0, 0, 0, Padding);
                da.To = Padding;
            }
            else ContentPresentationGrid.Margin = new Thickness(0, 0, 0, 100);
            da.From = null;
        }

        /// <summary>
        /// This method will tries to dispose the object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Dispose();
            }
            catch { }
        }
    }
}
