using System;
using universal_windows_platform_cs.Core.Models;
using universal_windows_platform_cs.ViewModels;

using Windows.UI.Xaml.Controls;

namespace universal_windows_platform_cs.Views
{
    public sealed partial class OrderAddPage : Page
    {
        public OrderAddViewModel ViewModel { get; } = new OrderAddViewModel();

        public static Order OrderItem { get; set; } = new Order();

        public OrderAddPage()
        {
            InitializeComponent();
        }

        private void CompanyIdText(object sender, TextChangedEventArgs e)
        {
            TextBox CompanyId = (TextBox)sender;
            try
            {
                OrderItem.CompanyId = Int32.Parse(CompanyId.Text);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{CompanyId}'");
            }
        }

        private void ShipperNameText(object sender, TextChangedEventArgs e)
        {
            TextBox ShipperName = (TextBox)sender;
            OrderItem.ShipperName = ShipperName.Text;
        }
    }
}
