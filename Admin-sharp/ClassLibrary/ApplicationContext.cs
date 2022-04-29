using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ClassLibrary
{

    public partial class ApplicationContext : DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<EmployeeOfCompany> EmployeeOfCompanies { get; set; }
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
        public virtual DbSet<Guarantee> Guarantees { get; set; }
        public virtual DbSet<ListOfSupportedModel> ListOfSupportedModels { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<PhoneModel> PhoneModels { get; set; }
        public virtual DbSet<PositionInOrder> PositionInOrders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PushareAgreement> PushareAgreements { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<SuppliedProduct> SuppliedProducts { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }
        public virtual DbSet<SupplyOrder> SupplyOrders { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.Migrate();
            Context.AddDb(this);
        }
        public static DbContextOptions<ApplicationContext> GetDb()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            return optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=sopct;Username=postgres;Password=123").Options;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=sopct;Username=postgres;Password=123");
                Context.InitDb();
                /*
                //string consting = ConfigurationManager.AppSettings["ConnectionString"];
                //optionsBuilder.UseNpgsql(""+consting);
                //Add-Migration Init - инициализация миграций
                //Remove-Migration
                //Update-Database - применение миграций

                Scaffold-DbContext "host=localhost;port=5432;database=sopct;username=postgres;password=123" npgsql.entityframeworkcore.postgresql
                -Tables "product"

                */
            }
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public ApplicationContext() : base()
        {
        }

    }
}
