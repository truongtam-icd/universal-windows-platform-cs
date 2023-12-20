using Microsoft.Toolkit.Uwp.UI.Controls;
using System.Threading.Tasks;
using universal_windows_platform_cs.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using universal_windows_platform_cs.Core.Models;
using universal_windows_platform_cs.Core.Services;

namespace universal_windows_platform_cs.Views
{
    public sealed partial class UserListPage : Page
    {
        public UserListViewModel ViewModel { get; } = new UserListViewModel();

        // TODO: Change the grid as appropriate to your app, adjust the column definitions on UserListPage.xaml.
        // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
        public UserListPage()
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

        private async void UpdateOrderData(object sender, DataGridCellEditEndedEventArgs e)
        {
            Order UpdateOrder = (Order)e.Row.DataContext;
            if (UpdateOrder != null)
            {
                await OrderService.Update(UpdateOrder);
            }
        }
    }
}
