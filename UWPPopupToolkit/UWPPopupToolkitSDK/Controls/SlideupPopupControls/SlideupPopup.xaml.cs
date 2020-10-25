using System;
using System.ComponentModel;
using System.Reflection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPPopupToolkit.Controls.SlideupPopupControls
{
    public sealed partial class SlideupPopup : UserControl, IDisposable, INotifyPropertyChanged
    {
        public SlideupPopup(Type PopupContent, params object[] args)
        {
            this.InitializeComponent();
            PopupContentType = PopupContent;
            if (PopupContent is null) throw new ArgumentNullException("PopupContent", "PopupContent Can't be null.");
            var content = Activator.CreateInstance(PopupContent, args);
            if (content is not FrameworkElement uicontent)
            {
                throw new ArgumentException("PopupContent must return a FrameworkElement object.", "PopupContent");
            }
            else
            {
                var initialize = PopupContent.GetMethod("InitializeComponent");
                initialize.Invoke(uicontent, null);
                ContentPresentationGrid.Children.Add(uicontent);
            }
        }

    }
}
