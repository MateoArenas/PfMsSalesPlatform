﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PfMsSalesPlatform.Infrastructure.Context;

#nullable disable

namespace PfMsSalesPlatform.Infrastructure.Migrations
{
    [DbContext(typeof(SalesDBContext))]
    partial class SalesDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PfMsSalesPlatform.Domain.Aggregates.Clients.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("ClientTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientTypeId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("PfMsSalesPlatform.Domain.Aggregates.Clients.Models.ClientType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("ClientTypes");
                });

            modelBuilder.Entity("PfMsSalesPlatform.Domain.Aggregates.Products.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ActualizationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ApplyClientDiscount")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PfMsSalesPlatform.Domain.Aggregates.Products.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("PfMsSalesPlatform.Domain.Aggregates.SalesBody.Models.Salebody", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SaleHeaderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleHeaderId");

                    b.ToTable("Salebodys");
                });

            modelBuilder.Entity("PfMsSalesPlatform.Domain.Aggregates.SalesHeader.Models.SaleHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DiscontApply")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("SaleHeaders");
                });

            modelBuilder.Entity("PfMsSalesPlatform.Domain.Aggregates.Clients.Models.Client", b =>
                {
                    b.HasOne("PfMsSalesPlatform.Domain.Aggregates.Clients.Models.ClientType", "ClientType")
                        .WithMany("Clients")
                        .HasForeignKey("ClientTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientType");
                });

            modelBuilder.Entity("PfMsSalesPlatform.Domain.Aggregates.Products.Models.Product", b =>
                {
                    b.HasOne("PfMsSalesPlatform.Domain.Aggregates.Products.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("PfMsSalesPlatform.Domain.Aggregates.SalesBody.Models.Salebody", b =>
                {
                    b.HasOne("PfMsSalesPlatform.Domain.Aggregates.Products.Models.Product", "Product")
                        .WithMany("Salebody")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PfMsSalesPlatform.Domain.Aggregates.SalesHeader.Models.SaleHeader", "SaleHeader")
                        .WithMany("Salebody")
                        .HasForeignKey("SaleHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SaleHeader");
                });

            modelBuilder.Entity("PfMsSalesPlatform.Domain.Aggregates.SalesHeader.Models.SaleHeader", b =>
                {
                    b.HasOne("PfMsSalesPlatform.Domain.Aggregates.Clients.Models.Client", "Client")
                        .WithMany("SaleHeaders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("PfMsSalesPlatform.Domain.Aggregates.Clients.Models.Client", b =>
                {
                    b.Navigation("SaleHeaders");
                });

            modelBuilder.Entity("PfMsSalesPlatform.Domain.Aggregates.Clients.Models.ClientType", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("PfMsSalesPlatform.Domain.Aggregates.Products.Models.Product", b =>
                {
                    b.Navigation("Salebody");
                });

            modelBuilder.Entity("PfMsSalesPlatform.Domain.Aggregates.Products.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PfMsSalesPlatform.Domain.Aggregates.SalesHeader.Models.SaleHeader", b =>
                {
                    b.Navigation("Salebody");
                });
#pragma warning restore 612, 618
        }
    }
}
