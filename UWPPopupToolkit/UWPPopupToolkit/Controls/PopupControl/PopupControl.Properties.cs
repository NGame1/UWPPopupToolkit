using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace UWPPopupToolkit.Controls.PopupControl
{
    public enum PopupControlAnimationKind
    {
        FadeIn,
        FadeOut,
        SlideUp,
        SlideRight,
        SlideLeft,
        SlideBottom,
        None
    }

    public partial class PopupControl
    {
        public Duration ShowAnimationDuration
        {
            get
            {
                if (GetValue(ShowAnimationDurationProperty) is Duration duration)
                    return (Duration)duration;
                else return new Duration(TimeSpan.FromMilliseconds(300));
            }
            set
            {
                SetValue(ShowAnimationDurationProperty, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ShowAnimationDuration"));
            }
        }

        public PopupControlAnimationKind ShowAnimation
        {
            get
            {
                if (GetValue(ShowAnimationProperty) is PopupControlAnimationKind Anim)
                    return (PopupControlAnimationKind)Anim;
                else return PopupControlAnimationKind.None;
            }
            set
            {
                SetValue(ShowAnimationProperty, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ShowAnimation"));
            }
        }

        public Duration HideAnimationDuration
        {
            get
            {
                if (GetValue(HideAnimationDurationProperty) is Duration duration)
                    return (Duration)duration;
                else return new Duration(TimeSpan.FromMilliseconds(300));
            }
            set
            {
                SetValue(HideAnimationDurationProperty, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HideAnimationDuration"));
            }
        }

        public PopupControlAnimationKind HideAnimation
        {
            get
            {
                if (GetValue(HideAnimationProperty) is PopupControlAnimationKind Anim)
                    return (PopupControlAnimationKind)Anim;
                else return PopupControlAnimationKind.None;
            }
            set
            {
                SetValue(HideAnimationProperty, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HideAnimation"));
            }
        }

        public static readonly DependencyProperty HideAnimationDurationProperty = DependencyProperty.Register(
         "HideAnimationDuration",
         typeof(Duration),
         typeof(PopupControl),
         new PropertyMetadata(new Duration(TimeSpan.FromMilliseconds(300)))
        );

        public static readonly DependencyProperty ShowAnimationDurationProperty = DependencyProperty.Register(
         "ShowAnimationDuration",
         typeof(Duration),
         typeof(PopupControl),
         new PropertyMetadata(new Duration(TimeSpan.FromMilliseconds(300)))
        );

        public static readonly DependencyProperty HideAnimationProperty = DependencyProperty.Register(
         "HideAnimation",
         typeof(PopupControlAnimationKind),
         typeof(PopupControl),
         new PropertyMetadata(PopupControlAnimationKind.None)
        );

        public static readonly DependencyProperty ShowAnimationProperty = DependencyProperty.Register(
         "ShowAnimation",
         typeof(PopupControlAnimationKind),
         typeof(PopupControl),
         new PropertyMetadata(PopupControlAnimationKind.None)
        );

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
