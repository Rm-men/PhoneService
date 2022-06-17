using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

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

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<ComponentsComplibility> ComponentsComplibilities { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeesView> EmployeesViews { get; set; }
        public virtual DbSet<Guarantee> Guarantees { get; set; }
        public virtual DbSet<ListSirvice> ListSirvices { get; set; }
        public virtual DbSet<ListWorkshop> ListWorkshops { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<OnOrderCmp> OnOrderCmps { get; set; }
        public virtual DbSet<OnOrderSrv> OnOrderSrvs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<OrdersView> OrdersViews { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<PhoneModel> PhoneModels { get; set; }
        public virtual DbSet<StoryOrderMove> StoryOrderMoves { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("host=localhost;port=5432;database=work100024;username=work100024;password=iS~pLC*gmrAgl6aJ1pL7");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("client_pkey");

                entity.ToTable("client");

                entity.HasIndex(e => e.Email, "client_email_key")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "client_phone_key")
                    .IsUnique();

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.Clpassword)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("clpassword");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Family)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("family");

                entity.Property(e => e.Namecl)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("namecl");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(45)
                    .HasColumnName("patronymic");

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.HasKey(e => e.IdComponent)
                    .HasName("component_pkey");

                entity.ToTable("component");

                entity.Property(e => e.IdComponent).HasColumnName("id_component");

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IdGuaranteecmp).HasColumnName("id_guaranteecmp");

                entity.Property(e => e.Manufacturercmp).HasColumnName("manufacturercmp");

                entity.Property(e => e.Namecmp)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("namecmp");

                entity.Property(e => e.Pricecmp)
                    .HasPrecision(12, 2)
                    .HasColumnName("pricecmp");

                entity.Property(e => e.Typecmp)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("typecmp");

                entity.HasOne(d => d.IdGuaranteecmpNavigation)
                    .WithMany(p => p.Components)
                    .HasForeignKey(d => d.IdGuaranteecmp)
                    .HasConstraintName("fk_comp_guarantee");

                entity.HasOne(d => d.ManufacturercmpNavigation)
                    .WithMany(p => p.Components)
                    .HasForeignKey(d => d.Manufacturercmp)
                    .HasConstraintName("fk_comp_manufacturer");
            });

            modelBuilder.Entity<ComponentsComplibility>(entity =>
            {
                entity.HasKey(e => e.Idcc)
                    .HasName("components_complibility_pkey");

                entity.ToTable("components_complibility");

                entity.Property(e => e.Idcc).HasColumnName("idcc");

                entity.Property(e => e.IdComponent).HasColumnName("id_component");

                entity.Property(e => e.IdPhmodel).HasColumnName("id_phmodel");

                entity.HasOne(d => d.IdComponentNavigation)
                    .WithMany(p => p.ComponentsComplibilities)
                    .HasForeignKey(d => d.IdComponent)
                    .HasConstraintName("fk_cc_c");

                entity.HasOne(d => d.IdPhmodelNavigation)
                    .WithMany(p => p.ComponentsComplibilities)
                    .HasForeignKey(d => d.IdPhmodel)
                    .HasConstraintName("fk_cc_p");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasIndex(e => e.IdContract, "employee_id_contract_key")
                    .IsUnique();

                entity.HasIndex(e => e.Login, "employee_login_key")
                    .IsUnique();

                entity.HasIndex(e => e.Paspnumber, "employee_paspnumber_key")
                    .IsUnique();

                entity.HasIndex(e => e.Paspserial, "employee_paspserial_key")
                    .IsUnique();

                entity.HasIndex(e => e.Password, "employee_password_key")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "employee_phone_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dateemploymentet)
                    .HasColumnType("date")
                    .HasColumnName("dateemploymentet");

                entity.Property(e => e.Empaddress).HasColumnName("empaddress");

                entity.Property(e => e.Family)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("family");

                entity.Property(e => e.IdContract)
                    .HasMaxLength(8)
                    .HasColumnName("id_contract");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("login")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Paspnumber)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("paspnumber");

                entity.Property(e => e.Paspserial)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("paspserial");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("password")
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(30)
                    .HasColumnName("patronymic");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("phone");

                entity.Property(e => e.Type)
                    .HasMaxLength(15)
                    .HasColumnName("type");

                entity.Property(e => e.Workshop).HasColumnName("workshop");

                entity.HasOne(d => d.WorkshopNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Workshop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_emp_store");
            });

            modelBuilder.Entity<EmployeesView>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("employees_view");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Dateemploymentet)
                    .HasColumnType("date")
                    .HasColumnName("dateemploymentet");

                entity.Property(e => e.Empaddress).HasColumnName("empaddress");

                entity.Property(e => e.Family)
                    .HasMaxLength(30)
                    .HasColumnName("family");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdContract)
                    .HasMaxLength(8)
                    .HasColumnName("id_contract");

                entity.Property(e => e.Login)
                    .HasMaxLength(64)
                    .HasColumnName("login");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Paspnumber)
                    .HasMaxLength(6)
                    .HasColumnName("paspnumber");

                entity.Property(e => e.Paspserial)
                    .HasMaxLength(4)
                    .HasColumnName("paspserial");

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .HasColumnName("password");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(30)
                    .HasColumnName("patronymic");

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .HasColumnName("phone");

                entity.Property(e => e.Type)
                    .HasMaxLength(15)
                    .HasColumnName("type");

                entity.Property(e => e.Workshop).HasColumnName("workshop");
            });

            modelBuilder.Entity<Guarantee>(entity =>
            {
                entity.HasKey(e => e.IdGuarantee)
                    .HasName("guarantee_pkey");

                entity.ToTable("guarantee");

                entity.Property(e => e.IdGuarantee).HasColumnName("id_guarantee");

                entity.Property(e => e.Conditions).HasColumnName("conditions");

                entity.Property(e => e.Period).HasColumnName("period");
            });

            modelBuilder.Entity<ListSirvice>(entity =>
            {
                entity.ToTable("list_sirvices");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Costsrv)
                    .HasPrecision(12, 2)
                    .HasColumnName("costsrv");

                entity.Property(e => e.Descriptionsrv).HasColumnName("descriptionsrv");

                entity.Property(e => e.Namesrv)
                    .HasMaxLength(55)
                    .HasColumnName("namesrv");

                entity.Property(e => e.Timesrv).HasColumnName("timesrv");

                entity.Property(e => e.Typesrv)
                    .HasMaxLength(25)
                    .HasColumnName("typesrv");
            });

            modelBuilder.Entity<ListWorkshop>(entity =>
            {
                entity.ToTable("list_workshops");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasKey(e => e.IdManufacturer)
                    .HasName("manufacturer_pkey");

                entity.ToTable("manufacturer");

                entity.HasIndex(e => e.Name, "manufacturer_name_key")
                    .IsUnique();

                entity.Property(e => e.IdManufacturer).HasColumnName("id_manufacturer");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<OnOrderCmp>(entity =>
            {
                entity.HasKey(e => e.IdCmpOnord)
                    .HasName("on_order_cmp_pkey");

                entity.ToTable("on_order_cmp");

                entity.Property(e => e.IdCmpOnord).HasColumnName("id_cmp_onord");

                entity.Property(e => e.IdCmpOnlist).HasColumnName("id_cmp_onlist");

                entity.Property(e => e.IdOrderForcomp).HasColumnName("id_order_forcomp");

                entity.HasOne(d => d.IdCmpOnlistNavigation)
                    .WithMany(p => p.OnOrderCmps)
                    .HasForeignKey(d => d.IdCmpOnlist)
                    .HasConstraintName("fk_cmponorder_component");

                entity.HasOne(d => d.IdOrderForcompNavigation)
                    .WithMany(p => p.OnOrderCmps)
                    .HasForeignKey(d => d.IdOrderForcomp)
                    .HasConstraintName("fk_cmponorder_order");
            });

            modelBuilder.Entity<OnOrderSrv>(entity =>
            {
                entity.HasKey(e => e.IdSrvOnord)
                    .HasName("on_order_srv_pkey");

                entity.ToTable("on_order_srv");

                entity.Property(e => e.IdSrvOnord).HasColumnName("id_srv_onord");

                entity.Property(e => e.IdOrderForservice).HasColumnName("id_order_forservice");

                entity.Property(e => e.IdSrvOnlist).HasColumnName("id_srv_onlist");

                entity.HasOne(d => d.IdOrderForserviceNavigation)
                    .WithMany(p => p.OnOrderSrvs)
                    .HasForeignKey(d => d.IdOrderForservice)
                    .HasConstraintName("fk_cmponorder_order");

                entity.HasOne(d => d.IdSrvOnlistNavigation)
                    .WithMany(p => p.OnOrderSrvs)
                    .HasForeignKey(d => d.IdSrvOnlist)
                    .HasConstraintName("fk_cmponorder_component");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("orders_pkey");

                entity.ToTable("orders");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Agreement)
                    .HasColumnName("agreement")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Comments).HasColumnName("comments");

                entity.Property(e => e.Dateord).HasColumnName("dateord");

                entity.Property(e => e.Descriptionord).HasColumnName("descriptionord");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.IdMaster).HasColumnName("id_master");

                entity.Property(e => e.IdOrderStatus)
                    .HasMaxLength(10)
                    .HasColumnName("id_order_status")
                    .HasDefaultValueSql("'add_0'::character varying");

                entity.Property(e => e.IdPhone).HasColumnName("id_phone");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(11)
                    .HasColumnName("phonenumber");

                entity.Property(e => e.Priceord)
                    .HasPrecision(12, 2)
                    .HasColumnName("priceord")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("fk_ord_client");

                entity.HasOne(d => d.IdOrderStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdOrderStatus)
                    .HasConstraintName("fk_ord_ordstat");

                entity.HasOne(d => d.IdPhoneNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdPhone)
                    .HasConstraintName("fk_ord_phonee");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.Idos)
                    .HasName("order_status_pkey");

                entity.ToTable("order_status");

                entity.Property(e => e.Idos)
                    .HasMaxLength(10)
                    .HasColumnName("idos");

                entity.Property(e => e.Descriptionos).HasColumnName("descriptionos");

                entity.Property(e => e.LogicalSequence)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("logical_sequence");
            });

            modelBuilder.Entity<OrdersView>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("orders_view");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Agreement).HasColumnName("agreement");

                entity.Property(e => e.Comments).HasColumnName("comments");

                entity.Property(e => e.Contacts).HasColumnName("contacts");

                entity.Property(e => e.Dateord).HasColumnName("dateord");

                entity.Property(e => e.Descriptionord).HasColumnName("descriptionord");

                entity.Property(e => e.Descriptionos).HasColumnName("descriptionos");

                entity.Property(e => e.Family)
                    .HasMaxLength(45)
                    .HasColumnName("family");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.IdMaster).HasColumnName("id_master");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.IdOrderStatus)
                    .HasMaxLength(10)
                    .HasColumnName("id_order_status");

                entity.Property(e => e.IdPhone).HasColumnName("id_phone");

                entity.Property(e => e.Namecl)
                    .HasMaxLength(25)
                    .HasColumnName("namecl");

                entity.Property(e => e.Namephone).HasColumnName("namephone");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(45)
                    .HasColumnName("patronymic");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(11)
                    .HasColumnName("phonenumber");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("phone");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdPhoneModel).HasColumnName("id_phone_model");

                entity.Property(e => e.Imei)
                    .HasMaxLength(17)
                    .HasColumnName("imei");

                entity.HasOne(d => d.IdPhoneModelNavigation)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.IdPhoneModel)
                    .HasConstraintName("fk_phone_phmodel");
            });

            modelBuilder.Entity<PhoneModel>(entity =>
            {
                entity.HasKey(e => e.IdPhoneModel)
                    .HasName("phone_model_pkey");

                entity.ToTable("phone_model");

                entity.Property(e => e.IdPhoneModel).HasColumnName("id_phone_model");

                entity.Property(e => e.Guarantee).HasColumnName("guarantee");

                entity.Property(e => e.Manufacturer).HasColumnName("manufacturer");

                entity.Property(e => e.Namephone)
                    .IsRequired()
                    .HasColumnName("namephone");

                entity.Property(e => e.Specifications)
                    .IsRequired()
                    .HasColumnName("specifications");

                entity.HasOne(d => d.GuaranteeNavigation)
                    .WithMany(p => p.PhoneModels)
                    .HasForeignKey(d => d.Guarantee)
                    .HasConstraintName("fk_phmod_guarante");

                entity.HasOne(d => d.ManufacturerNavigation)
                    .WithMany(p => p.PhoneModels)
                    .HasForeignKey(d => d.Manufacturer)
                    .HasConstraintName("fk_phmod_manufacturer");
            });

            modelBuilder.Entity<StoryOrderMove>(entity =>
            {
                entity.HasKey(e => e.Idmove)
                    .HasName("story_order_move_pkey");

                entity.ToTable("story_order_move");

                entity.Property(e => e.Idmove).HasColumnName("idmove");

                entity.Property(e => e.Idhuman).HasColumnName("idhuman");

                entity.Property(e => e.Idnewaddress).HasColumnName("idnewaddress");

                entity.Property(e => e.Idnewstatus)
                    .HasMaxLength(10)
                    .HasColumnName("idnewstatus");

                entity.Property(e => e.Idoldaddress).HasColumnName("idoldaddress");

                entity.Property(e => e.Idoldstatus)
                    .HasMaxLength(10)
                    .HasColumnName("idoldstatus");

                entity.Property(e => e.Idorder).HasColumnName("idorder");

                entity.Property(e => e.Somdate)
                    .HasColumnName("somdate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.IdhumanNavigation)
                    .WithMany(p => p.StoryOrderMoves)
                    .HasForeignKey(d => d.Idhuman)
                    .HasConstraintName("fk_som_human");

                entity.HasOne(d => d.IdnewaddressNavigation)
                    .WithMany(p => p.StoryOrderMoveIdnewaddressNavigations)
                    .HasForeignKey(d => d.Idnewaddress)
                    .HasConstraintName("fk_som_newaddress");

                entity.HasOne(d => d.IdnewstatusNavigation)
                    .WithMany(p => p.StoryOrderMoveIdnewstatusNavigations)
                    .HasForeignKey(d => d.Idnewstatus)
                    .HasConstraintName("fk_som_newstatus");

                entity.HasOne(d => d.IdoldaddressNavigation)
                    .WithMany(p => p.StoryOrderMoveIdoldaddressNavigations)
                    .HasForeignKey(d => d.Idoldaddress)
                    .HasConstraintName("fk_som_oldaddress");

                entity.HasOne(d => d.IdoldstatusNavigation)
                    .WithMany(p => p.StoryOrderMoveIdoldstatusNavigations)
                    .HasForeignKey(d => d.Idoldstatus)
                    .HasConstraintName("fk_som_oldstatus");

                entity.HasOne(d => d.IdorderNavigation)
                    .WithMany(p => p.StoryOrderMoves)
                    .HasForeignKey(d => d.Idorder)
                    .HasConstraintName("fk_som_order");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
