﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace UWPPopupToolkit.Sample.Controls.SlideupPopup
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
