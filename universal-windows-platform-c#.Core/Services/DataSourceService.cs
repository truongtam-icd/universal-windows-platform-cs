using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

using universal_windows_platform_c_.Core.Models;
using System.ComponentModel.Design;

using Npgsql;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace universal_windows_platform_c_.Core.Services
{
    public static class DataSourceService
    {
        public static async Task<bool> TestConnection()
        {
            string connString;
            var connectionStrings = ConfigurationManager.ConnectionStrings;

            if (connectionStrings != null)
            {
                connString = connectionStrings["PostgreSQLConnectionString"].ToString();
            }
            else
            {
                return false;
            }

            try
            {
                var dataSource = NpgsqlDataSource.Create(connString);
                var connection = await dataSource.OpenConnectionAsync();
                var cmd = new NpgsqlCommand("SELECT '1'", connection);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        if (reader.GetString(0) == "1") return true;
                    }
                }
                return false;
            }
            catch
            {
                Debug.WriteLine("Please check server or config database!");
                return false;
            }
        }

        public static async Task<NpgsqlConnection> GetConnection()
        {
            string connString;
            var connectionStrings = ConfigurationManager.ConnectionStrings;

            if (connectionStrings != null)
            {
                connString = connectionStrings["PostgreSQLConnectionString"].ToString();
            }
            else
            {
                return null;
            }

            try
            {
                var dataSource = NpgsqlDataSource.Create(connString);
                var connection = await dataSource.OpenConnectionAsync();
                return connection;
            }
            catch
            {
                Debug.WriteLine("Please check server or config database!");
                return null;
            }
        }
    }
}

