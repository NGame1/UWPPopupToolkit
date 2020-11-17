using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace UWPPopupToolkit.Controls.MessageBoxControls
{
    /// <summary>
    /// This class will create an instance of a button for the messagebox
    /// </summary>
    public class MessageBoxCommand
    {
        /// <summary>
        /// This will be shown as an Icon at left side of the messagebox button
        /// </summary>
        public string Icon { get; set; } = "";

        /// <summary>
        /// This is a font family for the Icon property. Default value is Segoe MDL2 Assets
        /// </summary>
        public FontFamily IconFont { get; set; } = new FontFamily("Segoe MDL2 Assets");

        /// <summary>
        /// Label/Text of the message box Button
        /// </summary>
        public string Label { get; set; } = "";

        /// <summary>
        /// Font family of the label, Default value is Segoe UI
        /// </summary>
        public FontFamily FontFamily { get; set; } = new FontFamily("Segoe UI");

        /// <summary>
        /// Foreground of the icon and label
        /// </summary>
        public Brush Foreground { get; set; } = null;

        /// <summary>
        /// Background brush of the button
        /// </summary>
        public Brush Background { get; set; } = null;

        /// <summary>
        /// Border brush of the button
        /// </summary>
        public Brush BorderBrush { get; set; }

        /// <summary>
        /// Thickness of the border of the button
        /// </summary>
        public Thickness BorderThickness { get; set; } = new Thickness();

        internal Action _invoke { get; set; }

        /// <summary>
        /// This will be shown as an Icon at left side of the messagebox button
        /// </summary>
        public MessageBoxCommand()
        {
            Background = new SolidColorBrush((Color)Application.Current.Resources["SystemAccentColor"]);
            BorderBrush = new SolidColorBrush((Color)Application.Current.Resources["SystemAccentColor"]);
            Foreground = (SolidColorBrush)Application.Current.Resources["ApplicationForegroundThemeBrush"];
        }

        /// <summary>
        /// This will be shown as an Icon at left side of the messagebox button
        /// </summary>
        /// <param name="label">Label/Text of the message box Button</param>
        /// <param name="invokeFunction">Function to be invoked after tapping on the button</param>
        public MessageBoxCommand(string label, Action invokeFunction = null)
        {
            Background = new SolidColorBrush((Color)Application.Current.Resources["SystemAccentColor"]);
            BorderBrush = new SolidColorBrush((Color)Application.Current.Resources["SystemAccentColor"]);
            Foreground = (SolidColorBrush)Application.Current.Resources["ApplicationForegroundThemeBrush"];
            Label = label;
            _invoke = invokeFunction;
        }
        /// <summary>
        /// This will be shown as an Icon at left side of the messagebox button
        /// </summary>
        /// <param name="label">Label/Text of the message box Button</param>
        /// <param name="icon">This will be shown as an Icon at left side of the messagebox button</param>
        /// <param name="invokeFunction">Function to be invoked after tapping on the button</param>
        public MessageBoxCommand(string label, string icon, Action invokeFunction = null)
        {
            Background = new SolidColorBrush((Color)Application.Current.Resources["SystemAccentColor"]);
            BorderBrush = new SolidColorBrush((Color)Application.Current.Resources["SystemAccentColor"]);
            Foreground = (SolidColorBrush)Application.Current.Resources["ApplicationForegroundThemeBrush"];
            Label = label;
            Icon = icon;
            _invoke = invokeFunction;
        }

        /// <summary>
        /// This will be shown as an Icon at left side of the messagebox button
        /// </summary>
        /// <param name="label">Label/Text of the message box Button</param>
        /// <param name="labelFont">Font family of the label, Default value is Segoe UI</param>
        /// <param name="invokeFunction">Function to be invoked after tapping on the button</param>
        public MessageBoxCommand(string label, FontFamily labelFont, Action invokeFunction = null)
        {
            Background = new SolidColorBrush((Color)Application.Current.Resources["SystemAccentColor"]);
            BorderBrush = new SolidColorBrush((Color)Application.Current.Resources["SystemAccentColor"]);
            Foreground = (SolidColorBrush)Application.Current.Resources["ApplicationForegroundThemeBrush"];
            Label = label;
            FontFamily = labelFont;
            _invoke = invokeFunction;
        }

        /// <summary>
        /// This will be shown as an Icon at left side of the messagebox button
        /// </summary>
        /// <param name="label">Label/Text of the message box Button</param>
        /// <param name="icon">This will be shown as an Icon at left side of the messagebox button</param>
        /// <param name="labelFont">Font family of the label, Default value is Segoe UI</param>
        /// <param name="iconFont">This is a font family for the Icon property. Default value is Segoe MDL2 Assets</param>
        /// <param name="invokeFunction">Function to be invoked after tapping on the button</param>
        public MessageBoxCommand(string label, string icon, FontFamily labelFont, FontFamily iconFont, Action invokeFunction = null)
        {
            Background = new SolidColorBrush((Color)Application.Current.Resources["SystemAccentColor"]);
            BorderBrush = new SolidColorBrush((Color)Application.Current.Resources["SystemAccentColor"]);
            Foreground = (SolidColorBrush)Application.Current.Resources["ApplicationForegroundThemeBrush"];
            Label = label;
            FontFamily = labelFont;
            Icon = icon;
            IconFont = iconFont;
            _invoke = invokeFunction;
        }

    }
}
