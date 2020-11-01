using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Threading.Tasks;
using UWPPopupToolkit.Controls.PopupPresenterHostControls;
using UWPPopupToolkit.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace UWPPopupToolkit.Controls.PopupControlControls
{
    public partial class PopupControl
    {
        /// <summary>
        /// This method will helps to be able to hide popup from the content
        /// </summary>
        /// <param name="control">While you are inside the content page/usercontrol of a popup simply use this keyword.</param>
        /// <returns></returns>
        public static Guid GetIdentifier(FrameworkElement control)
        {
            var parent = control;
            while (parent != null)
            {
                var p = parent.GetPropertyValue("Identifier");
                if (p != null) return (Guid)p;
                else
                {
                    parent = (FrameworkElement)parent.Parent;
                    if (parent == null) return Guid.Empty;
                }
            }
            return Guid.Empty;
            
        }

        /// <summary>
        /// Dispose the object 
        /// </summary>
        public void Dispose()
        {
            if (_uicontent is IDisposable disposable)
                disposable.Dispose();
            _content.Children.Clear();
            GC.Collect();
        }

        /// <summary>
        /// This method will shows the popup frame Syncronosly
        /// </summary>
        /// <returns></returns>
        public void ShowPopup()
        {
            var host = (PopupPresenterHost)Parent;
            var showsb = new Storyboard() { Duration = ShowAnimationDuration };
            switch (ShowAnimation)
            {
                case PopupControlAnimationKind.FadeIn:
                    {
                        var fadein = new DoubleAnimation() { Duration = ShowAnimationDuration, From = 0, To = 1 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.Opacity)");
                        showsb.Children.Add(fadein);
                        showsb.Begin();
                    }
                    break;
                case PopupControlAnimationKind.FadeOut:
                    {
                        var fadein = new DoubleAnimation() { Duration = ShowAnimationDuration, From = 1, To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.Opacity)");
                        showsb.Children.Add(fadein);
                        showsb.Begin();
                    }
                    break;
                case PopupControlAnimationKind.SlideUp:
                    {
                        var fadein = new DoubleAnimation() { Duration = ShowAnimationDuration, From = host.ActualHeight, To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateY)");
                        showsb.Children.Add(fadein);
                        showsb.Begin();
                    }
                    break;
                case PopupControlAnimationKind.SlideRight:
                    {
                        var fadein = new DoubleAnimation() { Duration = ShowAnimationDuration, From = -(host.ActualWidth), To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateX)");
                        showsb.Children.Add(fadein);
                        showsb.Begin();
                    }
                    break;
                case PopupControlAnimationKind.SlideLeft:
                    {
                        var fadein = new DoubleAnimation() { Duration = ShowAnimationDuration, From = host.ActualWidth, To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateX)");
                        showsb.Children.Add(fadein);
                        showsb.Begin();
                    }
                    break;
                case PopupControlAnimationKind.SlideBottom:
                    {
                        var fadein = new DoubleAnimation() { Duration = ShowAnimationDuration, From = -(host.ActualHeight), To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateY)");
                        showsb.Children.Add(fadein);
                        showsb.Begin();
                    }
                    break;
                case PopupControlAnimationKind.None:
                    {
                        var fadein = new DoubleAnimation() { Duration = new Duration(TimeSpan.FromMilliseconds(1)), From = 0, To = 1 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.Opacity)");
                        showsb.Children.Add(fadein);
                        showsb.Begin();
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// This method will shows the popup frame Asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task ShowPopupAsync()
        {
            var host = (PopupPresenterHost)Parent;
            var showsb = new Storyboard() { Duration = ShowAnimationDuration };
            switch (ShowAnimation)
            {
                case PopupControlAnimationKind.FadeIn:
                    {
                        var fadein = new DoubleAnimation() { Duration = ShowAnimationDuration, From = 0, To = 1 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.Opacity)");
                        showsb.Children.Add(fadein);
                        await showsb.BeginAsync();
                    }
                    break;
                case PopupControlAnimationKind.FadeOut:
                    {
                        var fadein = new DoubleAnimation() { Duration = ShowAnimationDuration, From = 1, To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.Opacity)");
                        showsb.Children.Add(fadein);
                        await showsb.BeginAsync();
                    }
                    break;
                case PopupControlAnimationKind.SlideUp:
                    {
                        var fadein = new DoubleAnimation() { Duration = ShowAnimationDuration, From = host.ActualHeight, To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateY)");
                        showsb.Children.Add(fadein);
                        await showsb.BeginAsync();
                    }
                    break;
                case PopupControlAnimationKind.SlideRight:
                    {
                        var fadein = new DoubleAnimation() { Duration = ShowAnimationDuration, From = -(host.ActualWidth), To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateX)");
                        showsb.Children.Add(fadein);
                        await showsb.BeginAsync();
                    }
                    break;
                case PopupControlAnimationKind.SlideLeft:
                    {
                        var fadein = new DoubleAnimation() { Duration = ShowAnimationDuration, From = host.ActualWidth, To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateX)");
                        showsb.Children.Add(fadein);
                        await showsb.BeginAsync();
                    }
                    break;
                case PopupControlAnimationKind.SlideBottom:
                    {
                        var fadein = new DoubleAnimation() { Duration = ShowAnimationDuration, From = -(host.ActualHeight), To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateY)");
                        showsb.Children.Add(fadein);
                        await showsb.BeginAsync();
                    }
                    break;
                case PopupControlAnimationKind.None:
                    {
                        var fadein = new DoubleAnimation() { Duration = new Duration(TimeSpan.FromMilliseconds(1)), From = 0, To = 1 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.Opacity)");
                        showsb.Children.Add(fadein);
                        await showsb.BeginAsync();
                    }
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// This method will hides the popup frame Syncronosly
        /// </summary>
        /// <returns></returns>
        public void HidePopup()
        {
            var host = (PopupPresenterHost)Parent;
            var HideSb = new Storyboard() { Duration = HideAnimationDuration };
            switch (HideAnimation)
            {
                case PopupControlAnimationKind.FadeIn:
                    {
                        var fadein = new DoubleAnimation() { Duration = HideAnimationDuration, To = 1 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.Opacity)");
                        HideSb.Children.Add(fadein);
                        HideSb.Begin();
                    }
                    break;
                case PopupControlAnimationKind.FadeOut:
                    {
                        var fadein = new DoubleAnimation() { Duration = HideAnimationDuration, To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.Opacity)");
                        HideSb.Children.Add(fadein);
                        HideSb.Begin();
                    }
                    break;
                case PopupControlAnimationKind.SlideUp:
                    {
                        var fadein = new DoubleAnimation() { Duration = HideAnimationDuration, To = -(host.ActualHeight) };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateY)");
                        HideSb.Children.Add(fadein);
                        HideSb.Begin();
                    }
                    break;
                case PopupControlAnimationKind.SlideRight:
                    {
                        var fadein = new DoubleAnimation() { Duration = HideAnimationDuration, To = host.ActualWidth };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateX)");
                        HideSb.Children.Add(fadein);
                        HideSb.Begin();
                    }
                    break;
                case PopupControlAnimationKind.SlideLeft:
                    {
                        var fadein = new DoubleAnimation() { Duration = HideAnimationDuration, To = -(host.ActualWidth) };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateX)");
                        HideSb.Children.Add(fadein);
                        HideSb.Begin();
                    }
                    break;
                case PopupControlAnimationKind.SlideBottom:
                    {
                        var fadein = new DoubleAnimation() { Duration = HideAnimationDuration, To = host.ActualHeight };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateY)");
                        HideSb.Children.Add(fadein);
                        HideSb.Begin();
                    }
                    break;
                case PopupControlAnimationKind.None:
                    {
                        var fadein = new DoubleAnimation() { Duration = new Duration(TimeSpan.FromMilliseconds(1)), To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.Opacity)");
                        HideSb.Children.Add(fadein);
                        HideSb.Begin();
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// This method will hides the popup frame Asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task HidePopupAsync()
        {
            var host = (PopupPresenterHost)Parent;
            var HideSb = new Storyboard() { Duration = HideAnimationDuration };
            switch (HideAnimation)
            {
                case PopupControlAnimationKind.FadeIn:
                    {
                        var fadein = new DoubleAnimation() { Duration = HideAnimationDuration, To = 1 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.Opacity)");
                        HideSb.Children.Add(fadein);
                        await HideSb.BeginAsync();
                    }
                    break;
                case PopupControlAnimationKind.FadeOut:
                    {
                        var fadein = new DoubleAnimation() { Duration = HideAnimationDuration, To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.Opacity)");
                        HideSb.Children.Add(fadein);
                        await HideSb.BeginAsync();
                    }
                    break;
                case PopupControlAnimationKind.SlideUp:
                    {
                        var fadein = new DoubleAnimation() { Duration = HideAnimationDuration, To = -(host.ActualHeight) };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateY)");
                        HideSb.Children.Add(fadein);
                        await HideSb.BeginAsync();
                    }
                    break;
                case PopupControlAnimationKind.SlideRight:
                    {
                        var fadein = new DoubleAnimation() { Duration = HideAnimationDuration, To = host.ActualWidth };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateX)");
                        HideSb.Children.Add(fadein);
                        await HideSb.BeginAsync();
                    }
                    break;
                case PopupControlAnimationKind.SlideLeft:
                    {
                        var fadein = new DoubleAnimation() { Duration = HideAnimationDuration, To = -(host.ActualWidth) };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateX)");
                        HideSb.Children.Add(fadein);
                        await HideSb.BeginAsync();
                    }
                    break;
                case PopupControlAnimationKind.SlideBottom:
                    {
                        var fadein = new DoubleAnimation() { Duration = HideAnimationDuration, To = host.ActualHeight };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateY)");
                        HideSb.Children.Add(fadein);
                        await HideSb.BeginAsync();
                    }
                    break;
                case PopupControlAnimationKind.None:
                    {
                        var fadein = new DoubleAnimation() { Duration = new Duration(TimeSpan.FromMilliseconds(1)), To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.Opacity)");
                        HideSb.Children.Add(fadein);
                        await HideSb.BeginAsync();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
