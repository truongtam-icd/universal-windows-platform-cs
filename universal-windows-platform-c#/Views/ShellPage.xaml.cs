using System;
using System.Diagnostics;
using System.Threading.Tasks;
using universal_windows_platform_c_.Core.Services;
using universal_windows_platform_c_.ViewModels;

using Windows.UI.Xaml.Controls;

namespace universal_windows_platform_c_.Views
{
    // TODO: Change the icons and titles for all NavigationViewItems in ShellPage.xaml.
    public sealed partial class ShellPage : Page
    {
        public ShellViewModel ViewModel { get; } = new ShellViewModel();

        public ShellPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame, navigationView, KeyboardAccelerators);

            try
            {
                Task.Run(async () =>
                {
                    Debug.WriteLine("Waiting connect databases ...");
                    var result = await DataSourceService.TestConnection();
                    if (result)
                    {
                        Debug.WriteLine("Connect success!");
                    }
                    else
                    {
                        Debug.WriteLine("Connect fail!");
                    }
                    Debug.WriteLine("End connect databases!");
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
