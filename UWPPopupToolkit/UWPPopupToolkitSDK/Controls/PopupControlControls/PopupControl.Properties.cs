using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace UWPPopupToolkit.Controls.PopupControlControls
{
    /// <summary>
    /// All kinds of the supported animations for showing/hiding the popup
    /// </summary>
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
        /// <summary>
        /// Unique identifier of the popup that helps in finding and hiding the active popups
        /// </summary>
        public Guid Identifier { get; } = Guid.NewGuid();

        /// <summary>
        /// Type of the activated content in the popup
        /// </summary>
        public Type PopupContentType { get; }

        /// <summary>
        /// Margin of the content from sides of the PopupPresenterHost
        /// </summary>
        public Thickness ContentMargin { get; set; } = new Thickness(0, 0, 0, 0);

        /// <summary>
        /// Duration of showing the popup
        /// </summary>
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

        /// <summary>
        /// Animation of showing the popup. Note: do not use fade out for the show animation
        /// </summary>
        public PopupControlAnimationKind ShowAnimation
        {
            get
            {
                if (GetValue(ShowAnimationProperty) is PopupControlAnimationKind Anim)
                    return (PopupControlAnimationKind)Anim;
                else return PopupControlAnimationKind.FadeIn;
            }
            set
            {
                SetValue(ShowAnimationProperty, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ShowAnimation"));
            }
        }

        /// <summary>
        /// Duration of hiding the popup
        /// </summary>
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

        /// <summary>
        /// Animation of hiding the popup. Note: do not use fade in for the show animation
        /// </summary>
        public PopupControlAnimationKind HideAnimation
        {
            get
            {
                if (GetValue(HideAnimationProperty) is PopupControlAnimationKind Anim)
                    return (PopupControlAnimationKind)Anim;
                else return PopupControlAnimationKind.FadeOut;
            }
            set
            {
                SetValue(HideAnimationProperty, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HideAnimation"));
            }
        }

        public static readonly DependencyProperty ContentMarginProperty = DependencyProperty.Register(
         "ContentMargin",
         typeof(Thickness),
         typeof(PopupControl),
         new PropertyMetadata(new Thickness(0, 0, 0, 0))
        );

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
         new PropertyMetadata(PopupControlAnimationKind.FadeOut)
        );

        public static readonly DependencyProperty ShowAnimationProperty = DependencyProperty.Register(
         "ShowAnimation",
         typeof(PopupControlAnimationKind),
         typeof(PopupControl),
         new PropertyMetadata(PopupControlAnimationKind.FadeIn)
        );

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
