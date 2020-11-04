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
        public Brush BackgroundColorBrsh { get; set; } = null;

        /// <summary>
        /// result popup width witch is full width 
        /// </summary>
        public double PopupWidth { get; set; } = double.NaN;

        /// <summary>
        /// Enables / Disables the light dismiss, allows to close popup by tapping out of the popup
        /// </summary>
        public bool LightDismissEnabled { get; set; } = true;

        /// <summary>
        /// Background color of the light dismiss brush
        /// </summary>
        public Color? LightDismissColor{ get; set; } = Color.FromArgb(200, 0, 0, 0);



        public static readonly DependencyProperty LightDismissColorProperty = DependencyProperty.Register(
         "LightDismissColor",
         typeof(Color?),
         typeof(SlideupPopup),
         new PropertyMetadata(null)
        );

        public static readonly DependencyProperty LightDismissEnabledProperty = DependencyProperty.Register(
         "LightDismissEnabled",
         typeof(bool),
         typeof(SlideupPopup),
         new PropertyMetadata(null)
        );

        public static readonly DependencyProperty PopupWidthProperty = DependencyProperty.Register(
         "PopupWidth",
         typeof(double),
         typeof(SlideupPopup),
         new PropertyMetadata(null)
        );

        public static readonly DependencyProperty BackgroundColorBrshProperty = DependencyProperty.Register(
         "BackgroundColorBrsh",
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
        FrameworkElement _uicontent { get; }
        bool outofrangeslide { get; set; }
    }
}
