using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace UWPPopupToolkit.Controls
{
    public partial class MessageBoxControl
    {
        /// <summary>
        /// This method will pops up the message box frame Asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task ShowPopupAsync()
        {
            var ShowAnimationDuration = new Duration(TimeSpan.FromMilliseconds(300));
            var storyboard = new Storyboard() { Duration = ShowAnimationDuration };
            var da = new DoubleAnimation() { Duration = ShowAnimationDuration };
            switch (ShowAnimation)
            {
                case MessageBoxAnimationKind.FadeIn:
                    {
                        Storyboard.SetTarget(da, _root);
                        da.To = 1;
                        Storyboard.SetTargetProperty(da, "(UIElement.Opacity)");
                        storyboard.Children.Add(da);
                        await storyboard.BeginAsync();
                    }
                    break;
                case MessageBoxAnimationKind.FadeOut:
                    {
                        Storyboard.SetTarget(da, _root);
                        da.To = 0;
                        Storyboard.SetTargetProperty(da, "(UIElement.Opacity)");
                        storyboard.Children.Add(da);
                        await storyboard.BeginAsync();
                    }
                    break;
                case MessageBoxAnimationKind.SlideUp:
                    break;
                case MessageBoxAnimationKind.SlideRight:
                    break;
                case MessageBoxAnimationKind.SlideLeft:
                    break;
                case MessageBoxAnimationKind.SlideBottom:
                    break;
                case MessageBoxAnimationKind.None:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// This method will pops up the message box Syncronosly
        /// </summary>
        /// <returns></returns>
        public void ShowPopup()
        {
            var ShowAnimationDuration = new Duration(TimeSpan.FromMilliseconds(300));
            var storyboard = new Storyboard() { Duration = ShowAnimationDuration };
            var da = new DoubleAnimation() { Duration = ShowAnimationDuration };
            switch (ShowAnimation)
            {
                case MessageBoxAnimationKind.FadeIn:
                    {
                        Storyboard.SetTarget(da, _root);
                        da.To = 1;
                        Storyboard.SetTargetProperty(da, "(UIElement.Opacity)");
                        storyboard.Children.Add(da);
                        storyboard.Begin();
                    }
                    break;
                case MessageBoxAnimationKind.FadeOut:
                    {
                        Storyboard.SetTarget(da, _root);
                        da.To = 0;
                        Storyboard.SetTargetProperty(da, "(UIElement.Opacity)");
                        storyboard.Children.Add(da);
                        storyboard.Begin();
                    }
                    break;
                case MessageBoxAnimationKind.SlideUp:
                    break;
                case MessageBoxAnimationKind.SlideRight:
                    break;
                case MessageBoxAnimationKind.SlideLeft:
                    break;
                case MessageBoxAnimationKind.SlideBottom:
                    break;
                case MessageBoxAnimationKind.None:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// This method will hides the message box Syncronosly
        /// </summary>
        public void HidePopup()
        {

        }

        /// <summary>
        /// This method will hides the message box Syncronosly
        /// </summary>
        public void HidePopupAsync()
        {

        }
    }
}
