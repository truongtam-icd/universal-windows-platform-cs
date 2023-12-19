using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Uwp.UI.Animations;

using universal_windows_platform_cs.Core.Models;
using universal_windows_platform_cs.Core.Services;
using universal_windows_platform_cs.Services;
using universal_windows_platform_cs.Views;

namespace universal_windows_platform_cs.ViewModels
{
    public class UserDetailView : Order
    {
        public string Company { get; set; }
    }

    public class UserDetailViewModel : ObservableObject
    {
        private ICommand _itemClickCommand;

        public ICommand ItemClickCommand => _itemClickCommand ?? (_itemClickCommand = new RelayCommand<UserDetailView>(OnItemClick));

        public ObservableCollection<UserDetailView> Source { get; } = new ObservableCollection<UserDetailView>();

        public UserDetailViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            // Replace this with your actual data
            var data = await DataService.GetContentGridDataAsync();
            foreach (var item in data)
            {
                UserDetailView dataItem = new UserDetailView
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

        private void OnItemClick(UserDetailView clickedItem)
        {
            if (clickedItem != null)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(clickedItem);
                NavigationService.Navigate<UserDetailDetailPage>(clickedItem.OrderId);
            }
        }
    }
}
