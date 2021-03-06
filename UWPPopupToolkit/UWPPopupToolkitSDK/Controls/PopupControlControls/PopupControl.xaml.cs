﻿using System;
using System.ComponentModel;
using System.Reflection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPPopupToolkit.Controls.PopupControlControls
{
    public sealed partial class PopupControl : UserControl, IDisposable, INotifyPropertyChanged
    {
        /// <summary>
        /// A simple and free to shape popup control
        /// </summary>
        /// <param name="PopupContent">Content you want to show in the popup</param>
        /// <param name="args">Pass Cunstructor arguments needed for PopupContent.</param>
        public PopupControl(Type PopupContent, params object[] args)
        {
            this.InitializeComponent();
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
                _content.Children.Add(uicontent);
                _uicontent = uicontent;
            }
        }

    }
}
