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
            var data = await DataService.GetContentGridDataAsync();
            Order item = data.First(i => i.OrderId == OrderId);
            Item = new CompanyDetailView()
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
        }
    }
}
