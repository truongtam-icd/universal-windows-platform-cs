using Microsoft.EntityFrameworkCore.Migrations;
using System;
using universal_windows_platform_cs.Core.Models;

namespace universalwindowsplatformcs.Migration.Migrations
{
    public partial class AddCompany : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        private readonly string Name = "Company";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Console.WriteLine($"Migrations Up Table: {Name}");
            migrationBuilder.InsertData(
            table: Name,
            columns: new[] {
                nameof(Company.CompanyName),
                nameof(Company.ContactName),
                nameof(Company.ContactTitle),
                nameof(Company.Address),
                nameof(Company.City),
                nameof(Company.PostalCode),
                nameof(Company.Country),
                nameof(Company.Phone),
                nameof(Company.Fax)
            },
            values: new object[,] {
                { 
                    "Company A", "Maria Anders", "Sales Representative", "Obere Str. 57", 
                    "Berlin", "12209", "Germany", "030-0074321", "030-0076545" 
                },
                {
                    "Company B", "Name Test", "Title Test", "Obere Str. 57",
                    "Berlin", "12209", "Germany", "030-0074321", "030-0076545"
                }
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            Console.WriteLine($"Migrations Down Table: {Name}");
            migrationBuilder.DeleteData(
            table: Name,
            keyColumns: new[] {
                nameof(Company.CompanyName)
            },
            keyValues: new object[] {
                "Company A"
            });
        }
    }
}
