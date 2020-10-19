using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPPopupToolkit.Controls.SlideupPopup
{
    public partial class SlideupPopup
    {
        public async Task ShowPopupAsync()
        {
            await ShowPopupStoryboard.BeginAsync();
        }

        public async void ShowPopup()
        {
            await ShowPopupStoryboard.BeginAsync();
        }

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
            _popup = null;
            _isdisposing = false;
            GC.Collect();
        }
    }
}
