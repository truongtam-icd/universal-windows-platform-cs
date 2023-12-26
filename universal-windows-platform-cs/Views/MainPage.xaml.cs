using System;

using universal_windows_platform_cs.ViewModels;

using Windows.UI.Xaml.Controls;

using universal_windows_platform_cs.Core.Services;

// using Logger;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace universal_windows_platform_cs.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
            // Debug.WriteLine(Logging.LogPath);
            // Logging.Info("Insert logging to file!");
            LoadingControl.IsLoading = true;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await Task.Delay(100);
            await ViewModel.LoadDataAsync();
            LoadingControl.IsLoading = false;
        }
    }
}
