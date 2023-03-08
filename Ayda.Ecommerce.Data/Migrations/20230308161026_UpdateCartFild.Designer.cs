﻿// <auto-generated />
using System;
using Ayda.Ecommerce.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ayda.Ecommerce.Data.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230308161026_UpdateCartFild")]
    partial class UpdateCartFild
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Cart.Cart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<Guid>("BrowserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Finished")
                        .HasColumnType("bit");

                    b.Property<bool>("IsShow")
                        .HasColumnType("bit");

                    b.Property<int>("TotalSum")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Cart.CartItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CartId")
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsShow")
                        .HasColumnType("bit");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Ecommerce.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsShow")
                        .HasColumnType("bit");

                    b.Property<string>("LogoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Ecommerce.CategoryAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsShow")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryAttributes");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Ecommerce.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AllowCustomerComment")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiscountLableText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<string>("ImageCoverPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDiscount")
                        .HasColumnType("bit");

                    b.Property<bool>("IsShow")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSotialProduct")
                        .HasColumnType("bit");

                    b.Property<int?>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShowCount")
                        .HasColumnType("int");

                    b.Property<bool>("ShowOnHomepage")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.Property<int?>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Ecommerce.ProductAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AttributeId")
                        .HasColumnType("int");

                    b.Property<string>("AttributeValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsShow")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAttributes");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Ecommerce.ProductColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ColorHex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsShow")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductColors");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Ecommerce.ProductComment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsShow")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("ProductComments");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Ecommerce.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AltTagAttribute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsShow")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("TitleTagAttribute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Menu.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsShow")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Menu.SubMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsShow")
                        .HasColumnType("bit");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("SubMenus");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Slider.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsShow")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PossitionId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PossitionId");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Slider.Possition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsShow")
                        .HasColumnType("bit");

                    b.Property<string>("PossitionNameFA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProssitionNameEN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Possitions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9055),
                            IsShow = true,
                            PossitionNameFA = "بالا",
                            ProssitionNameEN = "UP"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9061),
                            IsShow = true,
                            PossitionNameFA = "پایین",
                            ProssitionNameEN = "BUTTOM"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9065),
                            IsShow = true,
                            PossitionNameFA = "چپ",
                            ProssitionNameEN = "LEFT"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9070),
                            IsShow = true,
                            PossitionNameFA = "راست",
                            ProssitionNameEN = "RIGHT"
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9073),
                            IsShow = true,
                            PossitionNameFA = "بالا - چپ",
                            ProssitionNameEN = "UP-LEFT"
                        },
                        new
                        {
                            Id = 6,
                            CreatedDate = new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9079),
                            IsShow = true,
                            PossitionNameFA = "بالا - راست",
                            ProssitionNameEN = "UP-RIGHT"
                        },
                        new
                        {
                            Id = 7,
                            CreatedDate = new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9082),
                            IsShow = true,
                            PossitionNameFA = "وسط",
                            ProssitionNameEN = "CENTER"
                        },
                        new
                        {
                            Id = 8,
                            CreatedDate = new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9086),
                            IsShow = true,
                            PossitionNameFA = "وسط - راست",
                            ProssitionNameEN = "CENTER-RIGHT"
                        },
                        new
                        {
                            Id = 9,
                            CreatedDate = new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9089),
                            IsShow = true,
                            PossitionNameFA = "وسط - چپ",
                            ProssitionNameEN = "CENTER-Left"
                        });
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Slider.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsShow")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PossitionId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PossitionId");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.User.ApplicationUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirm")
                        .HasColumnType("bit");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsShow")
                        .HasColumnType("bit");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastLoginDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LockoutEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrganizationEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("PhoneConfirm")
                        .HasColumnType("bit");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserPhone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("ApplicationUsers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedDate = new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(9017),
                            Email = "ganjalimeysam@gmail.com",
                            EmailConfirm = true,
                            FName = "Meysam",
                            Gender = 1,
                            IsActive = true,
                            IsLocked = false,
                            IsShow = true,
                            LName = "Ganjali",
                            OrganizationEmail = "GANJALIMEYSAM@GMAIL.COM",
                            Password = "AQAAAAEAACcQAAAAEHLLvck7ngDW6KasDTyqLUf0TKrznd20Lx2iGPMLAbppjjlfkLO+n+KYjeIXA/VduA==",
                            PhoneConfirm = true,
                            RoleId = 1,
                            UserPhone = "09187504331"
                        });
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.User.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsShow")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(8879),
                            IsShow = true,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 3, 8, 19, 40, 26, 522, DateTimeKind.Local).AddTicks(8925),
                            IsShow = true,
                            Name = "Employee"
                        });
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Cart.Cart", b =>
                {
                    b.HasOne("Ayda.Ecommerce.Domains.User.ApplicationUser", "ApplicationUser")
                        .WithMany("Carts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Cart.CartItem", b =>
                {
                    b.HasOne("Ayda.Ecommerce.Domains.Cart.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Ayda.Ecommerce.Domains.Ecommerce.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Ecommerce.Category", b =>
                {
                    b.HasOne("Ayda.Ecommerce.Domains.Ecommerce.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Ecommerce.CategoryAttribute", b =>
                {
                    b.HasOne("Ayda.Ecommerce.Domains.Ecommerce.Category", "Category")
                        .WithMany("CategoryAttributes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Ecommerce.Product", b =>
                {
                    b.HasOne("Ayda.Ecommerce.Domains.Ecommerce.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Ecommerce.ProductAttribute", b =>
                {
                    b.HasOne("Ayda.Ecommerce.Domains.Ecommerce.CategoryAttribute", "CategoryAttribute")
                        .WithMany("ProductAttributes")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Ayda.Ecommerce.Domains.Ecommerce.Product", "Product")
                        .WithMany("ProductAttributes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CategoryAttribute");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Ecommerce.ProductColor", b =>
                {
                    b.HasOne("Ayda.Ecommerce.Domains.Ecommerce.Product", "Product")
                        .WithMany("ProductColors")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Ecommerce.ProductComment", b =>
                {
                    b.HasOne("Ayda.Ecommerce.Domains.Ecommerce.Product", "Product")
                        .WithMany("ProductComments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Ayda.Ecommerce.Domains.User.ApplicationUser", "ApplicationUser")
                        .WithMany("ProductComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Ecommerce.ProductImage", b =>
                {
                    b.HasOne("Ayda.Ecommerce.Domains.Ecommerce.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Menu.SubMenu", b =>
                {
                    b.HasOne("Ayda.Ecommerce.Domains.Ecommerce.Category", "Category")
                        .WithMany("SubMenus")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Ayda.Ecommerce.Domains.Menu.MenuItem", "MenuItem")
                        .WithMany("SubMenus")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("MenuItem");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Slider.Banner", b =>
                {
                    b.HasOne("Ayda.Ecommerce.Domains.Slider.Possition", "Possition")
                        .WithMany("Banners")
                        .HasForeignKey("PossitionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Possition");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Slider.Slider", b =>
                {
                    b.HasOne("Ayda.Ecommerce.Domains.Slider.Possition", "Possition")
                        .WithMany("Sliders")
                        .HasForeignKey("PossitionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Possition");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.User.ApplicationUser", b =>
                {
                    b.HasOne("Ayda.Ecommerce.Domains.User.Role", "Role")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Cart.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Ecommerce.Category", b =>
                {
                    b.Navigation("CategoryAttributes");

                    b.Navigation("Products");

                    b.Navigation("SubCategories");

                    b.Navigation("SubMenus");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Ecommerce.CategoryAttribute", b =>
                {
                    b.Navigation("ProductAttributes");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Ecommerce.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("ProductAttributes");

                    b.Navigation("ProductColors");

                    b.Navigation("ProductComments");

                    b.Navigation("ProductImages");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Menu.MenuItem", b =>
                {
                    b.Navigation("SubMenus");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.Slider.Possition", b =>
                {
                    b.Navigation("Banners");

                    b.Navigation("Sliders");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.User.ApplicationUser", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("ProductComments");
                });

            modelBuilder.Entity("Ayda.Ecommerce.Domains.User.Role", b =>
                {
                    b.Navigation("ApplicationUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
