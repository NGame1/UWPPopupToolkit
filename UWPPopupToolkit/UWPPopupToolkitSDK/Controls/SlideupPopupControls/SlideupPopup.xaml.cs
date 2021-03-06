﻿using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using UWPPopupToolkit.Helpers;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPPopupToolkit.Controls.SlideupPopupControls
{
    public sealed partial class SlideupPopup : UserControl, IDisposable, INotifyPropertyChanged
    {
        /// <summary>
        /// Slideup (e.g. Instagram Share) popup
        /// </summary>
        /// <param name="PopupContent">Content you want to show in the popup</param>
        /// <param name="args">Pass Cunstructor arguments needed for PopupContent.</param>
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
                _uicontent = uicontent;
                if (BackgroundColorBrsh == null)
                {
                    var b = (uicontent.GetPropertyValue("Background")) as Brush;
                    BackgroundColorBrsh = b;
                }
            }
            Window.Current.SizeChanged += Current_SizeChanged;
        }
    }
}
