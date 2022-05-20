using Microsoft.UI.Xaml;

namespace WinUIMVVMGrid {
    public sealed partial class MainWindow : Window {
        public MainViewModel ViewModel { get; } = new MainViewModel();
        public MainWindow() {
            this.InitializeComponent();
        }
    }
}
