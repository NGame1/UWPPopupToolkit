using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace UWPPopupToolkit.Controls.PopupPresenterHostControls
{
    public partial class PopupPresenterHost
    {
        /// <summary>
        /// This method will shows the message box frame Asynchronously
        /// </summary>
        /// <returns></returns>
        public static async Task<Guid> ShowMessageBoxAsync(string message, Type content = null, string Title = "", string Host_Id = null, params object[] args)
        {
            PopupPresenterHost Host = null;
            if (Host_Id == null)
                Host = _hosts.Any() ? _hosts.FirstOrDefault() : throw new Exception("Mo Hosts found or the host disposed.");
            else Host = _hosts.Any() ? _hosts.First(x => x.Id == Host_Id) : throw new Exception("Mo Hosts found or the host disposed.");
            //if (Host.Children.Any(x => x is PopupControl pop && pop.PopupContentType == content))
            //    if (!OpenNewIfExists)
            //        throw new Exception("An existing popup of this type is currently open.");
            //var p = new MessageBoxControl(content, args) { Title = Title, MessageContent = message, ShowAnimation = ShowAnimationMode, HideAnimation = HideAnimationMode };
            //if (Margin.HasValue) p.ContentMargin = Margin.Value;
            //if (ShowAnimDuration.HasValue) p.ShowAnimationDuration = ShowAnimDuration.Value;
            //if (HideAnimDuration.HasValue) p.HideAnimationDuration = HideAnimDuration.Value;
            //Host.Children.Add(p);
            //await p.ShowPopupAsync();
            return await PopupPresenterHost.ShowSlideupPopupAsync(typeof(MessageBoxControl), Host_Id:Host_Id, args: new object[] { content == null ? message : content, Title, args });
            //return p.Identifier;
        }
    }
}
