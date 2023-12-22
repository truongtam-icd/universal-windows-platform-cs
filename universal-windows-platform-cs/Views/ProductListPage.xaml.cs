using Microsoft.Toolkit.Uwp.UI.Animations;
using System.Diagnostics;
using universal_windows_platform_cs.Services;
using universal_windows_platform_cs.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace universal_windows_platform_cs.Views
{
    public sealed partial class ProductListPage : Page
    {
        public ProductListViewModel ViewModel { get; } = new ProductListViewModel();
        public string OrderName { get; set; }

        public ProductListPage()
        {
            InitializeComponent();
            LoadingControl.IsLoading = true;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is long OrderId)
            {
                await ViewModel.InitializeAsync(OrderId);
                OrderName = $"Show all Product of OrderId {OrderId}";
            }
            LoadingControl.IsLoading = false;
        }
    }
}
