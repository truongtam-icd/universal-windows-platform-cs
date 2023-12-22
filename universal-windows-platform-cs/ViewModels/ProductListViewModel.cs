using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using universal_windows_platform_cs.Core.Models;
using universal_windows_platform_cs.Core.Services;
using UWPApp.PostgreSQL;
using Windows.ApplicationModel.Store;

namespace universal_windows_platform_cs.ViewModels
{
    public class ProductListViewModel : ObservableObject
    {
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
    }
}
