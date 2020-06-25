﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Multimark.Models;

namespace Multimark.Migrations
{
    [DbContext(typeof(MultimarkContext))]
    [Migration("20200624021533_new10")]
    partial class new10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Multimark.Models.Adm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.ToTable("Adms");
                });

            modelBuilder.Entity("Multimark.Models.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Multimark.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("AddressNumber");

                    b.Property<string>("CellPhone");

                    b.Property<string>("City");

                    b.Property<string>("Comments");

                    b.Property<string>("Cpf_Cnpj");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Neighborhood");

                    b.Property<string>("Rg");

                    b.Property<string>("TelePhone");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Multimark.Models.ItemSales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Price");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<int>("SalesId");

                    b.Property<double>("Subtotal");

                    b.HasKey("Id");

                    b.HasIndex("SalesId");

                    b.ToTable("ItemSales");
                });

            modelBuilder.Entity("Multimark.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoriesId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int>("Size");

                    b.HasKey("Id");

                    b.HasIndex("CategoriesId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Multimark.Models.Sales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Status");

                    b.Property<double>("Total");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Multimark.Models.ItemSales", b =>
                {
                    b.HasOne("Multimark.Models.Sales")
                        .WithMany("ItemSales")
                        .HasForeignKey("SalesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Multimark.Models.Product", b =>
                {
                    b.HasOne("Multimark.Models.Categories", "Categorie")
                        .WithMany("Products")
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Multimark.Models.Sales", b =>
                {
                    b.HasOne("Multimark.Models.Client", "Client")
                        .WithMany("Sales")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
