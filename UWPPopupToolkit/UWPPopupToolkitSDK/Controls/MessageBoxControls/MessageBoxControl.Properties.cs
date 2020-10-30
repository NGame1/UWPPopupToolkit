using System;
using Windows.UI.Xaml;

namespace UWPPopupToolkit.Controls
{
    /// <summary>
    /// All kinds of the supported animations for showing/hiding the popup
    /// </summary>
    public enum MessageBoxAnimationKind
    {
        /// <summary>
        /// Increase the Opacity to 1
        /// </summary>
        FadeIn,
        /// <summary>
        /// Decrease the Opacity to 0
        /// </summary>
        FadeOut,
        /// <summary>
        /// Slides from Bottom of the screen
        /// </summary>
        SlideUp,
        /// <summary>
        /// Slides from the right edge of the screen
        /// </summary>
        SlideRight,
        /// <summary>
        /// Slides from the left edge of the screen
        /// </summary>
        SlideLeft,
        /// <summary>
        /// Slides from top of the screen
        /// </summary>
        SlideBottom,
        /// <summary>
        /// No animation, just show/hide
        /// </summary>
        None
    }
    public partial class MessageBoxControl
    {
        /// <summary>
        /// Type of the activated content in the message box. One of the ContentType and MessageContent must be set otherwise we select one of them by default.
        /// </summary>
        public Type ContentType { get; set; }
        /// <summary>
        /// Text message to be shown in the message box. One of the ContentType and MessageContent must be set otherwise we select one of them by default.
        /// </summary>
        public string MessageContent { get; set; } = null;

        /// <summary>
        /// Title of the Message box
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Animation of showing the message box. Note: do not use fade out for the show animation
        /// </summary>
        public MessageBoxAnimationKind ShowAnimation { get; set; } = MessageBoxAnimationKind.FadeIn;
        /// <summary>
        /// Animation of hiding the message box. Note: do not use fade in for the hide animation
        /// </summary>
        public MessageBoxAnimationKind HideAnimation { get; set; } = MessageBoxAnimationKind.FadeOut;

        public static readonly DependencyProperty ShowAnimationProperty = DependencyProperty.Register(
         "ShowAnimation",
         typeof(MessageBoxAnimationKind),
         typeof(MessageBoxControl),
         new PropertyMetadata(MessageBoxAnimationKind.FadeIn)
        ); 

        public static readonly DependencyProperty HideAnimationProperty = DependencyProperty.Register(
          "HideAnimation",
          typeof(MessageBoxAnimationKind),
          typeof(MessageBoxControl),
          new PropertyMetadata(MessageBoxAnimationKind.FadeOut)
         );

        public static readonly DependencyProperty MessageContentProperty = DependencyProperty.Register(
         "MessageContent",
         typeof(string),
         typeof(MessageBoxControl),
         new PropertyMetadata(null)
        );

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
         "Title",
         typeof(string),
         typeof(MessageBoxControl),
         new PropertyMetadata(string.Empty)
        );

        public static readonly DependencyProperty ContentTypeProperty = DependencyProperty.Register(
          "ContentType",
          typeof(Type),
          typeof(MessageBoxControl),
          new PropertyMetadata(null)
         );

        public Guid Identifier { get; } = Guid.NewGuid();
    }
}
