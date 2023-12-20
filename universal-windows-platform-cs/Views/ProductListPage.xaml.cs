using System;

using universal_windows_platform_cs.ViewModels;

using Windows.UI.Xaml.Controls;

namespace universal_windows_platform_cs.Views
{
    public sealed partial class ProductListPage : Page
    {
        public ProductListViewModel ViewModel { get; } = new ProductListViewModel();

        public ProductListPage()
        {
            InitializeComponent();
        }
    }
}
