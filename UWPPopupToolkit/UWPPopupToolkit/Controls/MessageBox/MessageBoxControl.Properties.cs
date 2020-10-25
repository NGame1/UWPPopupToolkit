using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace UWPPopupToolkit.Sample.Controls.MessageBox
{
    public partial class MessageBoxControl
    {
        public Type ContentType { get; set; }
        public string MessageContent { get; set; } = null;


        public static readonly DependencyProperty MessageContentProperty = DependencyProperty.Register(
         "MessageContent",
         typeof(string),
         typeof(MessageBoxControl),
         new PropertyMetadata(null)
        ); 

        public static readonly DependencyProperty ContentTypeProperty = DependencyProperty.Register(
          "ContentType",
          typeof(Type),
          typeof(MessageBoxControl),
          new PropertyMetadata(null)
         );

    }
}
