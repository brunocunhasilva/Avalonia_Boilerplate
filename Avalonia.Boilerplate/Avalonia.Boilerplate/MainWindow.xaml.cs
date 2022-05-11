using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Avalonia.Boilerplate {
    public class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private int clicksCounter;
        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        private void MyButton_OnClick(object? sender, RoutedEventArgs e)
        {
            // var myButton = (Button)sender;
            // myButton.Content = "My Button was clicked";

            var label = this.FindControl<Label>("MyLabel");
            label.Content = $"Clicks counter: {++clicksCounter}";
        }
    }
}
