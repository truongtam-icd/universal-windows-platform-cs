using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Uwp.UI.Animations;

using universal_windows_platform_c_.Core.Models;
using universal_windows_platform_c_.Core.Services;
using universal_windows_platform_c_.Services;
using universal_windows_platform_c_.Views;

namespace universal_windows_platform_c_.ViewModels
{
    public class UserDetailViewModel : ObservableObject
    {
        private ICommand _itemClickCommand;

        public ICommand ItemClickCommand => _itemClickCommand ?? (_itemClickCommand = new RelayCommand<Order>(OnItemClick));

        public ObservableCollection<Order> Source { get; } = new ObservableCollection<Order>();

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
                Source.Add(item);
            }
        }

        private void OnItemClick(Order clickedItem)
        {
            if (clickedItem != null)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(clickedItem);
                NavigationService.Navigate<UserDetailDetailPage>(clickedItem.OrderId);
            }
        }
    }
}
