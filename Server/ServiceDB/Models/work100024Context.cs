using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ServiceDB.Models
{
    public partial class work100024Context : DbContext
    {
        public work100024Context()
        {
        }

        public work100024Context(DbContextOptions<work100024Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Component> Components { get; set; } = null!;
        public virtual DbSet<EmployeeOfCompany> EmployeeOfCompanies { get; set; } = null!;
        public virtual DbSet<Guarantee> Guarantees { get; set; } = null!;
        public virtual DbSet<ListOfSupportedModel> ListOfSupportedModels { get; set; } = null!;
        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<Phone> Phones { get; set; } = null!;
        public virtual DbSet<PhoneModel> PhoneModels { get; set; } = null!;
        public virtual DbSet<Workshop> Workshops { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("host=45.10.244.15;port=55532;database=work100024;username=work100024;password= iS~pLC*gmrAgl6aJ1pL7");
            }
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
