using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;

namespace UWPPopupToolkit.Controls.SlideupPopup
{
    public partial class SlideupPopup
    {
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
        public static readonly DependencyProperty PopupHeightProperty = DependencyProperty.Register(
         "PopupHeight",
         typeof(double),
         typeof(SlideupPopup),
         new PropertyMetadata(double.NaN)
        );

        public event PropertyChangedEventHandler PropertyChanged;

        public Guid Identifier { get; } = Guid.NewGuid();
        public Duration AnimationDuration { get; set; } = new Duration(TimeSpan.FromMilliseconds(300));
        Point _startPoint;
        bool _isdisposing = false;
        public Type PopupContentType { get; }
    }
}
