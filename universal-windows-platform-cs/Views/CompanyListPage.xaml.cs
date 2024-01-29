using PassportLogin.AuthService;
using PassportLogin.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using universal_windows_platform_cs.Services;
using universal_windows_platform_cs.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace universal_windows_platform_cs.Views
{
    public sealed partial class CompanyListPage : Page
    {
        public CompanyListViewModel ViewModel { get; } = new CompanyListViewModel();

        public CompanyListPage()
        {
            InitializeComponent();
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
