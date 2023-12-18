using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using universal_windows_platform_cs.Core.Models;
using UWPApp.PostgreSQL;

namespace universal_windows_platform_cs.Core.Services
{
    public static class DataService
    {
        private static IEnumerable<Order> _allOrders;

        private static IEnumerable<Order> AllOrders()
        {
            // The following is order summary data
            var companies = AllCompanies();
            return companies.SelectMany(c => c.Orders);
        }

        private static IEnumerable<Company> AllCompanies()
        {
            List<Company> AllCompanies = new List<Company>();
    
            using (var db = new UWPContext())
            {
                var Companies = db.Company.ToList();
                foreach (var company in Companies)
                {
                    var Oders = db.Order.Where(order => order.CompanyId == company.CompanyId).ToList();
                    List<Order> AllOders = new List<Order>();
                    if (Oders != null)
                    {
                        foreach (var order in Oders)
                        {
                            var Products = db.Product.Where(product => product.OrderId == order.OrderId).ToList();
                            List<Product> AllProducts = new List<Product>();
                            if (Oders != null)
                            { 
                                foreach (var product in Products)
                                {
                                    AllProducts.Add(product);
                                }
                            }
                            AllOders.Add(order);
                        }
                    }
                    AllCompanies.Add(company);
                }
            }

            return AllCompanies;
        }

        // Remove this once your ContentGrid page is displaying real data.
        public static async Task<IEnumerable<Order>> GetContentGridDataAsync()
        {
            if (_allOrders == null)
            {
                _allOrders = AllOrders();
            }

            await Task.CompletedTask;
            return _allOrders;
        }

        // Remove this once your grid page is displaying real data.
        public static async Task<IEnumerable<Order>> GetGridDataAsync()
        {
            await Task.CompletedTask;
            return AllOrders();
        }
    }
}
