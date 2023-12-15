using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Toolkit.Mvvm.ComponentModel;

using universal_windows_platform_cs.Core.Models;
using universal_windows_platform_cs.Core.Services;

namespace universal_windows_platform_cs.ViewModels
{
    public class UserDetailDetailViewModel : ObservableObject
    {
        private Order _item;

        public Order Item
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
            Item = data.First(i => i.OrderId == OrderId);
        }
    }
}
