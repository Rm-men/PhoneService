using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace ClassLibrary
{
    public partial class ApplicationContext : DbContext
    {
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
                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");
                entity.Property(e => e.Family)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("family");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("name");
                entity.Property(e => e.Patronymic)
                    .HasMaxLength(45)
                    .HasColumnName("patronymic");
                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.HasKey(e => e.IdComponent)
                    .HasName("component_pkey");
                entity.ToTable("component");
                entity.Property(e => e.IdComponent)
                    .HasMaxLength(25)
                    .HasColumnName("id_component");
                entity.Property(e => e.IdGuarantee)
                    .HasMaxLength(15)
                    .HasColumnName("id_guarantee");
                entity.Property(e => e.IdProduct)
                    .HasMaxLength(40)
                    .HasColumnName("id_product");
                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("manufacturer");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("name");
                entity.Property(e => e.TypeC)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("type_c");
                entity.HasOne(d => d.IdGuaranteeNavigation)
                    .WithMany(p => p.Components)
                    .HasForeignKey(d => d.IdGuarantee)
                    .HasConstraintName("fk_comp_guarantee");
                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Components)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("fk_comp_id_product");

                entity.HasOne(d => d.ManufacturerNavigation)
                    .WithMany(p => p.Components)
                    .HasForeignKey(d => d.Manufacturer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_comp_manufacturer");
            });

            modelBuilder.Entity<EmployeeOfCompany>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("employee_of_company_pkey");
                entity.ToTable("employee_of_company");
                entity.HasIndex(e => e.IdEmploymentContract, "employee_of_company_id_employment_contract_key")
                    .IsUnique();
                entity.HasIndex(e => e.Login, "employee_of_company_login_key")
                    .IsUnique();
                entity.HasIndex(e => e.PassportNubmer, "employee_of_company_passport_nubmer_key")
                    .IsUnique();
                entity.HasIndex(e => e.PassportSerial, "employee_of_company_passport_serial_key")
                    .IsUnique();
                entity.HasIndex(e => e.Password, "employee_of_company_password_key")
                    .IsUnique();
                entity.HasIndex(e => e.Phone, "employee_of_company_phone_number_key")
                    .IsUnique();
                entity.Property(e => e.IdEmployee)
                    .HasMaxLength(8)
                    .HasColumnName("id_employee");
                entity.Property(e => e.Adres).HasColumnName("adres");
                entity.Property(e => e.DateOfEmployment)
                    .HasColumnType("date")
                    .HasColumnName("date_of_employment");
                entity.Property(e => e.Family)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("family");
                entity.Property(e => e.IdEmployeeType)
                    .HasMaxLength(15)
                    .HasColumnName("id_employee_type");
                entity.Property(e => e.IdEmploymentContract)
                    .HasMaxLength(8)
                    .HasColumnName("id_employment_contract");
                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("login")
                    .HasDefaultValueSql("NULL::character varying");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");
                entity.Property(e => e.NameStore)
                    .HasMaxLength(35)
                    .HasColumnName("name_store");

                entity.Property(e => e.PassportNubmer)
                    .HasPrecision(6)
                    .HasColumnName("passport_nubmer");

                entity.Property(e => e.PassportSerial)
                    .HasPrecision(4)
                    .HasColumnName("passport_serial");

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
                    .HasColumnName("phone_number");

                entity.HasOne(d => d.IdEmployeeTypeNavigation)
                    .WithMany(p => p.EmployeeOfCompanies)
                    .HasForeignKey(d => d.IdEmployeeType)
                    .HasConstraintName("fk_emp_type");

                entity.HasOne(d => d.NameStoreNavigation)
                    .WithMany(p => p.EmployeeOfCompanies)
                    .HasForeignKey(d => d.NameStore)
                    .HasConstraintName("fk_emp_store");
            });

            modelBuilder.Entity<EmployeeType>(entity =>
            {
                entity.HasKey(e => e.IdEmployeeType)
                    .HasName("employee_type_pkey");

                entity.ToTable("employee_type");

                entity.Property(e => e.IdEmployeeType)
                    .HasMaxLength(15)
                    .HasColumnName("id_employee_type");

                entity.Property(e => e.ResponsibleDescription)
                    .IsRequired()
                    .HasColumnName("responsible_description");
            });

            modelBuilder.Entity<Guarantee>(entity =>
            {
                entity.HasKey(e => e.IdGuarantee)
                    .HasName("guarantee_pkey");

                entity.ToTable("guarantee");

                entity.Property(e => e.IdGuarantee)
                    .HasMaxLength(10)
                    .HasColumnName("id_guarantee");

                entity.Property(e => e.GarrantyConditions).HasColumnName("garranty_conditions");

                entity.Property(e => e.GarrantyPeriodInMonths).HasColumnName("garranty_period_in_months");
            });

            modelBuilder.Entity<ListOfSupportedModel>(entity =>
            {
                entity.HasKey(e => e.IdListOfSupModels)
                    .HasName("list_of_supported_models_pkey");

                entity.ToTable("list_of_supported_models");

                entity.Property(e => e.IdListOfSupModels)
                    .HasMaxLength(5)
                    .HasColumnName("id_list_of_sup_models");

                entity.Property(e => e.IdComponent)
                    .HasMaxLength(25)
                    .HasColumnName("id_component");

                entity.Property(e => e.IdPhoneModel)
                    .HasMaxLength(25)
                    .HasColumnName("id_phone_model");

                entity.Property(e => e.ListSupmodelName)
                    .HasMaxLength(25)
                    .HasColumnName("list_supmodel_name");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasKey(e => e.IdManufacturer)
                    .HasName("manufacturer_pkey");

                entity.ToTable("manufacturer");

                entity.HasIndex(e => e.Name, "manufacturer_name_key")
                    .IsUnique();

                entity.Property(e => e.IdManufacturer)
                    .HasMaxLength(25)
                    .HasColumnName("id_manufacturer");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("order__pkey");

                entity.ToTable("order_");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.IdOrderStatus)
                    .HasMaxLength(10)
                    .HasColumnName("id_order_status");

                entity.Property(e => e.OrderDate).HasColumnName("order_date");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(11)
                    .HasColumnName("phone_number");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("fk_ord_client");

                entity.HasOne(d => d.IdOrderStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdOrderStatus)
                    .HasConstraintName("fk_ord_ordstat");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.IdOrderStatus)
                    .HasName("order_status_pkey");

                entity.ToTable("order_status");

                entity.Property(e => e.IdOrderStatus)
                    .HasMaxLength(10)
                    .HasColumnName("id_order_status");

                entity.Property(e => e.DescriptionOrderStatus)
                    .HasMaxLength(25)
                    .HasColumnName("description_order_status");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasKey(e => e.Imei)
                    .HasName("phone_pkey");

                entity.ToTable("phone");

                entity.Property(e => e.Imei)
                    .HasMaxLength(17)
                    .HasColumnName("imei");

                entity.Property(e => e.IdPhoneModel)
                    .HasMaxLength(25)
                    .HasColumnName("id_phone_model");
            });

            modelBuilder.Entity<PhoneModel>(entity =>
            {
                entity.HasKey(e => e.IdPhoneModel)
                    .HasName("phone_model_pkey");

                entity.ToTable("phone_model");

                entity.Property(e => e.IdPhoneModel)
                    .HasMaxLength(25)
                    .HasColumnName("id_phone_model");

                entity.Property(e => e.GuaranteePhoneModel)
                    .HasMaxLength(15)
                    .HasColumnName("guarantee_phone_model");

                entity.Property(e => e.IdProduct)
                    .HasMaxLength(40)
                    .HasColumnName("id_product");

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(25)
                    .HasColumnName("manufacturer");

                entity.Property(e => e.NameModel)
                    .IsRequired()
                    .HasMaxLength(35)
                    .HasColumnName("name_model");

                entity.Property(e => e.Specifications)
                    .IsRequired()
                    .HasColumnName("specifications");

                entity.HasOne(d => d.GuaranteePhoneModelNavigation)
                    .WithMany(p => p.PhoneModels)
                    .HasForeignKey(d => d.GuaranteePhoneModel)
                    .HasConstraintName("fk_phmod_guarante");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.PhoneModels)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("fk_phmod_id_product");

                entity.HasOne(d => d.ManufacturerNavigation)
                    .WithMany(p => p.PhoneModels)
                    .HasForeignKey(d => d.Manufacturer)
                    .HasConstraintName("fk_phmod_manufacturer");
            });

            modelBuilder.Entity<PositionInOrder>(entity =>
            {
                entity.HasKey(e => new { e.IdPosition, e.IdPushareAgreement })
                    .HasName("pk_pos_listgoods");

                entity.ToTable("position_in_order");

                entity.Property(e => e.IdPosition)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_position");

                entity.Property(e => e.IdPushareAgreement).HasColumnName("id_pushare_agreement");

                entity.Property(e => e.CountStaf).HasColumnName("count_staf");

                entity.Property(e => e.IdProduct)
                    .HasMaxLength(40)
                    .HasColumnName("id_product");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.PositionInOrders)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("fk_pos_product");

                entity.HasOne(d => d.IdPushareAgreementNavigation)
                    .WithMany(p => p.PositionInOrders)
                    .HasForeignKey(d => d.IdPushareAgreement)
                    .HasConstraintName("fk_pos_pushagree");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("product_pkey");

                entity.ToTable("product");

                entity.Property(e => e.IdProduct)
                    .HasMaxLength(40)
                    .HasColumnName("id_product");

                entity.Property(e => e.Counts).HasColumnName("counts");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<PushareAgreement>(entity =>
            {
                entity.HasKey(e => e.IdPushareAgreement)
                    .HasName("pushare_agreement_pkey");

                entity.ToTable("pushare_agreement");

                entity.Property(e => e.IdPushareAgreement).HasColumnName("id_pushare_agreement");

                entity.Property(e => e.AllCost)
                    .HasColumnType("money")
                    .HasColumnName("all_cost");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.NameStore)
                    .HasMaxLength(35)
                    .HasColumnName("name_store");

                entity.Property(e => e.Paid)
                    .HasColumnName("paid")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.PushareAgreementDate).HasColumnName("pushare_agreement_date");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.PushareAgreements)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("fk_pa_id_client");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.PushareAgreements)
                    .HasForeignKey(d => d.IdOrder)
                    .HasConstraintName("fk_pa_order");

                entity.HasOne(d => d.NameStoreNavigation)
                    .WithMany(p => p.PushareAgreements)
                    .HasForeignKey(d => d.NameStore)
                    .HasConstraintName("fk_pa_shop");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.HasKey(e => e.NameStore)
                    .HasName("shop_pkey");

                entity.ToTable("shop");

                entity.Property(e => e.NameStore)
                    .HasMaxLength(35)
                    .HasColumnName("name_store");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");
            });

            modelBuilder.Entity<SuppliedProduct>(entity =>
            {
                entity.HasKey(e => new { e.IdSuppply, e.IdProduct })
                    .HasName("pk_supplied_product");

                entity.ToTable("supplied_product");

                entity.Property(e => e.IdSuppply).HasColumnName("id_suppply");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.NameStore)
                    .IsRequired()
                    .HasMaxLength(35)
                    .HasColumnName("name_store");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.HasOne(d => d.IdSuppplyNavigation)
                    .WithMany(p => p.SuppliedProducts)
                    .HasForeignKey(d => d.IdSuppply)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_suplgod_supply");

                entity.HasOne(d => d.NameStoreNavigation)
                    .WithMany(p => p.SuppliedProducts)
                    .HasForeignKey(d => d.NameStore)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pa_shop");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.IdSupplier)
                    .HasName("supplier_pkey");

                entity.ToTable("supplier");

                entity.Property(e => e.IdSupplier)
                    .HasMaxLength(25)
                    .HasColumnName("id_supplier");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnName("adress");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Supply>(entity =>
            {
                entity.HasKey(e => e.IdSupply)
                    .HasName("supply_pkey");

                entity.ToTable("supply");

                entity.Property(e => e.IdSupply).HasColumnName("id_supply");

                entity.Property(e => e.DateSupply).HasColumnName("date_supply");

                entity.Property(e => e.DescriptionSupply).HasColumnName("description_supply");

                entity.Property(e => e.IdSupplier)
                    .HasMaxLength(15)
                    .HasColumnName("id_supplier");

                entity.Property(e => e.IdSupplyOrder).HasColumnName("id_supply_order");

                entity.Property(e => e.PriceSupply)
                    .HasColumnType("money")
                    .HasColumnName("price_supply");

                entity.HasOne(d => d.IdSupplierNavigation)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.IdSupplier)
                    .HasConstraintName("fk_supply_supplier");

                entity.HasOne(d => d.IdSupplyOrderNavigation)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.IdSupplyOrder)
                    .HasConstraintName("fk_supply_supplorder");
            });

            modelBuilder.Entity<SupplyOrder>(entity =>
            {
                entity.HasKey(e => e.IdSupplyOrder)
                    .HasName("supply_order_pkey");

                entity.ToTable("supply_order");

                entity.Property(e => e.IdSupplyOrder).HasColumnName("id_supply_order");

                entity.Property(e => e.DateSuplOrder).HasColumnName("date_supl_order");

                entity.Property(e => e.IdEmployee)
                    .HasMaxLength(10)
                    .HasColumnName("id_employee");
            });

            OnModelCreatingPartial(modelBuilder);
        }

    }
}
