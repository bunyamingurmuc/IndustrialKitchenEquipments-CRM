﻿// <auto-generated />
using System;
using IndustrialKitchenEquipmentsCRM.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IndustrialKitchenEquipmentsCRM.DAL.Migrations
{
    [DbContext(typeof(IndustrialKitchenEquipmentsContext))]
    [Migration("20221128185619_dasdsad")]
    partial class dasdsad
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IndustrialKitchenEquipmentsCRM.Entities.Auth.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("IndustrialKitchenEquipmentsCRM.Entities.Card.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AppUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrencyUnit")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("IndustrialKitchenEquipmentsCRM.Entities.Card.CardItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("CardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("StockId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("StockId");

                    b.ToTable("CardItems");
                });

            modelBuilder.Entity("IndustrialKitchenEquipmentsCRM.Entities.Category.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("IndustrialKitchenEquipmentsCRM.Entities.Customer.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("IndustrialKitchenEquipmentsCRM.Entities.Image.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("StockId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("IndustrialKitchenEquipmentsCRM.Entities.Stock.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAvalible")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("StockCount")
                        .HasColumnType("int");

                    b.Property<string>("StockDescription1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StockDescription2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StockName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("IndustrialKitchenEquipmentsCRM.Entities.Card.Card", b =>
                {
                    b.HasOne("IndustrialKitchenEquipmentsCRM.Entities.Auth.AppUser", "AppUser")
                        .WithMany("Cards")
                        .HasForeignKey("AppUserId");

                    b.HasOne("IndustrialKitchenEquipmentsCRM.Entities.Customer.Customer", "Customer")
                        .WithMany("Cards")
                        .HasForeignKey("CustomerId");

                    b.Navigation("AppUser");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("IndustrialKitchenEquipmentsCRM.Entities.Card.CardItem", b =>
                {
                    b.HasOne("IndustrialKitchenEquipmentsCRM.Entities.Card.Card", "Card")
                        .WithMany("CardItems")
                        .HasForeignKey("CardId");

                    b.HasOne("IndustrialKitchenEquipmentsCRM.Entities.Stock.Stock", "Stock")
                        .WithMany("CardItems")
                        .HasForeignKey("StockId");

                    b.Navigation("Card");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("IndustrialKitchenEquipmentsCRM.Entities.Image.Image", b =>
                {
                    b.HasOne("IndustrialKitchenEquipmentsCRM.Entities.Stock.Stock", "Stock")
                        .WithMany("Images")
                        .HasForeignKey("StockId");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("IndustrialKitchenEquipmentsCRM.Entities.Stock.Stock", b =>
                {
                    b.HasOne("IndustrialKitchenEquipmentsCRM.Entities.Category.Category", "Category")
                        .WithMany("Stocks")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("IndustrialKitchenEquipmentsCRM.Entities.Auth.AppUser", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("IndustrialKitchenEquipmentsCRM.Entities.Card.Card", b =>
                {
                    b.Navigation("CardItems");
                });

            modelBuilder.Entity("IndustrialKitchenEquipmentsCRM.Entities.Category.Category", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("IndustrialKitchenEquipmentsCRM.Entities.Customer.Customer", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("IndustrialKitchenEquipmentsCRM.Entities.Stock.Stock", b =>
                {
                    b.Navigation("CardItems");

                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
