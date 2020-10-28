using System;
using System.Linq;
using System.Threading.Tasks;
using UWPPopupToolkit.Controls.SlideupPopupControls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace UWPPopupToolkit.Controls.PopupPresenterHostControls
{
    public partial class PopupPresenterHost
    {
        /// <summary>
        /// Shows a simple slideup popup just like Instagram's popups
        /// </summary>
        /// <param name="content">Content you want to be presented inside the popup. Simply use typeof(YourUserControl)</param>
        /// <param name="ContentHeight">Height of the result popup</param>
        /// <param name="PopupWidth">Width of the result popup</param>
        /// <param name="Host_Id">Id of the control that will host the new popup</param>
        /// <param name="OpenNewIfExists">Allows to open more than one popup with the same content</param>
        /// <param name="BgColor">Background Color of the final popup (default is White)</param>
        /// <param name="args">Arguments needed on the Content ctor</param>
        /// <returns></returns>
        public static async Task<Guid> ShowSlideupPopupAsync(Type content, double ContentHeight = double.NaN, double PopupWidth = double.NaN, string Host_Id = null, bool OpenNewIfExists = true, Brush BgColor = null, params object[] args)
        {
            PopupPresenterHost Host = null;
            if (Host_Id == null)
                Host = _hosts.Any() ? _hosts.FirstOrDefault() : throw new Exception("Mo Hosts found or the host disposed.");
            else Host = _hosts.Any() ? _hosts.First(x => x.Id == Host_Id) : throw new Exception("Mo Hosts found or the host disposed.");
            if (Host.Children.Any(x => x is SlideupPopup slideup && slideup.PopupContentType == content))
                if (!OpenNewIfExists)
                    throw new Exception("An existing popup of this type is currently open.");
            var p = new SlideupPopup(content, args) { PopupHeight = ContentHeight };
            if(BgColor != null) p.BackgroundColor = BgColor;
            if (!double.IsNaN(PopupWidth)) p.PopupWidth = PopupWidth;
            Host.Children.Add(p);
            await p.ShowPopupAsync();
            return p.Identifier;
        }

        /// <summary>
        /// Shows a simple slideup popup just like Instagram's popups
        /// </summary>
        /// <param name="content">Content you want to be presented inside the popup. Simply use typeof(YourUserControl)</param>
        /// <param name="ContentHeight">Height of the result popup. </param>
        /// <param name="PopupWidth">Width of the result popup. </param>
        /// <param name="Host_Id">Id of the control that will host the new popup</param>
        /// <param name="OpenNewIfExists">Allows to open more than one popup with the same content</param>
        /// <param name="BgColor">Background Color of the final popup (default is White)</param>
        /// <param name="args">Arguments needed on the Content ctor</param>
        /// <returns></returns>
        public static Guid ShowSlideupPopup(Type content, double ContentHeight = double.NaN, double PopupWidth = double.NaN, string Host_Id = null, bool OpenNewIfExists = true, Brush BgColor = null, params object[] args)
        {
            PopupPresenterHost Host = null;
            if (Host_Id == null)
                Host = _hosts.Any() ? _hosts.FirstOrDefault() : throw new Exception("Mo Hosts found or the host disposed.");
            else Host = _hosts.Any() ? _hosts.First(x => x.Id == Host_Id) : throw new Exception("Mo Hosts found or the host disposed.");
            if (Host.Children.Any(x => x is SlideupPopup slideup && slideup.PopupContentType == content))
                if (!OpenNewIfExists)
                    throw new Exception("An existing popup of this type is currently open.");
            var p = new SlideupPopup(content, args) { PopupHeight = ContentHeight };
            if (BgColor != null) p.BackgroundColor = BgColor;
            if (!double.IsNaN(PopupWidth)) p.PopupWidth = PopupWidth;
            Host.Children.Add(p);
            p.ShowPopup();
            return p.Identifier;
        }

        /// <summary>
        /// Hides an existing slideup popup
        /// </summary>
        /// <param name="Identifier">Identifier of the slideup popup</param>
        /// <param name="Host_Id">Identifier of the host control</param>
        public static async void HideSlideupPopup(Guid Identifier, string Host_Id = null)
        {
            PopupPresenterHost Host = null;
            if (Host_Id == null)
                Host = _hosts.Any() ? _hosts.FirstOrDefault(x => x.Children.Any(y => y.GetType() == typeof(SlideupPopup) && (y as SlideupPopup).Identifier == Identifier)) : throw new Exception("Mo Hosts found or the host disposed.");
            else Host = !_hosts.Any() ? throw new Exception("Mo Hosts found or the host disposed.") :
            _hosts.Any(x => x.Id == Host_Id) ? _hosts.First(x => x.Id == Host_Id) : throw new Exception("Mo Hosts found or the host disposed.");
            if (Host.Children.Any(x => x is SlideupPopup uc && uc.Identifier == Identifier))
            {
                var uc = (SlideupPopup)Host.Children.FirstOrDefault(x => x is SlideupPopup uc && uc.Identifier == Identifier);
                uc.Dispose();
                await Task.Delay((int)uc.AnimationDuration.TimeSpan.TotalMilliseconds);
                Host.Children.Remove(uc);
            }
        }

        /// <summary>
        /// Hides an existing slideup popup
        /// </summary>
        /// <param name="Identifier">Identifier of the slideup popup</param>
        /// <param name="Host_Id">Identifier of the host control</param>
        public static async Task HideSlideupPopupAsync(Guid Identifier, string Host_Id = null)
        {
            PopupPresenterHost Host = null;
            if (Host_Id == null)
                Host = _hosts.Any() ? _hosts.FirstOrDefault(x => x.Children.Any(y => y.GetType() == typeof(SlideupPopup) && (y as SlideupPopup).Identifier == Identifier)) : throw new Exception("Mo Hosts found or the host disposed.");
            else Host = !_hosts.Any() ? throw new Exception("Mo Hosts found or the host disposed.") :
            _hosts.Any(x => x.Id == Host_Id) ? _hosts.First(x => x.Id == Host_Id) : throw new Exception("Mo Hosts found or the host disposed.");
            if (Host.Children.Any(x => x is SlideupPopup uc && uc.Identifier == Identifier))
            {
                var uc = (SlideupPopup)Host.Children.FirstOrDefault(x => x is SlideupPopup uc && uc.Identifier == Identifier);
                uc.Dispose();
                await Task.Delay((int)uc.AnimationDuration.TimeSpan.TotalMilliseconds);
                Host.Children.Remove(uc);
            }
        }

        /// <summary>
        /// Hides an existing slideup popup
        /// </summary>
        /// <param name="popupContent">a child or root element of the popup content</param>
        /// <param name="Host_Id">Identifier of the host control</param>
        public static void HideSlideupPopup(FrameworkElement popupContent, string Host_Id = null)
        {
            var id = SlideupPopup.GetIdentifier(popupContent);
            HideSlideupPopup(id, Host_Id);
        }

        /// <summary>
        /// Hides an existing slideup popup
        /// </summary>
        /// <param name="popupContent">a child or root element of the popup content</param>
        /// <param name="Host_Id">Identifier of the host control</param>
        public static async Task HideSlideupPopupAsync(FrameworkElement popupContent, string Host_Id = null)
        {
            var id = SlideupPopup.GetIdentifier(popupContent);
            await HideSlideupPopupAsync(id, Host_Id);
        }

    }
}
