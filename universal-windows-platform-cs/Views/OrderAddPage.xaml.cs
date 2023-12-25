using Microsoft.UI.Xaml.Controls;
using universal_windows_platform_cs.Core.Models;
using universal_windows_platform_cs.ViewModels;

using Windows.UI.Xaml.Controls;

namespace universal_windows_platform_cs.Views
{
    public sealed partial class OrderAddPage : Page
    {
        public OrderAddViewModel ViewModel { get; } = new OrderAddViewModel();

        public static Order OrderItem { get; set; }

        public OrderAddPage()
        {
            InitializeComponent();
            OrderItem = new Order();
        }

        private void ShipperNameText(object sender, TextChangedEventArgs e)
        {
            TextBox ShipperName = (TextBox)sender;
            OrderItem.ShipperName = ShipperName.Text;
        }

        private void CompanyIdValue(NumberBox sender, NumberBoxValueChangedEventArgs args)
        {
            if (args.NewValue > 0)
            {
                OrderItem.CompanyId = (int)args.NewValue;
            }
        }
    }
}
