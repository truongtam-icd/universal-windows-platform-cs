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
    public class OrderCreate
    {
        public int CompanyId { get; set; }
        public string ShipperName { get; set; }
    }
    public class OrderAddViewModel : ObservableObject
    {
        private ICommand _createOrderCommand;
        public ICommand CreateOrderCommand => _createOrderCommand ?? (_createOrderCommand = new RelayCommand(CreateOrder));

        public OrderAddViewModel()
        {
        }

        private static async void CreateOrder()
        {
            await OrderService.Add(OrderAddPage.OrderItem);
            NavigationService.Navigate<OrderListPage>();
        }
    }
}
