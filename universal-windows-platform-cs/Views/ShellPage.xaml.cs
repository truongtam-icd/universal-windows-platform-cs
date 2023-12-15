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

        public ShellPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame, navigationView, KeyboardAccelerators);

            try
            {
                Task.Run(async () =>
                {
                    Debug.WriteLine(string.Format("{0}: Waiting connect databases ...", "ShellPage"));
                    var result = await DataSourceService.TestConnection();
                    if (result)
                    {
                        Debug.WriteLine(string.Format("{0}: Connect success!", "ShellPage"));
                    }
                    else
                    {
                        Debug.WriteLine(string.Format("{0}: Connect fail!", "ShellPage"));
                    }
                    Debug.WriteLine(string.Format("{0}: End connect databases!", "ShellPage"));
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
