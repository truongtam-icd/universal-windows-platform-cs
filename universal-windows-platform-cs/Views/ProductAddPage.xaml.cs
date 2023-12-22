using System;

using universal_windows_platform_cs.ViewModels;

using Windows.UI.Xaml.Controls;

namespace universal_windows_platform_cs.Views
{
    public sealed partial class ProductAddPage : Page
    {
        public ProductAddViewModel ViewModel { get; } = new ProductAddViewModel();

        public ProductAddPage()
        {
            InitializeComponent();
        }
    }
}
