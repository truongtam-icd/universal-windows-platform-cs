using System;

using universal_windows_platform_c_.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace universal_windows_platform_c_.Views
{
    public sealed partial class UserListPage : Page
    {
        public UserListViewModel ViewModel { get; } = new UserListViewModel();

        // TODO: Change the grid as appropriate to your app, adjust the column definitions on UserListPage.xaml.
        // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
        public UserListPage()
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
