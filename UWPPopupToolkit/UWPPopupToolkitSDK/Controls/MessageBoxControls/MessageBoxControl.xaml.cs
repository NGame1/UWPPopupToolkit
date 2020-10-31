using System;
using System.Reflection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPPopupToolkit.Controls
{
    public sealed partial class MessageBoxControl : UserControl, IDisposable
    {
        public MessageBoxControl(Type PopupContent, params object[] args)
        {
            this.InitializeComponent();
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
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
