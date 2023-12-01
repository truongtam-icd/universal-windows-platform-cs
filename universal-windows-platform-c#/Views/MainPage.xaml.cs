using System;

using universal_windows_platform_c_.ViewModels;

using Windows.UI.Xaml.Controls;

using universal_windows_platform_c_.Core.Services;

// using Logger;
using System.Diagnostics;
using System.Threading.Tasks;

namespace universal_windows_platform_c_.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
            // Debug.WriteLine(Logging.LogPath);
            // Logging.Info("Insert logging to file!");

            try
            {
                Task.Run(async () =>
                {
                    Debug.WriteLine("Waiting connect databases ...");
                    var result = await DataSourceService.TestConnection();
                    if (result)
                    {
                        Debug.WriteLine("Connect success!");
                    } else
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
