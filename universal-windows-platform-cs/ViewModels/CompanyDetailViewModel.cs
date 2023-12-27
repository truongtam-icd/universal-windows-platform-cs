using System.Linq;
using System.Threading.Tasks;

using Microsoft.Toolkit.Mvvm.ComponentModel;

using universal_windows_platform_cs.Core.Models;
using universal_windows_platform_cs.Core.Services;

namespace universal_windows_platform_cs.ViewModels
{
    public class CompanyDetailView : Company
    {
        public string FullAddress { get; set; }
    }

    public class CompanyDetailViewModel : ObservableObject
    {
        public CompanyDetailView Item { get; set; }

        public CompanyDetailViewModel()
        {
        }

        public async Task InitializeAsync(int CompanyId)
        {
            var data = await CompanyService.GetByCompanyId(CompanyId);
            Item = new CompanyDetailView()
            {
                CompanyId = data.CompanyId,
                CompanyName = data.CompanyName,
                Address = data.Address,
                City = data.City,
                Country = data.Country,
                ContactName = data.ContactName,
                PostalCode = data.PostalCode,
                Fax = data.Fax,
                ContactTitle = data.ContactTitle,
                Orders = data.Orders,
                Phone = data.Phone,
                FullAddress = $"{data.ContactName} {data.Address}, {data.City}, {data.Country}"
            };
        }
    }
}
