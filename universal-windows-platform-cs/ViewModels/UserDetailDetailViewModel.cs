using System.Linq;
using System.Threading.Tasks;

using Microsoft.Toolkit.Mvvm.ComponentModel;

using universal_windows_platform_cs.Core.Models;
using universal_windows_platform_cs.Core.Services;

namespace universal_windows_platform_cs.ViewModels
{
    public class UserDetailDetailView : Order
    {
        public string Company { get; set; }
    }

    public class UserDetailDetailViewModel : ObservableObject
    {
        private UserDetailDetailView _item;

        public UserDetailDetailView Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        public UserDetailDetailViewModel()
        {
        }

        public async Task InitializeAsync(long OrderId)
        {
            var data = await DataService.GetContentGridDataAsync();
            Order item = data.First(i => i.OrderId == OrderId);
            Item = new UserDetailDetailView()
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
