using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using universal_windows_platform_cs.Core.Services;

namespace universal_windows_platform_cs.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public ICommand MainViewCommand { get; set; }
        public MainViewModel()
        {
            MainViewCommand = new RelayCommand(DebugCommand);
        }

        public async Task LoadDataAsync()
        {
            await DataSourceService.TestConnection();
        }

        private void DebugCommand()
        {
            Debug.WriteLine($"DebugCommand");
        }
    }
}
