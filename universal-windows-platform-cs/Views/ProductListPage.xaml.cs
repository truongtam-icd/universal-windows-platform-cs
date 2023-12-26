using Microsoft.Toolkit.Uwp.UI.Animations;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System.Diagnostics;
using universal_windows_platform_cs.Core.Models;
using universal_windows_platform_cs.Core.Services;
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

        private async void UpdateProductData(object sender, DataGridCellEditEndedEventArgs e)
        {
            Product UpdateProduct = (Product)e.Row.DataContext;
            if (UpdateProduct != null)
            {
                await ProductService.Update(UpdateProduct);
                await OrderService.UpdateByOrderId(UpdateProduct.OrderId);
                await ViewModel.InitializeAsync(UpdateProduct.OrderId);
            }
        }
    }
}
