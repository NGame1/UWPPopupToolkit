﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace UWPPopupToolkit.Sample.Controls.PopupPresenterHost
{
    public partial class PopupPresenterHost
    {
        public string Id
        {
            get
            {
                if (GetValue(IdProperty) is string id)
                    return (string)id;
                else return string.Empty;
            }
            set
            {
                SetValue(IdProperty, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
            }
        }
        public static readonly DependencyProperty IdProperty = DependencyProperty.Register(
         "Id",
         typeof(string),
         typeof(PopupPresenterHost),
         new PropertyMetadata(null)
        );

        public event PropertyChangedEventHandler PropertyChanged;
        static List<PopupPresenterHost> _hosts { get; } = new List<PopupPresenterHost>();
    }
}
