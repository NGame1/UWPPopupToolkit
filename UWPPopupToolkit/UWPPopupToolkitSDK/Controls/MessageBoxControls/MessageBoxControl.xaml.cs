using System;
using System.Reflection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPPopupToolkit.Controls
{
    public sealed partial class MessageBoxControl : UserControl
    {
        public MessageBoxControl()
        {
            this.InitializeComponent();
            if (ContentType is not null)
            {
                var content = Activator.CreateInstance(ContentType);
                if (content is not FrameworkElement uicontent)
                {
                    throw new ArgumentException("PopupContent must return a FrameworkElement object.", "PopupContent");
                }
                else
                {
                    var initialize = ContentType.GetMethod("InitializeComponent");
                    initialize.Invoke(uicontent, null);
                    _content.Children.Add(uicontent);
                    _content.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
