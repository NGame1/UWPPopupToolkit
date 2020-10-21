using System;
using System.Linq;
using System.Threading.Tasks;
using UWPPopupToolkit.Controls.PopupControl;
using Windows.UI.Xaml;

namespace UWPPopupToolkit.Controls.PopupPresenterHost
{
    public partial class PopupPresenterHost
    {
        public static Guid ShowPopupControl(Type content, string Host_Id = null, bool OpenNewIfExists = true, PopupControlAnimationKind ShowAnimationMode = PopupControlAnimationKind.FadeIn, PopupControlAnimationKind HideAnimationMode = PopupControlAnimationKind.FadeOut, params object[] args)
        {
            PopupPresenterHost Host = null;
            if (Host_Id == null)
                Host = _hosts.Any() ? _hosts.FirstOrDefault() : throw new Exception("Mo Hosts found or the host disposed.");
            else Host = _hosts.Any() ? _hosts.First(x => x.Id == Host_Id) : throw new Exception("Mo Hosts found or the host disposed.");
            if (Host.Children.Any(x => x is PopupControl.PopupControl pop && pop.PopupContentType == content))
                if (!OpenNewIfExists)
                    throw new Exception("An existing popup of this type is currently open.");
            var p = new PopupControl.PopupControl(content, args) { ShowAnimation = ShowAnimationMode, HideAnimation = HideAnimationMode };
            Host.Children.Add(p);
            p.ShowPopup();
            return p.Identifier;
        }

        public static async Task<Guid> ShowPopupControlAsync(Type content, string Host_Id = null, bool OpenNewIfExists = true, PopupControlAnimationKind ShowAnimationMode = PopupControlAnimationKind.FadeIn, PopupControlAnimationKind HideAnimationMode = PopupControlAnimationKind.FadeOut, params object[] args)
        {
            PopupPresenterHost Host = null;
            if (Host_Id == null)
                Host = _hosts.Any() ? _hosts.FirstOrDefault() : throw new Exception("Mo Hosts found or the host disposed.");
            else Host = _hosts.Any() ? _hosts.First(x => x.Id == Host_Id) : throw new Exception("Mo Hosts found or the host disposed.");
            if (Host.Children.Any(x => x is PopupControl.PopupControl pop && pop.PopupContentType == content))
                if (!OpenNewIfExists)
                    throw new Exception("An existing popup of this type is currently open.");
            var p = new PopupControl.PopupControl(content, args) { ShowAnimation = ShowAnimationMode, HideAnimation = HideAnimationMode };
            Host.Children.Add(p);
            await p.ShowPopupAsync();
            return p.Identifier;
        }

        public static async void HidePopupControl(Guid Identifier, string Host_Id = null)
        {
            PopupPresenterHost Host = null;
            if (Host_Id == null)
                Host = _hosts.Any() ? _hosts.FirstOrDefault(x => x.Children.Any(y => y.GetType() == typeof(PopupControl.PopupControl) && (y as PopupControl.PopupControl).Identifier == Identifier)) : throw new Exception("Mo Hosts found or the host disposed.");
            else Host = !_hosts.Any() ? throw new Exception("Mo Hosts found or the host disposed.") :
            _hosts.Any(x => x.Id == Host_Id) ? _hosts.First(x => x.Id == Host_Id) : throw new Exception("Mo Hosts found or the host disposed.");
            if (Host.Children.Any(x => x is PopupControl.PopupControl uc && uc.Identifier == Identifier))
            {
                var uc = (PopupControl.PopupControl)Host.Children.FirstOrDefault(x => x is PopupControl.PopupControl uc && uc.Identifier == Identifier);
                uc.HidePopup();
                await Task.Delay((int)uc.HideAnimationDuration.TimeSpan.TotalMilliseconds);
                uc.Dispose();
                Host.Children.Remove(uc);
            }
        }

        public static void HidePopupControl(FrameworkElement popupContent, string Host_Id = null)
        {
            var id = PopupControl.PopupControl.GetIdentifier(popupContent);
            HidePopupControl(id, Host_Id);
        }

        public static async Task HidePopupControlAsync(Guid Identifier, string Host_Id = null)
        {
            PopupPresenterHost Host = null;
            if (Host_Id == null)
                Host = _hosts.Any() ? _hosts.FirstOrDefault(x => x.Children.Any(y => y.GetType() == typeof(PopupControl.PopupControl) && (y as PopupControl.PopupControl).Identifier == Identifier)) : throw new Exception("Mo Hosts found or the host disposed.");
            else Host = !_hosts.Any() ? throw new Exception("Mo Hosts found or the host disposed.") :
            _hosts.Any(x => x.Id == Host_Id) ? _hosts.First(x => x.Id == Host_Id) : throw new Exception("Mo Hosts found or the host disposed.");
            if (Host.Children.Any(x => x is PopupControl.PopupControl uc && uc.Identifier == Identifier))
            {
                var uc = (PopupControl.PopupControl)Host.Children.FirstOrDefault(x => x is PopupControl.PopupControl uc && uc.Identifier == Identifier);
                await uc.HidePopupAsync();
                Host.Children.Remove(uc);
            }
        }

        public static async Task HidePopupControlAsync(FrameworkElement popupContent, string Host_Id = null)
        {
            var id = PopupControl.PopupControl.GetIdentifier(popupContent);
            await HidePopupControlAsync(id, Host_Id);
        }

    }
}
