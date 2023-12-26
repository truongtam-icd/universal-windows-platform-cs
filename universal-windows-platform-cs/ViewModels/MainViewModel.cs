using System;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using universal_windows_platform_cs.Core.Services;

namespace universal_windows_platform_cs.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            await CompanyService.GetAll();
        }
    }
}
