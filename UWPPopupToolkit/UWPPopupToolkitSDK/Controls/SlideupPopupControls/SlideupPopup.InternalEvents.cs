using Microsoft.Toolkit.Uwp.UI.Animations;
using Microsoft.Toolkit.Uwp.UI.Extensions;
using System.Linq;
using System.Threading.Tasks;
using UWPPopupToolkit.Controls.PopupPresenterHostControls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
            if (sender is FrameworkElement element)
            {
                double ph = 0;
                var wh = Window.Current.Bounds.Height;
                if (double.IsNaN(PopupHeight))
                    ph = 100;
                else ph = wh - PopupHeight;
                if (element.Name == nameof(LightDismissArea) && e.Position.Y > ph)
                    outofrangeslide = true;
                else outofrangeslide = false;
            }
        }

        /// <summary>
        /// This method will be handle the slideup popup control up/down maniption for helping user to hide the popup
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Not important</param>
        private void _popup_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (outofrangeslide) return;
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
            if (outofrangeslide) return;
            var Host = (FrameworkElement)this.Parent;
            if (e.Cumulative.Translation.Y > 50)
            {
                (HidePopupStoryboard.Children[0] as DoubleAnimation).To = Host.ActualHeight;
                (HidePopupStoryboard.Children[1] as DoubleAnimation).To = 0;
                await HidePopupStoryboard.BeginAsync();
                await PopupPresenterHost.HideSlideupPopupAsync(this);
            }
            else await ShowPopupStoryboard.BeginAsync();
        }

        /// <summary>
        /// Hides the popup on tapping outside of the popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LightDismissArea_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var p = e.GetPosition(_popup);
            if (LightDismissEnabled)
                if (p.Y < 0 || p.X < 0 || (!double.IsNaN(PopupWidth) && p.X > PopupWidth))
                    await PopupPresenterHost.HideSlideupPopupAsync(this);
        }

        /// <summary>
        /// Initializing some little things of the animations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var Host = (PopupPresenterHost)this.Parent;
            if (_uicontent is MessageBoxControl message)
            {
                if (message.MessageContent != null)
                {
                    var txts = message.FindChildren<TextBlock>();
                    double sum = 0;
                    sum = txts.Sum(x => x.ActualHeight);
                    sum += message.ButtonsGrid.ActualHeight;
                    sum += 24;
                    if (Host.ActualHeight >= sum + 100)
                        PopupHeight = sum;
                }
            }
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
            if (!double.IsNaN(PopupWidth)) _popup.Width = PopupWidth;
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
