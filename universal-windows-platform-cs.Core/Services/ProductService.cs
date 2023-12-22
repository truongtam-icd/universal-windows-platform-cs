using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using universal_windows_platform_cs.Core.Models;
using UWPApp.PostgreSQL;

namespace universal_windows_platform_cs.Core.Services
{
    public static class ProductService
    {
        public static async Task<List<Product>> GetByOrderId(long OrderId)
        {
            await Task.CompletedTask;
            using (var db = new UWPContext())
            {
                try
                {
                    List<Product> data = db.Product.Where(product => product.OrderId == OrderId).ToList();
                    return data;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return null;
                }
            }
        }
    }
}
