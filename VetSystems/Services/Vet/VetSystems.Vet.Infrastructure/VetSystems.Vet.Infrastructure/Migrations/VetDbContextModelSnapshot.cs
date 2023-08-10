﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VetSystems.Vet.Infrastructure.Persistence;

#nullable disable

namespace VetSystems.Vet.Infrastructure.Migrations
{
    [DbContext(typeof(VetDbContext))]
    partial class VetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VetSystems.Vet.Domain.Entities.Adress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("county");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdate");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit")
                        .HasColumnName("deleted");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("district");

                    b.Property<string>("LongAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("longadress");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("province");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedate");

                    b.HasKey("Id")
                        .HasName("pk_adress");

                    b.ToTable("adress", (string)null);
                });

            modelBuilder.Entity("VetSystems.Vet.Domain.Entities.Customers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("AdressId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("adressid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdate");

                    b.Property<Guid?>("CustomerGroup")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("customergroup");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit")
                        .HasColumnName("deleted");

                    b.Property<decimal>("DiscountRate")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("discountrate");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("firstname");

                    b.Property<bool?>("IsEmail")
                        .HasColumnType("bit")
                        .HasColumnName("isemail");

                    b.Property<bool?>("IsPhone")
                        .HasColumnType("bit")
                        .HasColumnName("isphone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("lastname");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("note");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phonenumber");

                    b.Property<string>("PhoneNumber2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phonenumber2");

                    b.Property<string>("TaxOffice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("taxoffice");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedate");

                    b.Property<string>("VKNTCNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("vkntcno");

                    b.HasKey("Id")
                        .HasName("customers_pkey");

                    b.HasIndex("AdressId")
                        .HasDatabaseName("ix_customers_adressid");

                    b.ToTable("customers", (string)null);
                });

            modelBuilder.Entity("VetSystems.Vet.Domain.Entities.Patients", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<int>("AnimalBreed")
                        .HasColumnType("int")
                        .HasColumnName("animalbreed");

                    b.Property<int>("AnimalColor")
                        .HasColumnType("int")
                        .HasColumnName("animalcolor");

                    b.Property<int>("AnimalType")
                        .HasColumnType("int")
                        .HasColumnName("animaltype");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birthdate");

                    b.Property<string>("ChipNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("chipnumber");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdate");

                    b.Property<Guid>("CustomersId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("customersid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit")
                        .HasColumnName("deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("ReportNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("reportnumber");

                    b.Property<int>("Sex")
                        .HasColumnType("int")
                        .HasColumnName("sex");

                    b.Property<string>("SpecialNote")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("specialnote");

                    b.Property<bool>("Sterilization")
                        .HasColumnType("bit")
                        .HasColumnName("sterilization");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedate");

                    b.HasKey("Id")
                        .HasName("pk_patients");

                    b.HasIndex("CustomersId")
                        .HasDatabaseName("ix_patients_customersid");

                    b.ToTable("patients", (string)null);
                });

            modelBuilder.Entity("VetSystems.Vet.Domain.Entities.ProductCategories", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("CategoryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("categorycode");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdate");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit")
                        .HasColumnName("deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedate");

                    b.HasKey("Id")
                        .HasName("ProductCategories_pkey");

                    b.ToTable("productcategories", (string)null);
                });

            modelBuilder.Entity("VetSystems.Vet.Domain.Entities.Products", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<bool?>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("active");

                    b.Property<bool?>("BuyingIncludeKDV")
                        .HasColumnType("bit")
                        .HasColumnName("buyingincludekdv");

                    b.Property<decimal>("BuyingPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("buyingprice");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("categoryid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdate");

                    b.Property<decimal>("CriticalAmount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("criticalamount");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit")
                        .HasColumnName("deleted");

                    b.Property<bool?>("FixPrice")
                        .HasColumnType("bit")
                        .HasColumnName("fixprice");

                    b.Property<bool?>("IsExpirationDate")
                        .HasColumnType("bit")
                        .HasColumnName("isexpirationdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("ProductBarcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("productbarcode");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("productcode");

                    b.Property<Guid?>("ProductTypeId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("producttypeid");

                    b.Property<decimal>("Ratio")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ratio");

                    b.Property<bool?>("SellingIncludeKDV")
                        .HasColumnType("bit")
                        .HasColumnName("sellingincludekdv");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("sellingprice");

                    b.Property<Guid?>("SupplierId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("supplierid");

                    b.Property<Guid?>("UnitId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("unitid");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updatedate");

                    b.HasKey("Id")
                        .HasName("products_pkey");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("VetSystems.Vet.Domain.Entities.Customers", b =>
                {
                    b.HasOne("VetSystems.Vet.Domain.Entities.Adress", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_customers_adress_adressid");

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("VetSystems.Vet.Domain.Entities.Patients", b =>
                {
                    b.HasOne("VetSystems.Vet.Domain.Entities.Customers", "Customers")
                        .WithMany("Patients")
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_patients_customers_customersid");

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("VetSystems.Vet.Domain.Entities.Customers", b =>
                {
                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
