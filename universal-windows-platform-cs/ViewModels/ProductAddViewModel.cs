using System;
using System.Diagnostics;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using universal_windows_platform_cs.Core.Services;
using universal_windows_platform_cs.Services;
using universal_windows_platform_cs.Views;

namespace universal_windows_platform_cs.ViewModels
{
    public class ProductAddViewModel : ObservableObject
    {
        public ICommand CreateProductCommand { get; set; }
        public ProductAddViewModel()
        {
            CreateProductCommand = new RelayCommand(CreateProduct);
        }

        private static async void CreateProduct()
        {
            await ProductService.Add(ProductAddPage.ProductItem);
            NavigationService.Navigate<ProductListPage>(ProductAddPage.ProductItem.OrderId);
        }
    }
}
