using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPPopupToolkit.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace UWPPopupToolkit.Controls.PopupControl
{
    public partial class PopupControl
    {
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

        public void Dispose()
        {
        }

        public void ShowPopup()
        {
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
                        var fadein = new DoubleAnimation() { Duration = ShowAnimationDuration, From = 1, To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateY)");
                        showsb.Children.Add(fadein);
                        showsb.Begin();
                    }
                    break;
                case PopupControlAnimationKind.SlideRight:
                    break;
                case PopupControlAnimationKind.SlideLeft:
                    break;
                case PopupControlAnimationKind.SlideBottom:
                    break;
                case PopupControlAnimationKind.None:
                    break;
                default:
                    break;
            }
        }

        public void HidePopup()
        {
            var HideSb = new Storyboard() { Duration = HideAnimationDuration };
            switch (HideAnimation)
            {
                case PopupControlAnimationKind.FadeIn:
                    {
                        var fadein = new DoubleAnimation() { Duration = HideAnimationDuration, From = 0, To = 1 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.Opacity)");
                        HideSb.Children.Add(fadein);
                        HideSb.Begin();
                    }
                    break;
                case PopupControlAnimationKind.FadeOut:
                    {
                        var fadein = new DoubleAnimation() { Duration = ShowAnimationDuration, From = 1, To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.Opacity)");
                        HideSb.Children.Add(fadein);
                        HideSb.Begin();
                    }
                    break;
                case PopupControlAnimationKind.SlideUp:
                    {
                        var fadein = new DoubleAnimation() { Duration = ShowAnimationDuration, From = 1, To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateY)");
                        HideSb.Children.Add(fadein);
                        HideSb.Begin();
                    }
                    break;
                case PopupControlAnimationKind.SlideRight:
                    break;
                case PopupControlAnimationKind.SlideLeft:
                    break;
                case PopupControlAnimationKind.SlideBottom:
                    break;
                case PopupControlAnimationKind.None:
                    break;
                default:
                    break;
            }
        }
        public async Task ShowPopupAsync()
        {
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
                        var fadein = new DoubleAnimation() { Duration = ShowAnimationDuration, From = 1, To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateY)");
                        showsb.Children.Add(fadein);
                        await showsb.BeginAsync();
                    }
                    break;
                case PopupControlAnimationKind.SlideRight:
                    break;
                case PopupControlAnimationKind.SlideLeft:
                    break;
                case PopupControlAnimationKind.SlideBottom:
                    break;
                case PopupControlAnimationKind.None:
                    break;
                default:
                    break;
            }
        }

        public async Task HidePopupAsync()
        {
            var HideSb = new Storyboard() { Duration = HideAnimationDuration };
            switch (HideAnimation)
            {
                case PopupControlAnimationKind.FadeIn:
                    {
                        var fadein = new DoubleAnimation() { Duration = HideAnimationDuration, From = 0, To = 1 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.Opacity)");
                        HideSb.Children.Add(fadein);
                        await HideSb.BeginAsync();
                    }
                    break;
                case PopupControlAnimationKind.FadeOut:
                    {
                        var fadein = new DoubleAnimation() { Duration = ShowAnimationDuration, From = 1, To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.Opacity)");
                        HideSb.Children.Add(fadein);
                        await HideSb.BeginAsync();
                    }
                    break;
                case PopupControlAnimationKind.SlideUp:
                    {
                        var fadein = new DoubleAnimation() { Duration = ShowAnimationDuration, From = 1, To = 0 };
                        Storyboard.SetTarget(fadein, _content);
                        Storyboard.SetTargetProperty(fadein, "(UIElement.RenderTransform).(CompositeTransform.TranslateY)");
                        HideSb.Children.Add(fadein);
                        await HideSb.BeginAsync();
                    }
                    break;
                case PopupControlAnimationKind.SlideRight:
                    break;
                case PopupControlAnimationKind.SlideLeft:
                    break;
                case PopupControlAnimationKind.SlideBottom:
                    break;
                case PopupControlAnimationKind.None:
                    break;
                default:
                    break;
            }
        }
    }
}
