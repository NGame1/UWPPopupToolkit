using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPPopupToolkit.Sample.Controls.MessageBox
{
    public sealed partial class MessageBoxControl : UserControl
    {
        public MessageBoxControl()
        {
            this.InitializeComponent();
            if(ContentType is not null)
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
                }
            }
        }
    }
}
