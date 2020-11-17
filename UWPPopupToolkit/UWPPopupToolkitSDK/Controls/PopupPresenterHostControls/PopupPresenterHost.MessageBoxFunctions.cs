using System;
using System.Linq;
using System.Threading.Tasks;
using UWPPopupToolkit.Controls.MessageBoxControls;
using Windows.UI.Popups;

namespace UWPPopupToolkit.Controls.PopupPresenterHostControls
{
    public partial class PopupPresenterHost
    {
        /// <summary>
        /// This method will shows the message box frame Asynchronously
        /// </summary>
        /// <returns></returns>
        public static async Task<Guid> ShowMessageBoxAsync(string message, Type content = null, string Title = "", string Host_Id = null, MessageBoxCommand[] Commands = null, params object[] args)
        {
            PopupPresenterHost Host = null;
            if (Host_Id == null)
                Host = _hosts.Any() ? _hosts.FirstOrDefault() : throw new Exception("Mo Hosts found or the host disposed.");
            else Host = _hosts.Any() ? _hosts.First(x => x.Id == Host_Id) : throw new Exception("Mo Hosts found or the host disposed.");
            if (Host == null)
            {
                var msg = new MessageDialog(message, Title);
                if (Commands != null && Commands.Any())
                {
                    foreach (var item in Commands)
                    {
                        msg.Commands.Add(new UICommand(item.Label, delegate { item._invoke?.Invoke(); }));
                    }
                }
                return Guid.Empty;
            }
            return await PopupPresenterHost.ShowSlideupPopupAsync(typeof(MessageBoxControl), Host_Id: Host_Id, args: new object[] { content == null ? message : content, Title, Commands, args });
        }
    }
}
