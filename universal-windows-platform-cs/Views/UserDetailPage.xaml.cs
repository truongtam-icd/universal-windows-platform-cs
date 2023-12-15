using System;

using universal_windows_platform_cs.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace universal_windows_platform_cs.Views
{
    public sealed partial class UserDetailPage : Page
    {
        public UserDetailViewModel ViewModel { get; } = new UserDetailViewModel();

        public UserDetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ViewModel.LoadDataAsync();
        }
    }
}
