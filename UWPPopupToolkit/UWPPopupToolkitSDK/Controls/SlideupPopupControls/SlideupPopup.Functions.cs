using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Threading.Tasks;
using UWPPopupToolkit.Helpers;
using Windows.UI.Xaml;

namespace UWPPopupToolkit.Controls.SlideupPopupControls
{
    public partial class SlideupPopup
    {
        /// <summary>
        /// This method will pops up the popup frame Asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task ShowPopupAsync()
        {
            await ShowPopupStoryboard.BeginAsync();
        }

        /// <summary>
        /// This method will pops up the popup frame Syncronosly
        /// </summary>
        public async void ShowPopup()
        {
            await ShowPopupStoryboard.BeginAsync();
        }

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
                if (p != null && parent is SlideupPopup) return (Guid)p;
                else
                {
                    parent = (FrameworkElement)parent.Parent;
                    if (parent == null) return Guid.Empty;
                }
            }
            return Guid.Empty;

        }

        /// <summary>
        /// Hides and dispose the popup and the content inside
        /// </summary>
        public async void Dispose()
        {
            if (_isdisposing || HidePopupStoryboard == null) return;
            _isdisposing = true;
            await HidePopupStoryboard.BeginAsync();
            HidePopupStoryboard.Stop();
            HidePopupStoryboard.Children.Clear();
            HidePopupStoryboard = null;
            ShowPopupStoryboard.Stop();
            ShowPopupStoryboard.Children.Clear();
            ShowPopupStoryboard = null;
            _contentgr.Children.Clear();
            _contentgr = null;
            _popup.Children.Clear();
            if (_uicontent is IDisposable disposable)
                disposable.Dispose();
            BackgroundColorBrsh = null;
            LightDismissColor = null;
            ContentPresentationGrid = null;
            _translatetransform = null;
            _popup = null;
            _isdisposing = false;
            GC.Collect();
        }
    }
}
