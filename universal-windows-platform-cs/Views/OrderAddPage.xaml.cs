using System;

using universal_windows_platform_cs.ViewModels;

using Windows.UI.Xaml.Controls;

namespace universal_windows_platform_cs.Views
{
    public sealed partial class OrderAddPage : Page
    {
        public OrderAddViewModel ViewModel { get; } = new OrderAddViewModel();

        public OrderAddPage()
        {
            InitializeComponent();
        }
    }
}
