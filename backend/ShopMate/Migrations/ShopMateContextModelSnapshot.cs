﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopMate.Persistence.Relational;

namespace ShopMate.Migrations
{
    [DbContext(typeof(ShopMateContext))]
    partial class ShopMateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-rc.1.20451.13");

            modelBuilder.Entity("BrandProduct", b =>
                {
                    b.Property<int>("BrandsId")
                        .HasColumnType("int");

                    b.Property<string>("ProductsBarcode")
                        .HasColumnType("char(14)");

                    b.HasKey("BrandsId", "ProductsBarcode");

                    b.HasIndex("ProductsBarcode");

                    b.ToTable("BrandProduct");
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<string>("ProductsBarcode")
                        .HasColumnType("char(14)");

                    b.HasKey("CategoriesId", "ProductsBarcode");

                    b.HasIndex("ProductsBarcode");

                    b.ToTable("CategoryProduct");
                });

            modelBuilder.Entity("LabelProduct", b =>
                {
                    b.Property<int>("LabelsId")
                        .HasColumnType("int");

                    b.Property<string>("ProductsBarcode")
                        .HasColumnType("char(14)");

                    b.HasKey("LabelsId", "ProductsBarcode");

                    b.HasIndex("ProductsBarcode");

                    b.ToTable("LabelProduct");
                });

            modelBuilder.Entity("ProductStore", b =>
                {
                    b.Property<string>("ProductsBarcode")
                        .HasColumnType("char(14)");

                    b.Property<int>("VendorsId")
                        .HasColumnType("int");

                    b.HasKey("ProductsBarcode", "VendorsId");

                    b.HasIndex("VendorsId");

                    b.ToTable("ProductStore");
                });

            modelBuilder.Entity("ShopMate.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Aliases")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("ShopMate.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ShopMate.Models.Label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("ShopMate.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ProductBarcode")
                        .HasColumnType("char(14)");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductBarcode");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("ShopMate.Models.PriceModifier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kind")
                        .HasColumnType("int");

                    b.Property<string>("ProductBarcode")
                        .HasColumnType("char(14)");

                    b.Property<decimal>("Value")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("ProductBarcode");

                    b.ToTable("PriceModifier");
                });

            modelBuilder.Entity("ShopMate.Models.PriceModifierBreakdown", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ShoppingListId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingListId");

                    b.ToTable("PriceModifierBreakdown");
                });

            modelBuilder.Entity("ShopMate.Models.Product", b =>
                {
                    b.Property<string>("Barcode")
                        .HasColumnType("char(14)");

                    b.Property<long?>("AvailableStock")
                        .HasColumnType("bigint");

                    b.Property<bool>("Edible")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("OriginCountry")
                        .HasColumnType("char(2)");

                    b.Property<string>("Pictures")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<long>("TimesSold")
                        .HasColumnType("bigint");

                    b.Property<int?>("Units")
                        .HasColumnType("int");

                    b.Property<double?>("Volume")
                        .HasColumnType("float");

                    b.Property<double?>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Barcode");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ShopMate.Models.ShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("SubtotalPrice")
                        .HasColumnType("money");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("ShoppingLists");
                });

            modelBuilder.Entity("ShopMate.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("char(3)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("BrandProduct", b =>
                {
                    b.HasOne("ShopMate.Models.Brand", null)
                        .WithMany()
                        .HasForeignKey("BrandsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopMate.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsBarcode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("ShopMate.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopMate.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsBarcode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LabelProduct", b =>
                {
                    b.HasOne("ShopMate.Models.Label", null)
                        .WithMany()
                        .HasForeignKey("LabelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopMate.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsBarcode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductStore", b =>
                {
                    b.HasOne("ShopMate.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsBarcode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopMate.Models.Store", null)
                        .WithMany()
                        .HasForeignKey("VendorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShopMate.Models.Position", b =>
                {
                    b.HasOne("ShopMate.Models.Product", null)
                        .WithMany("Positions")
                        .HasForeignKey("ProductBarcode");
                });

            modelBuilder.Entity("ShopMate.Models.PriceModifier", b =>
                {
                    b.HasOne("ShopMate.Models.Product", null)
                        .WithMany("PriceModifiers")
                        .HasForeignKey("ProductBarcode");
                });

            modelBuilder.Entity("ShopMate.Models.PriceModifierBreakdown", b =>
                {
                    b.HasOne("ShopMate.Models.ShoppingList", null)
                        .WithMany("ModifierBreakdowns")
                        .HasForeignKey("ShoppingListId");
                });

            modelBuilder.Entity("ShopMate.Models.Product", b =>
                {
                    b.Navigation("Positions");

                    b.Navigation("PriceModifiers");
                });

            modelBuilder.Entity("ShopMate.Models.ShoppingList", b =>
                {
                    b.Navigation("ModifierBreakdowns");
                });
#pragma warning restore 612, 618
        }
    }
}
