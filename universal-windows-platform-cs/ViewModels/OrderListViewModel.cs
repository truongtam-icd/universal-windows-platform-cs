using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Microsoft.Toolkit.Mvvm.ComponentModel;

using universal_windows_platform_cs.Core.Models;
using universal_windows_platform_cs.Core.Services;

namespace universal_windows_platform_cs.ViewModels
{
    public class OrderListView : Order
    {
        public string Company { get; set; }
    }

    public class OrderListViewModel : ObservableObject
    {
        public ObservableCollection<OrderListView> Source { get; } = new ObservableCollection<OrderListView>();
        public ObservableCollection<string> OrderStatus { get; set; } = new ObservableCollection<string> {
            "", "Delivered", "Shipped"
        };

        public OrderListViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            // Replace this with your actual data
            var data = await DataService.GetGridDataAsync();

            foreach (var item in data)
            {
                OrderListView dataItem = new OrderListView
                {
                    OrderId = item.OrderId,
                    CompanyId = item.CompanyId,
                    OrderDate = item.OrderDate,
                    RequiredDate = item.RequiredDate,
                    ShippedDate = item.ShippedDate,
                    ShipperName = item.ShipperName,
                    ShipperPhone = item.ShipperPhone,
                    Freight = item.Freight,
                    ShipTo = item.ShipTo,
                    SymbolCode = item.SymbolCode,
                    Status = item.Status,
                    OrderTotal = item.OrderTotal,
                    Details = item.Details,
                    Company = await DataService.GetCompanyNameAsync(item.CompanyId)
                };
                Source.Add(dataItem);
            }
        }
    }
}
