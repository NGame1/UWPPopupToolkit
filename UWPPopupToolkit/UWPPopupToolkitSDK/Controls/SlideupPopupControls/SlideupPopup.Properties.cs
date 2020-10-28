using System;
using System.ComponentModel;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace UWPPopupToolkit.Controls.SlideupPopupControls
{
    public partial class SlideupPopup
    {
        /// <summary>
        /// Height of the result popup
        /// </summary>
        public double PopupHeight
        {
            get
            {
                if (GetValue(PopupHeightProperty) is double id)
                    return (double)id;
                else return double.NaN;
            }
            set
            {
                SetValue(PopupHeightProperty, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PopupHeight"));
            }
        }

        /// <summary>
        /// Gets or sets the background color of the popup
        /// </summary>
        public Brush BackgroundColor { get; set; } = new SolidColorBrush(Colors.White);


        public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register(
         "BackgroundColor",
         typeof(Brush),
         typeof(SlideupPopup),
         new PropertyMetadata(null)
        );

        public static readonly DependencyProperty PopupHeightProperty = DependencyProperty.Register(
         "PopupHeight",
         typeof(double),
         typeof(SlideupPopup),
         new PropertyMetadata(double.NaN)
        );

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Unique identifier of the popup that helps in finding and hiding the active popups
        /// </summary>
        public Guid Identifier { get; } = Guid.NewGuid();
        /// <summary>
        /// Duration of the Show / Hide animations. Default value is 300 Milliseconds.
        /// </summary>
        public Duration AnimationDuration { get; set; } = new Duration(TimeSpan.FromMilliseconds(300));
        Point _startPoint;
        bool _isdisposing = false;
        /// <summary>
        /// Type of the activated content in the popup
        /// </summary>
        public Type PopupContentType { get; }
    }
}
