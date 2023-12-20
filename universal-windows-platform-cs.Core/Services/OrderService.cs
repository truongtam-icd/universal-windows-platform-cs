using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using universal_windows_platform_cs.Core.Models;
using UWPApp.PostgreSQL;

namespace universal_windows_platform_cs.Core.Services
{
    public static class OrderService
    {
        public static async Task<bool> Update(Order NewOrder)
        {
            await Task.CompletedTask;
            using (var db = new UWPContext())
            {
                try
                {
                    Order OldOrder = (Order)db.Order.Where(order => order.OrderId == NewOrder.OrderId).First();
                    if (OldOrder != null)
                    {
                        OldOrder.OrderTotal = NewOrder.OrderTotal;
                        OldOrder.Status = NewOrder.Status;
                        db.Order.Update(OldOrder);
                        db.SaveChanges();
                        return true;
                    } 
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return false;
                }
            }
        }
    }
}
