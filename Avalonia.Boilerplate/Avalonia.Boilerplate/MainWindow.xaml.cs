using System;
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
            var topMenu = NativeMenu.GetMenu(this);

            BuildNativeTopMenus(topMenu);

            // var label = this.FindControl<Label>("MyLabel");
            // label.Content = $"Clicks counter: {++clicksCounter}";
        }
        
        private void ForGCCollectButton_OnClick(object? sender, RoutedEventArgs e)
        {
            GC.Collect();
        }
        
        
        public void BuildNativeTopMenus(NativeMenu nativeMenu) {
            if (nativeMenu != null)
            {
                var topMenus = new String[] { "TopMenu1", "TopMenu2" };
                nativeMenu.Items.Clear(); // memory should be cleared when clearing the old menuItems
                foreach (var topMenu in topMenus) {
                    var menuItem = new NativeMenuItem(topMenu);
                    var lotsOfMemory = GetLotsOfMemory();
                    var menu = new NativeMenu();
                    menu.NeedsUpdate += delegate {
                        Console.WriteLine($"Holding to an array with {lotsOfMemory.Length} of length");
                    };
                    menuItem.Menu = menu;
                    nativeMenu.Add(menuItem);
                }
            }
        }

        private const int ArrayLength = 100 * 1024 * 1024;
        private Byte[] GetLotsOfMemory()
        {
            Byte[] lotsOfMemory = new Byte[ArrayLength];
            for (int i = 0; i < ArrayLength; i++) {
                lotsOfMemory[i] = 1;
            }

            return lotsOfMemory;
        }
    }
}
