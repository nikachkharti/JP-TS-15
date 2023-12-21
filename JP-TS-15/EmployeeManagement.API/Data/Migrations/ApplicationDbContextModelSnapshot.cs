﻿// <auto-generated />
using System;
using EmployeeManagement.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeManagement.API.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeeManagement.API.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Nodari",
                            LastName = "Eqvtimishvili"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Guka",
                            LastName = "Shinjikashvili"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Aleksandre",
                            LastName = "Iosava"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Tako",
                            LastName = "Makhatadze"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Nika",
                            LastName = "Kuprashvili"
                        });
                });

            modelBuilder.Entity("EmployeeManagement.API.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(1974, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Microsoft"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(1976, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Apple"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(1946, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Sony"
                        });
                });

            modelBuilder.Entity("EmployeeManagement.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@gmail.com",
                            Password = "admin",
                            Role = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
