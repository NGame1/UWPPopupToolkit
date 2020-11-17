using System;
using System.Linq;
using System.Threading.Tasks;
using UWPPopupToolkit.Controls.PopupControlControls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace UWPPopupToolkit.Controls.PopupPresenterHostControls
{
    public partial class PopupPresenterHost
    {
        /// <summary>
        /// Shows a simple full screen popup
        /// </summary>
        /// <param name="content">Content you want to be presented inside the popup. Simply use typeof(YourUserControl)</param>
        /// <param name="Host_Id">Id of the control that will host the new popup</param>
        /// <param name="OpenNewIfExists">Allows to open more than one popup with the same content</param>
        /// <param name="ShowAnimationMode">Animation mode of showing the popup</param>
        /// <param name="HideAnimationMode">Animation mode of hiding the popup</param>
        /// <param name="Margin">Content padding from the sides</param>
        /// <param name="ShowAnimDuration">Show animation duration</param>
        /// <param name="HideAnimDuration">Hide animation duration</param>
        /// <param name="args">Arguments needed on the Content ctor</param>
        /// <returns></returns>
        public static Guid ShowPopupControl(Type content, string Host_Id = null, bool OpenNewIfExists = true, PopupControlAnimationKind ShowAnimationMode = PopupControlAnimationKind.FadeIn, PopupControlAnimationKind HideAnimationMode = PopupControlAnimationKind.FadeOut, Thickness? Margin = null, Duration? ShowAnimDuration = null, Duration? HideAnimDuration = null, params object[] args)
        {
            PopupPresenterHost Host = null;

            try
            {
                if (Host_Id == null)
                    Host = _hosts.Any() ? _hosts.FirstOrDefault() : throw new Exception("Mo Hosts found or the host disposed.");
                else Host = _hosts.Any() ? _hosts.First(x => x.Id == Host_Id) : throw new Exception("Mo Hosts found or the host disposed.");
                var testthreadaccess = Host.Id;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("0x8001010E"))
                {
                    foreach (var item in _hosts)
                    {
                        try
                        {
                            if (item.Id is null || item.Id is string str)
                            {
                                if (Host_Id == null)
                                    Host = item;
                                else if (item.Id == Host_Id) Host = item;
                            }
                        }
                        catch { }
                    }
                }
            }
            if (Host.Children.Any(x => x is PopupControl pop && pop.PopupContentType == content))
                if (!OpenNewIfExists)
                    throw new Exception("An existing popup of this type is currently open.");
            var p = new PopupControl(content, args) { ShowAnimation = ShowAnimationMode, HideAnimation = HideAnimationMode };
            if (Margin.HasValue) p.ContentMargin = Margin.Value;
            if (ShowAnimDuration.HasValue) p.ShowAnimationDuration = ShowAnimDuration.Value; 
            if (HideAnimDuration.HasValue) p.HideAnimationDuration = HideAnimDuration.Value;
            Host.Children.Add(p);
            p.ShowPopup();
            return p.Identifier;
        }

        /// <summary>
        /// Shows a simple full screen popup
        /// </summary>
        /// <param name="content">Content you want to be presented inside the popup. Simply use typeof(YourUserControl)</param>
        /// <param name="Host_Id">Id of the control that will host the new popup</param>
        /// <param name="OpenNewIfExists">Allows to open more than one popup with the same content</param>
        /// <param name="ShowAnimationMode">Animation mode of showing the popup</param>
        /// <param name="HideAnimationMode">Animation mode of hiding the popup</param>
        /// <param name="Margin">Content padding from the sides</param>
        /// <param name="ShowAnimDuration">Show animation duration</param>
        /// <param name="HideAnimDuration">Hide animation duration</param>
        /// <param name="args">Arguments needed on the Content ctor</param>
        /// <returns></returns>
        public static async Task<Guid> ShowPopupControlAsync(Type content, string Host_Id = null, bool OpenNewIfExists = true, PopupControlAnimationKind ShowAnimationMode = PopupControlAnimationKind.FadeIn, PopupControlAnimationKind HideAnimationMode = PopupControlAnimationKind.FadeOut, Thickness? Margin = null, Duration? ShowAnimDuration = null, Duration? HideAnimDuration = null, params object[] args)
        {
            PopupPresenterHost Host = null;
            try
            {
                if (Host_Id == null)
                    Host = _hosts.Any() ? _hosts.FirstOrDefault() : throw new Exception("Mo Hosts found or the host disposed.");
                else Host = _hosts.Any() ? _hosts.First(x => x.Id == Host_Id) : throw new Exception("Mo Hosts found or the host disposed.");
                var testthreadaccess = Host.Id;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("0x8001010E"))
                {
                    foreach (var item in _hosts)
                    {
                        try
                        {
                            if (item.Id is null || item.Id is string str)
                            {
                                if (Host_Id == null)
                                    Host = item;
                                else if (item.Id == Host_Id) Host = item;
                            }
                        }
                        catch { }
                    }
                }
            }
            if (Host.Children.Any(x => x is PopupControl pop && pop.PopupContentType == content))
                if (!OpenNewIfExists)
                    throw new Exception("An existing popup of this type is currently open.");
            var p = new PopupControl(content, args) { ShowAnimation = ShowAnimationMode, HideAnimation = HideAnimationMode };
            if (Margin.HasValue) p.ContentMargin = Margin.Value;
            if (ShowAnimDuration.HasValue) p.ShowAnimationDuration = ShowAnimDuration.Value;
            if (HideAnimDuration.HasValue) p.HideAnimationDuration = HideAnimDuration.Value;
            Host.Children.Add(p);
            await p.ShowPopupAsync();
            return p.Identifier;
        }

        /// <summary>
        /// Hides an existing popup
        /// </summary>
        /// <param name="Identifier">Identifier of the slideup popup</param>
        /// <param name="Host_Id">Identifier of the host control</param>
        public static async void HidePopupControl(Guid Identifier, string Host_Id = null)
        {
            PopupPresenterHost Host = null;
            try
            {
                if (Host_Id == null)
                    Host = _hosts.Any() ? _hosts.FirstOrDefault(x => x.Children.Any(y => y.GetType() == typeof(PopupControl) && (y as PopupControl).Identifier == Identifier)) : throw new Exception("Mo Hosts found or the host disposed.");
                else Host = !_hosts.Any() ? throw new Exception("Mo Hosts found or the host disposed.") :
                _hosts.Any(x => x.Id == Host_Id) ? _hosts.First(x => x.Id == Host_Id) : throw new Exception("Mo Hosts found or the host disposed.");
                var testthreadaccess = Host.Id;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("0x8001010E"))
                {
                    foreach (var item in _hosts)
                    {
                        try
                        {
                            if (item.Id is null || item.Id is string str)
                            {
                                if (Host_Id == null && item.Children.Any(y => y.GetType() == typeof(PopupControl) && (y as PopupControl).Identifier == Identifier))
                                    Host = item;
                                else if (item.Id == Host_Id && item.Children.Any(y => y.GetType() == typeof(PopupControl) && (y as PopupControl).Identifier == Identifier)) Host = item;
                            }
                        }
                        catch { }
                    }
                    if (Host == null) throw new Exception("Mo Hosts found or the host disposed.");
                }
            }
            //if (Host_Id == null)
            //    Host = _hosts.Any() ? _hosts.FirstOrDefault(x => x.Children.Any(y => y.GetType() == typeof(PopupControl) && (y as PopupControl).Identifier == Identifier)) : throw new Exception("Mo Hosts found or the host disposed.");
            //else Host = !_hosts.Any() ? throw new Exception("Mo Hosts found or the host disposed.") :
            //_hosts.Any(x => x.Id == Host_Id) ? _hosts.First(x => x.Id == Host_Id) : throw new Exception("Mo Hosts found or the host disposed.");
            if (Host.Children.Any(x => x is PopupControl uc && uc.Identifier == Identifier))
            {
                var uc = (PopupControl)Host.Children.FirstOrDefault(x => x is PopupControl uc && uc.Identifier == Identifier);
                uc.HidePopup();
                await Task.Delay((int)uc.HideAnimationDuration.TimeSpan.TotalMilliseconds);
                uc.Dispose();
                Host.Children.Remove(uc);
            }
        }

        /// <summary>
        /// Hides an existing popup
        /// </summary>
        /// <param name="popupContent">a child or root element of the popup content</param>
        /// <param name="Host_Id">Identifier of the host control</param>
        public static void HidePopupControl(FrameworkElement popupContent, string Host_Id = null)
        {
            var id = PopupControl.GetIdentifier(popupContent);
            HidePopupControl(id, Host_Id);
        }

        /// <summary>
        /// Hides an existing popup
        /// </summary>
        /// <param name="Identifier">Identifier of the slideup popup</param>
        /// <param name="Host_Id">Identifier of the host control</param>
        public static async Task HidePopupControlAsync(Guid Identifier, string Host_Id = null)
        {
            PopupPresenterHost Host = null;
            try
            {
                if (Host_Id == null)
                    Host = _hosts.Any() ? _hosts.FirstOrDefault(x => x.Children.Any(y => y.GetType() == typeof(PopupControl) && (y as PopupControl).Identifier == Identifier)) : throw new Exception("Mo Hosts found or the host disposed.");
                else Host = !_hosts.Any() ? throw new Exception("Mo Hosts found or the host disposed.") :
                _hosts.Any(x => x.Id == Host_Id) ? _hosts.First(x => x.Id == Host_Id) : throw new Exception("Mo Hosts found or the host disposed.");
                var testthreadaccess = Host.Id;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("0x8001010E"))
                {
                    foreach (var item in _hosts)
                    {
                        try
                        {
                            if (item.Id is null || item.Id is string str)
                            {
                                if (Host_Id == null && item.Children.Any(y => y.GetType() == typeof(PopupControl) && (y as PopupControl).Identifier == Identifier))
                                    Host = item;
                                else if (item.Id == Host_Id && item.Children.Any(y => y.GetType() == typeof(PopupControl) && (y as PopupControl).Identifier == Identifier)) Host = item;
                            }
                        }
                        catch { }
                    }
                    if (Host == null) throw new Exception("Mo Hosts found or the host disposed.");
                }
            }
            if (Host.Children.Any(x => x is PopupControl uc && uc.Identifier == Identifier))
            {
                var uc = (PopupControl)Host.Children.FirstOrDefault(x => x is PopupControl uc && uc.Identifier == Identifier);
                await uc.HidePopupAsync();
                Host.Children.Remove(uc);
            }
        }

        /// <summary>
        /// Hides an existing popup
        /// </summary>
        /// <param name="popupContent">a child or root element of the popup content</param>
        /// <param name="Host_Id">Identifier of the host control</param>
        public static async Task HidePopupControlAsync(FrameworkElement popupContent, string Host_Id = null)
        {
            var id = PopupControl.GetIdentifier(popupContent);
            await HidePopupControlAsync(id, Host_Id);
        }

    }
}
