using System;
using System.Numerics;
using System.Reflection;
using UWPPopupToolkit.Controls.PopupPresenterHostControls;
using UWPPopupToolkit.Controls.SlideupPopupControls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPPopupToolkit.Controls
{
    public sealed partial class MessageBoxControl : UserControl, IDisposable
    {
        public MessageBoxControl(string message, string title, params object[] args)
        {
            this.InitializeComponent();
            MessageContent = message;
            Title = title;
        }

        public MessageBoxControl(Type PopupContent, string title, params object[] args)
        {
            this.InitializeComponent();
            Title = title;
            if (PopupContent is not null)
            {
                var content = Activator.CreateInstance(PopupContent);
                if (content is not FrameworkElement uicontent)
                {
                    throw new ArgumentException("PopupContent must return a FrameworkElement object.", "PopupContent");
                }
                else
                {
                    var initialize = PopupContent.GetMethod("InitializeComponent");
                    initialize.Invoke(uicontent, null);
                    _content.Children.Add(uicontent);
                    _content.Visibility = Visibility.Visible;
                    ContentType = PopupContent;
                    _uicontent = uicontent;
                }
            }
        }

        /// <summary>
        /// Dispose the instance and content of the message box
        /// </summary>
        public void Dispose()
        {
            ShowAnimation = MessageBoxAnimationKind.None;
            HideAnimation = MessageBoxAnimationKind.None;
            _root = null;
            _content = null;
            if (_uicontent is IDisposable disposable)
                disposable.Dispose();
            ContentType = null;
            Content = null;
            MessageContent = null;
            GC.Collect();
        }

        private async void ButtonBorder_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var id = SlideupPopup.GetIdentifier(this);
            await PopupPresenterHost.HideSlideupPopupAsync(id);
        }
    }
}
