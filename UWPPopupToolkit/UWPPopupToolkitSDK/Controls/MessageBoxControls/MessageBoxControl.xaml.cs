using System;
using System.Reflection;
using UWPPopupToolkit.Controls.MessageBoxControls;
using UWPPopupToolkit.Controls.PopupPresenterHostControls;
using UWPPopupToolkit.Controls.SlideupPopupControls;
using UWPPopupToolkit.Helpers;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPPopupToolkit.Controls
{
    public sealed partial class MessageBoxControl : UserControl, IDisposable
    {
        public MessageBoxControl(string message, string title, MessageBoxCommand[] commands, params object[] args)
        {
            this.InitializeComponent();
            MessageContent = message;
            Title = title;
            if(commands == null || commands.Length == 0)
            {
                var brd = new Border() { Background = new SolidColorBrush((Color)Resources["SystemAccentColor"]), Height = 45, HorizontalAlignment = HorizontalAlignment.Stretch, CornerRadius = new CornerRadius(20) };
                var txt = new TextBlock() { FontSize = 18, FontWeight = FontWeights.SemiBold, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center };
                txt.Inlines.Add(new Run() { Text = "OK" });
                brd.Child = txt;
                brd.Tapped += Brd_Tapped;
                ButtonsGrid.Children.Add(brd);
                return;
            }
            if (commands.Length == 1)
            {
                var brd = new Border() { BorderBrush = commands[0].BorderBrush, Background = commands[0].Background, BorderThickness = commands[0].BorderThickness, Height = 45, HorizontalAlignment = HorizontalAlignment.Stretch, CornerRadius = new CornerRadius(20) };
                var txt = new TextBlock() { FontSize = 18, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center };
                txt.Inlines.Add(new Run() { FontFamily = commands[0].IconFont, Text = commands[0].Icon });
                txt.Inlines.Add(new Run() { FontFamily = commands[0].FontFamily, Text = commands[0].Label, FontWeight = FontWeights.SemiBold });
                brd.Child = txt;
                brd.DataContext = commands[0];
                brd.Tapped += Brd_Tapped;
                ButtonsGrid.Children.Add(brd);
                return;
            }
            if (commands.Length == 2)
            {
                ButtonsGrid.ColumnDefinitions.Add(new ColumnDefinition());
                ButtonsGrid.ColumnDefinitions.Add(new ColumnDefinition());

                var brd = new Border() { Margin = new Thickness(10,0,10,0), BorderBrush = commands[0].BorderBrush, Background = commands[0].Background, BorderThickness = commands[0].BorderThickness, Height = 45, HorizontalAlignment = HorizontalAlignment.Stretch, CornerRadius = new CornerRadius(20) };
                var txt = new TextBlock() { FontSize = 18, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center };
                txt.Inlines.Add(new Run() { FontFamily = commands[0].IconFont, Text = commands[0].Icon });
                txt.Inlines.Add(new Run() { FontFamily = commands[0].FontFamily, Text = commands[0].Label, FontWeight = FontWeights.SemiBold });
                brd.Child = txt;
                Grid.SetColumn(brd, 0);
                brd.DataContext = commands[0];
                brd.Tapped += Brd_Tapped;
                ButtonsGrid.Children.Add(brd);

                var brd2 = new Border() { Margin = new Thickness(10, 0, 10, 0), BorderBrush = commands[1].BorderBrush, Background = commands[1].Background, BorderThickness = commands[1].BorderThickness, Height = 45, HorizontalAlignment = HorizontalAlignment.Stretch, CornerRadius = new CornerRadius(20) };
                var txt2 = new TextBlock() { FontSize = 18, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center };
                txt2.Inlines.Add(new Run() { FontFamily = commands[1].IconFont, Text = commands[1].Icon });
                txt2.Inlines.Add(new Run() { FontFamily = commands[1].FontFamily, Text = commands[1].Label, FontWeight = FontWeights.SemiBold });
                brd2.Child = txt2;
                Grid.SetColumn(brd2, 1);
                brd2.DataContext = commands[1];
                brd2.Tapped += Brd_Tapped;
                ButtonsGrid.Children.Add(brd2);
                return;
            }
            for (int i = 0; i < commands.Length; i++)
            {
                ButtonsGrid.RowDefinitions.Add(new RowDefinition());
                var brd = new Border() { Margin = new Thickness(10, 5, 10, 5), BorderBrush = commands[i].BorderBrush, Background = commands[i].Background, BorderThickness = commands[i].BorderThickness, Height = 45, HorizontalAlignment = HorizontalAlignment.Stretch, CornerRadius = new CornerRadius(20) };
                var txt = new TextBlock() { FontSize = 18, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center };
                txt.Inlines.Add(new Run() { FontFamily = commands[i].IconFont, Text = commands[i].Icon });
                txt.Inlines.Add(new Run() { FontFamily = commands[i].FontFamily, Text = commands[i].Label, FontWeight = FontWeights.SemiBold });
                brd.Child = txt;
                Grid.SetRow(brd, i);
                brd.DataContext = commands[i];
                brd.Tapped += Brd_Tapped;
                ButtonsGrid.Children.Add(brd);
            }
        }

        public MessageBoxControl(Type PopupContent, string title, MessageBoxCommand[] commands, params object[] args)
        {
            this.InitializeComponent();
            Title = title;
            if (PopupContent is not null)
            {
                var content = Activator.CreateInstance(PopupContent, args);
                if (content is not FrameworkElement uicontent)
                {
                    throw new ArgumentException("PopupContent must return a FrameworkElement object.", "PopupContent");
                }
                else
                {
                    var initialize = PopupContent.GetMethod("InitializeComponent");
                    initialize.Invoke(uicontent, null);
                    _content.Children.Add(uicontent);
                    _content.Visibility = Visibility.Visible;
                    ContentType = PopupContent;
                    _uicontent = uicontent;
                }
            }

            if (commands == null || commands.Length == 0)
            {
                var brd = new Border() { Background = new SolidColorBrush((Color)Resources["SystemAccentColor"]), Height = 45, HorizontalAlignment = HorizontalAlignment.Stretch, CornerRadius = new CornerRadius(20) };
                var txt = new TextBlock() { FontSize = 18, FontWeight = FontWeights.SemiBold, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center };
                txt.Inlines.Add(new Run() { Text = "OK" });
                brd.Child = txt;
                brd.Tapped += Brd_Tapped;
                ButtonsGrid.Children.Add(brd);
                return;
            }
            if (commands.Length == 1)
            {
                var brd = new Border() { BorderBrush = commands[0].BorderBrush, Background = commands[0].Background, BorderThickness = commands[0].BorderThickness, Height = 45, HorizontalAlignment = HorizontalAlignment.Stretch, CornerRadius = new CornerRadius(20) };
                var txt = new TextBlock() { FontSize = 18, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center };
                txt.Inlines.Add(new Run() { FontFamily = commands[0].IconFont, Text = commands[0].Icon });
                txt.Inlines.Add(new Run() { FontFamily = commands[0].FontFamily, Text = commands[0].Label, FontWeight = FontWeights.SemiBold });
                brd.Child = txt;
                brd.DataContext = commands[0];
                brd.Tapped += Brd_Tapped;
                ButtonsGrid.Children.Add(brd);
                return;
            }
            if (commands.Length == 2)
            {
                ButtonsGrid.ColumnDefinitions.Add(new ColumnDefinition());
                ButtonsGrid.ColumnDefinitions.Add(new ColumnDefinition());

                var brd = new Border() { Margin = new Thickness(10, 0, 10, 0), BorderBrush = commands[0].BorderBrush, Background = commands[0].Background, BorderThickness = commands[0].BorderThickness, Height = 45, HorizontalAlignment = HorizontalAlignment.Stretch, CornerRadius = new CornerRadius(20) };
                var txt = new TextBlock() { FontSize = 18, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center };
                txt.Inlines.Add(new Run() { FontFamily = commands[0].IconFont, Text = commands[0].Icon });
                txt.Inlines.Add(new Run() { FontFamily = commands[0].FontFamily, Text = commands[0].Label, FontWeight = FontWeights.SemiBold });
                brd.Child = txt;
                Grid.SetColumn(brd, 0);
                brd.DataContext = commands[0];
                brd.Tapped += Brd_Tapped;
                ButtonsGrid.Children.Add(brd);

                var brd2 = new Border() { Margin = new Thickness(10, 0, 10, 0), BorderBrush = commands[1].BorderBrush, Background = commands[1].Background, BorderThickness = commands[1].BorderThickness, Height = 45, HorizontalAlignment = HorizontalAlignment.Stretch, CornerRadius = new CornerRadius(20) };
                var txt2 = new TextBlock() { FontSize = 18, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center };
                txt2.Inlines.Add(new Run() { FontFamily = commands[1].IconFont, Text = commands[1].Icon });
                txt2.Inlines.Add(new Run() { FontFamily = commands[1].FontFamily, Text = commands[1].Label, FontWeight = FontWeights.SemiBold });
                brd2.Child = txt2;
                Grid.SetColumn(brd2, 1);
                brd2.DataContext = commands[1];
                brd2.Tapped += Brd_Tapped;
                ButtonsGrid.Children.Add(brd2);
                return;
            }
            for (int i = 0; i < commands.Length; i++)
            {
                ButtonsGrid.RowDefinitions.Add(new RowDefinition());
                var brd = new Border() { Margin = new Thickness(10, 5, 10, 5), BorderBrush = commands[i].BorderBrush, Background = commands[i].Background, BorderThickness = commands[i].BorderThickness, Height = 45, HorizontalAlignment = HorizontalAlignment.Stretch, CornerRadius = new CornerRadius(20) };
                var txt = new TextBlock() { FontSize = 18, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center };
                txt.Inlines.Add(new Run() { FontFamily = commands[i].IconFont, Text = commands[i].Icon });
                txt.Inlines.Add(new Run() { FontFamily = commands[i].FontFamily, Text = commands[i].Label, FontWeight = FontWeights.SemiBold });
                brd.Child = txt;
                Grid.SetRow(brd, i);
                brd.DataContext = commands[i];
                brd.Tapped += Brd_Tapped;
                ButtonsGrid.Children.Add(brd);
            }
        }
        
        private async void Brd_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await PopupPresenterHost.HideSlideupPopupAsync(this);
            var dt = (MessageBoxCommand)sender.GetPropertyValue("DataContext");
            dt?._invoke?.Invoke();
        }
        /// <summary>
        /// Dispose the instance and content of the message box
        /// </summary>
        public void Dispose()
        {
            ShowAnimation = MessageBoxAnimationKind.None;
            HideAnimation = MessageBoxAnimationKind.None;
            _root = null;
            _content = null;
            if (_uicontent is IDisposable disposable)
                disposable.Dispose();
            ContentType = null;
            Content = null;
            MessageContent = null;
            GC.Collect();
        }

        private async void ButtonBorder_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var id = SlideupPopup.GetIdentifier(this);
            await PopupPresenterHost.HideSlideupPopupAsync(id);
        }
    }
}
