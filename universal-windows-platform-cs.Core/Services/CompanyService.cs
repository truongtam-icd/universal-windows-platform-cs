using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using universal_windows_platform_cs.Core.Models;
using UWPApp.PostgreSQL;

namespace universal_windows_platform_cs.Core.Services
{
    public static class CompanyService
    {
        public static async Task<List<Company>> GetAll()
        {
            await Task.CompletedTask;
            using (var db = new UWPContext())
            {
                try
                {
                    List<Company> data = db.Company.Where(company => true).ToList();
                    return data;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return null;
                }
            }
        }

        public static async Task<Company> GetByCompanyId(int CompanyId)
        {
            await Task.CompletedTask;
            using (var db = new UWPContext())
            {
                try
                {
                    Company data = db.Company.Where(company => company.CompanyId == CompanyId).First();
                    return data;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return null;
                }
            }
        }

        public static async Task<Company> GetByCompanyName(string CompanyName)
        {
            await Task.CompletedTask;
            using (var db = new UWPContext())
            {
                try
                {
                    Company data = db.Company.Where(company => company.CompanyName == CompanyName).First();
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
