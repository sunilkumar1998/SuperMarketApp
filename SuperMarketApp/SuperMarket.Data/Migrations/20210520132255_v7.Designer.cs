// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SuperMarket.Data;

namespace SuperMarket.Data.Migrations
{
    [DbContext(typeof(SupermarketContext))]
    [Migration("20210520132255_v7")]
    partial class v7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SuperMarket.Domain.Address", b =>
                {
                    b.Property<int>("addressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("addressLine1")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("addressLine2")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<long>("pincode")
                        .HasMaxLength(6)
                        .HasColumnType("bigint");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("addressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("SuperMarket.Domain.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CategoryCode")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("SuperMarket.Domain.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ProductId")
                        .HasMaxLength(6)
                        .HasColumnType("integer");

                    b.Property<long>("Quantity")
                        .HasMaxLength(6)
                        .HasColumnType("bigint");

                    b.HasKey("InventoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("SuperMarket.Domain.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CategoryId")
                        .HasMaxLength(10)
                        .HasColumnType("integer");

                    b.Property<double>("CostPrice")
                        .HasMaxLength(15)
                        .HasColumnType("double precision");

                    b.Property<DateTime>("ExpiryDate")
                        .HasMaxLength(15)
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<double>("SellingPrice")
                        .HasMaxLength(15)
                        .HasColumnType("double precision");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SuperMarket.Domain.PurchaseOrder", b =>
                {
                    b.Property<int>("SupplierId")
                        .HasMaxLength(6)
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasMaxLength(6)
                        .HasColumnType("integer");

                    b.Property<DateTime>("Orderdate")
                        .HasMaxLength(11)
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PurchaseOrderId")
                        .HasColumnType("integer");

                    b.HasKey("SupplierId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("PurchaseOrder");
                });

            modelBuilder.Entity("SuperMarket.Domain.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("SuperMarket.Domain.Staff", b =>
                {
                    b.Property<int>("staffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("addressId")
                        .HasColumnType("integer");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("gender")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)");

                    b.Property<string>("lastname")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<long>("phone")
                        .HasMaxLength(10)
                        .HasColumnType("bigint");

                    b.Property<int>("roleId")
                        .HasColumnType("integer");

                    b.HasKey("staffId");

                    b.HasIndex("addressId");

                    b.HasIndex("roleId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("SuperMarket.Domain.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<long>("phone")
                        .HasMaxLength(10)
                        .HasColumnType("bigint");

                    b.HasKey("SupplierId");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("SuperMarket.Domain.Inventory", b =>
                {
                    b.HasOne("SuperMarket.Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SuperMarket.Domain.Product", b =>
                {
                    b.HasOne("SuperMarket.Domain.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SuperMarket.Domain.PurchaseOrder", b =>
                {
                    b.HasOne("SuperMarket.Domain.Product", "Product")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuperMarket.Domain.Supplier", "Supplier")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("SuperMarket.Domain.Staff", b =>
                {
                    b.HasOne("SuperMarket.Domain.Address", "Address")
                        .WithMany("Staff")
                        .HasForeignKey("addressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuperMarket.Domain.Role", "Role")
                        .WithMany("Staff")
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SuperMarket.Domain.Address", b =>
                {
                    b.Navigation("Staff");
                });

            modelBuilder.Entity("SuperMarket.Domain.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SuperMarket.Domain.Product", b =>
                {
                    b.Navigation("PurchaseOrders");
                });

            modelBuilder.Entity("SuperMarket.Domain.Role", b =>
                {
                    b.Navigation("Staff");
                });

            modelBuilder.Entity("SuperMarket.Domain.Supplier", b =>
                {
                    b.Navigation("PurchaseOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
