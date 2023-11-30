using System;

using universal_windows_platform_c_.ViewModels;

using Windows.UI.Xaml.Controls;

namespace universal_windows_platform_c_.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
