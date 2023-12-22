using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using universal_windows_platform_cs.Core.Models;
using universal_windows_platform_cs.Core.Services;
using universal_windows_platform_cs.Services;
using universal_windows_platform_cs.Views;

namespace universal_windows_platform_cs.ViewModels
{
    public class ProductListViewModel : ObservableObject
    {
        private ICommand _newProductCommand;
        public ICommand CreateProductCommand => _newProductCommand ?? (_newProductCommand = new RelayCommand(CreateProduct));
        public ObservableCollection<Product> Source { get; } = new ObservableCollection<Product>();

        public ProductListViewModel()
        {
        }

        public async Task InitializeAsync(long OrderId)
        {
            Source.Clear();
            await Task.CompletedTask;
            List<Product> data = await ProductService.GetByOrderId(OrderId);
            foreach (var item in data)
            {
                Source.Add(item);
            }
        }
        private static void CreateProduct()
        {
            NavigationService.Navigate<ProductAddPage>();
        }
    }
}
