using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI.Xaml;

namespace UWPPopupToolkit.Controls.PopupPresenterHostControls
{
    public partial class PopupPresenterHost
    {
        /// <summary>
        /// Id of the host control
        /// </summary>
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
