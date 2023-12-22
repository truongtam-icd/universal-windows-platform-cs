using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Diagnostics;
using universal_windows_platform_cs.Core.Models;
using universal_windows_platform_cs.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace universal_windows_platform_cs.Views
{
    public sealed partial class ProductAddPage : Page
    {
        public ProductAddViewModel ViewModel { get; } = new ProductAddViewModel();

        public static Product ProductItem { get; set; } = new Product();

        public ProductAddPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is long OrderId)
            {
                ProductItem.OrderId = OrderId;
            }
        }

        private void TotalText(object sender, TextChangedEventArgs e)
        {
            TextBox Total = (TextBox)sender;
            try
            {
                ProductItem.Total = Int32.Parse(Total.Text);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{Total}'");
            }
        }

        private void ProductNameText(object sender, TextChangedEventArgs e)
        {
            TextBox ProductName = (TextBox)sender;
            ProductItem.ProductName = ProductName.Text;
        }
    }
}
