using System;
using System.Diagnostics;
using System.Threading.Tasks;
using universal_windows_platform_cs.Core.Services;
using universal_windows_platform_cs.ViewModels;

using Windows.UI.Xaml.Controls;

namespace universal_windows_platform_cs.Views
{
    // TODO: Change the icons and titles for all NavigationViewItems in ShellPage.xaml.
    public sealed partial class ShellPage : Page
    {
        public ShellViewModel ViewModel { get; } = new ShellViewModel();
        private static readonly string PageName = "ShellPage";

        public ShellPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame, navigationView, KeyboardAccelerators);

            try
            {
                Task.Run(async () =>
                {
                    Debug.WriteLine($"{PageName}: Waiting connect databases ...");
                    var result = await DataSourceService.TestConnection();
                    if (result)
                    {
                        Debug.WriteLine($"{PageName}: Connect success!");
                    }
                    else
                    {
                        Debug.WriteLine($"{PageName}: Connect fail!");
                    }
                    Debug.WriteLine($"{PageName}: End connect databases!");
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{PageName}: {ex}");
            }
        }
    }
}
