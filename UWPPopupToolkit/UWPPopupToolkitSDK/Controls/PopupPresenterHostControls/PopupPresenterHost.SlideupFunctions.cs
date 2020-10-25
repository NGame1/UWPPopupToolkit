using System;
using System.Linq;
using System.Threading.Tasks;
using UWPPopupToolkit.Controls.SlideupPopupControls;
using Windows.UI.Xaml;

namespace UWPPopupToolkit.Controls.PopupPresenterHostControls
{
    public partial class PopupPresenterHost
    {
        public static async Task<Guid> ShowSlideupPopupAsync(Type content, double ContentHeight = double.NaN, string Host_Id = null, bool OpenNewIfExists = true, params object[] args)
        {
            PopupPresenterHost Host = null;
            if (Host_Id == null)
                Host = _hosts.Any() ? _hosts.FirstOrDefault() : throw new Exception("Mo Hosts found or the host disposed.");
            else Host = _hosts.Any() ? _hosts.First(x => x.Id == Host_Id) : throw new Exception("Mo Hosts found or the host disposed.");
            if (Host.Children.Any(x => x is SlideupPopup slideup && slideup.PopupContentType == content))
                if (!OpenNewIfExists)
                    throw new Exception("An existing popup of this type is currently open.");
            var p = new SlideupPopup(content, args) { PopupHeight = ContentHeight };
            Host.Children.Add(p);
            await p.ShowPopupAsync();
            return p.Identifier;
        }

        public static Guid ShowSlideupPopup(Type content, double ContentHeight = double.NaN, string Host_Id = null, bool OpenNewIfExists = true, params object[] args)
        {
            PopupPresenterHost Host = null;
            if (Host_Id == null)
                Host = _hosts.Any() ? _hosts.FirstOrDefault() : throw new Exception("Mo Hosts found or the host disposed.");
            else Host = _hosts.Any() ? _hosts.First(x => x.Id == Host_Id) : throw new Exception("Mo Hosts found or the host disposed.");
            if (Host.Children.Any(x => x is SlideupPopup slideup && slideup.PopupContentType == content))
                if (!OpenNewIfExists)
                    throw new Exception("An existing popup of this type is currently open.");
            var p = new SlideupPopup(content, args) { PopupHeight = ContentHeight };
            Host.Children.Add(p);
            p.ShowPopup();
            return p.Identifier;
        }

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

        public static void HideSlideupPopup(FrameworkElement popupContent, string Host_Id = null)
        {
            var id = SlideupPopup.GetIdentifier(popupContent);
            HideSlideupPopup(id, Host_Id);
        }

        public static async Task HideSlideupPopupAsync(FrameworkElement popupContent, string Host_Id = null)
        {
            var id = SlideupPopup.GetIdentifier(popupContent);
            await HideSlideupPopupAsync(id, Host_Id);
        }

    }
}
