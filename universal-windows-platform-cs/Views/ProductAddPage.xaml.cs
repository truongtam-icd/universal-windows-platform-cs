﻿using Microsoft.Toolkit.Uwp.UI.Animations;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Diagnostics;
using universal_windows_platform_cs.Core.Models;
using universal_windows_platform_cs.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace universal_windows_platform_cs.Views
{
    public sealed partial class ProductAddPage : Page
    {
        public ProductAddViewModel ViewModel { get; } = new ProductAddViewModel();

        public static Product ProductItem { get; set; }

        public ProductAddPage()
        {
            InitializeComponent();
            ProductItem = new Product();
            ProductItem.QuantityPerUnit = "0";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is long OrderId)
            {
                ProductItem.OrderId = OrderId;
            }
        }

        private void ProductNameText(object sender, TextChangedEventArgs e)
        {
            TextBox ProductNameTextBox = (TextBox)sender;
            ProductItem.ProductName = ProductNameTextBox.Text;
        }

        private void QuantityChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
        {
            ProductItem.Quantity = (int)args.NewValue;
            if (ProductItem.UnitPrice > 0)
            {
                Total.Text = (ProductItem.Quantity * ProductItem.UnitPrice).ToString();
            }
            else
            {
                Total.Text = "0";
            }
        }

        private void UnitPriceChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
        {
            ProductItem.UnitPrice = (int)args.NewValue;
            if (ProductItem.Quantity > 0)
            {
                Total.Text = (ProductItem.Quantity * ProductItem.UnitPrice).ToString();
            }
            else
            {
                Total.Text = "0";
            }
        }

        private void CategoryNameText(object sender, TextChangedEventArgs e)
        {
            TextBox CategoryNameTextBox = (TextBox)sender;
            ProductItem.CategoryName = CategoryNameTextBox.Text;
        }

        private void CategoryDescriptionText(object sender, TextChangedEventArgs e)
        {
            TextBox CategoryDescriptionTextBox = (TextBox)sender;
            ProductItem.CategoryDescription = CategoryDescriptionTextBox.Text;
        }

        private void TotalText(object sender, TextChangedEventArgs e)
        {
            TextBox TotalTextBox = (TextBox)sender;
            ProductItem.Total = long.Parse(TotalTextBox.Text);
        }
    }
}
