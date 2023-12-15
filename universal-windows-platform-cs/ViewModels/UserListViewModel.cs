using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Microsoft.Toolkit.Mvvm.ComponentModel;

using universal_windows_platform_cs.Core.Models;
using universal_windows_platform_cs.Core.Services;

namespace universal_windows_platform_cs.ViewModels
{
    public class UserListViewModel : ObservableObject
    {
        public ObservableCollection<Order> Source { get; } = new ObservableCollection<Order>();

        public UserListViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            // Replace this with your actual data
            var data = await DataService.GetGridDataAsync();

            foreach (var item in data)
            {
                Source.Add(item);
            }
        }
    }
}
