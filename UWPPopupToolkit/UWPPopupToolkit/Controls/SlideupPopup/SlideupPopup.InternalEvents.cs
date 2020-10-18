using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace UWPPopupToolkit.Controls.SlideupPopup
{
    public partial class SlideupPopup
    {
        private void _popup_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            _startPoint = e.Position;
        }

        private void _popup_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var Host = (FrameworkElement)this.Parent;
            var _translatetransform = _popup.RenderTransform as CompositeTransform;
            var enddelta = _translatetransform.TranslateY + e.Delta.Translation.Y;
            if (enddelta >= Host.ActualHeight)
                _translatetransform.TranslateY = Host.ActualHeight;
            else if (enddelta < 0) _translatetransform.TranslateY = 0;
            else _translatetransform.TranslateY += e.Delta.Translation.Y;
        }

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
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var Host = (PopupPresenterHost.PopupPresenterHost)this.Parent;
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
            await ShowPopupStoryboard.BeginAsync();
            da.From = null;
        }

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
