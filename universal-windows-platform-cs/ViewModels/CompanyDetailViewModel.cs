using System.Linq;
using System.Threading.Tasks;

using Microsoft.Toolkit.Mvvm.ComponentModel;

using universal_windows_platform_cs.Core.Models;
using universal_windows_platform_cs.Core.Services;

namespace universal_windows_platform_cs.ViewModels
{
    public class CompanyDetailView : Order
    {
        public string Company { get; set; }
    }

    public class CompanyDetailViewModel : ObservableObject
    {
        private CompanyDetailView _item;

        public CompanyDetailView Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        public CompanyDetailViewModel()
        {
        }

        public async Task InitializeAsync(long OrderId)
        {
            var data = await OrderService.GetByOrderId(OrderId);
            Item = new CompanyDetailView()
            {
                OrderId = data.OrderId,
                CompanyId = data.CompanyId,
                OrderDate = data.OrderDate,
                RequiredDate = data.RequiredDate,
                ShippedDate = data.ShippedDate,
                ShipperName = data.ShipperName,
                ShipperPhone = data.ShipperPhone,
                Freight = data.Freight,
                ShipTo = data.ShipTo,
                SymbolCode = data.SymbolCode,
                Status = data.Status,
                OrderTotal = data.OrderTotal,
                Details = data.Details,
                Company = data.CompanyName
            };
        }
    }
}
