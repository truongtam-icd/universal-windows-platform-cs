﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Migration.PostgreSQL;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace universalwindowsplatformcs.Migration.Migrations
{
    [DbContext(typeof(UWPContext))]
    [Migration("20231215073957_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("universal_windows_platform_cs.Core.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("CompanyName")
                        .HasColumnType("text");

                    b.Property<string>("ContactName")
                        .HasColumnType("text");

                    b.Property<string>("ContactTitle")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Fax")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .HasColumnType("text");

                    b.HasKey("CompanyId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("universal_windows_platform_cs.Core.Models.Order", b =>
                {
                    b.Property<long>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
                    
                    b.Property<int?>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<double>("Freight")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("OrderTotal")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("RequiredDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ShipTo")
                        .HasColumnType("text");

                    b.Property<DateTime>("ShippedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ShipperName")
                        .HasColumnType("text");

                    b.Property<string>("ShipperPhone")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<int>("SymbolCode")
                        .HasColumnType("integer");

                    b.HasKey("OrderId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("universal_windows_platform_cs.Core.Models.Product", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("text");

                    b.Property<string>("CategoryName")
                        .HasColumnType("text");

                    b.Property<double>("Discount")
                        .HasColumnType("double precision");

                    b.Property<string>("ProductName")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("QuantityPerUnit")
                        .HasColumnType("text");

                    b.Property<double>("Total")
                        .HasColumnType("double precision");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("double precision");

                    b.HasKey("ProductId");

                    b.HasIndex("OrderId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("universal_windows_platform_cs.Core.Models.Order", b =>
                {
                    b.HasOne("universal_windows_platform_cs.Core.Models.Company", null)
                        .WithMany("Orders")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("universal_windows_platform_cs.Core.Models.Product", b =>
                {
                    b.HasOne("universal_windows_platform_cs.Core.Models.Order", null)
                        .WithMany("Details")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
