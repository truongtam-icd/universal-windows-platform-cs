using System;

using universal_windows_platform_cs.ViewModels;

using Windows.UI.Xaml.Controls;

using universal_windows_platform_cs.Core.Services;

// using Logger;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using PassportLogin.AuthService;
using System.Collections.Generic;
using PassportLogin.Utils;
using System.Linq;
using universal_windows_platform_cs.Services;

namespace universal_windows_platform_cs.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
            LoadingControl.IsLoading = true;
            DataContext = ViewModel;
            // Debug.WriteLine(Logging.LogPath);
            // Logging.Info("Insert logging to file!");
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            List<UserAccount> accounts = AuthService.Instance.GetUserAccountsForDevice(AuthHelper.GetDeviceId());
            
            if (accounts.Any())
            {
                base.OnNavigatedTo(e);
                await Task.Delay(100);
                await ViewModel.LoadDataAsync();
            }
            LoadingControl.IsLoading = false;
        }
    }
}
