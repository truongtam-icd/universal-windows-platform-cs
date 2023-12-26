using Microsoft.UI.Xaml.Controls;
using System.Diagnostics;
using System.Threading.Tasks;
using universal_windows_platform_cs.Core.Models;
using universal_windows_platform_cs.Core.Services;
using universal_windows_platform_cs.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

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
            LoadingControl.IsLoading = true;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await Task.Delay(100);
            await ViewModel.LoadDataAsync();
            OrderItem.Status = "Available";
            LoadingControl.IsLoading = false;
        }

        private async void CompanyChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox ComboBoxCompany = (ComboBox)sender;
            if (ComboBoxCompany != null)
            {
                string CompanyName = ComboBoxCompany.SelectedValue.ToString();
                Company _Company = await ViewModel.InfoCompany(CompanyName);
                OrderItem.CompanyId = _Company.CompanyId;
                ShipTo.Text = $"{CompanyName} {_Company.Address}, {_Company.City}, {_Company.Country}";
            }
        }

        private void ShipperNameText(object sender, TextChangedEventArgs e)
        {
            TextBox TextBoxShipperName = (TextBox)sender;
            OrderItem.ShipperName = TextBoxShipperName.Text;
        }

        private void ShipToText(object sender, TextChangedEventArgs e)
        {
            TextBox TextBoxShipTo = (TextBox)sender;
            OrderItem.ShipTo = TextBoxShipTo.Text;
        }

        private void ShipperPhoneChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
        {
            OrderItem.ShipperPhone = args.NewValue.ToString();
        }

        private void FreightChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
        {
            OrderItem.Freight = args.NewValue;
        }

        private void OrderTotalChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
        {
            OrderItem.OrderTotal = args.NewValue;
        }

        private void OrderDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            DatePicker DatePickerOrderDate = (DatePicker)sender;
            OrderItem.OrderDate = DatePickerOrderDate.SelectedDate.Value.DateTime;
        }

        private void RequiredDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            DatePicker DatePickerRequiredDate = (DatePicker)sender;
            OrderItem.RequiredDate = DatePickerRequiredDate.SelectedDate.Value.DateTime;
        }

        private void ShippedDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            DatePicker DatePickerShippedDate = (DatePicker)sender;
            OrderItem.ShippedDate = DatePickerShippedDate.SelectedDate.Value.DateTime;
        }
    }
}
