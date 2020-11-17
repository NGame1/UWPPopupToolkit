using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UWPPopupToolkit.Controls.MessageBoxControls;
using Windows.Security.Authorization.AppCapabilityAccess;
using Windows.System.Threading;
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
            try
            {
                if (Host_Id == null)
                    Host = _hosts.Any() ? _hosts.FirstOrDefault() : null;
                else Host = _hosts.Any() ? _hosts.First(x => x.Id == Host_Id) : null;
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
                await msg.ShowAsync();
                return Guid.Empty;
            }
            return await PopupPresenterHost.ShowSlideupPopupAsync(typeof(MessageBoxControl), Host_Id: Host_Id, args: new object[] { content == null ? message : content, Title, Commands, args });
        }
    }
}
