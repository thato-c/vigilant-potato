﻿// <auto-generated />
using System;
using LicenceService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LicenceService.Migrations
{
    [DbContext(typeof(LicenceContext))]
    partial class LicenceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LicenceService.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("CompanyEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("LicenceService.Models.Licence", b =>
                {
                    b.Property<int>("LicenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LicenceId"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LicenceId");

                    b.ToTable("Licence", (string)null);
                });

            modelBuilder.Entity("LicenceService.Models.LicencePurchase", b =>
                {
                    b.Property<int>("PurchseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchseId"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("LicenceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("PurchseId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("LicenceId");

                    b.ToTable("LicencePurchase", (string)null);
                });

            modelBuilder.Entity("LicenceService.Models.LicencePurchase", b =>
                {
                    b.HasOne("LicenceService.Models.Company", "Company")
                        .WithMany("LicencePurchases")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LicenceService.Models.Licence", "Licence")
                        .WithMany("LicencePurchases")
                        .HasForeignKey("LicenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Licence");
                });

            modelBuilder.Entity("LicenceService.Models.Company", b =>
                {
                    b.Navigation("LicencePurchases");
                });

            modelBuilder.Entity("LicenceService.Models.Licence", b =>
                {
                    b.Navigation("LicencePurchases");
                });
#pragma warning restore 612, 618
        }
    }
}
