using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceDB.Models;

namespace ServiceDB;

internal static class EntityConfigure
{
    internal static void ClientConfigure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("client");
/*        builder.HasKey(e => e.IdClient)
                            .HasName("client_pkey");*/
        builder.HasIndex(e => e.Email, "client_email_key")
                            .IsUnique();
        builder.HasIndex(e => e.Phone, "client_phone_key")
                            .IsUnique();
        builder.Property(e => e.IdClient).HasColumnName("id_client");
        builder.Property(e => e.Email)
                            .HasMaxLength(255)
                            .HasColumnName("email");
        builder.Property(e => e.Family)
                            .HasMaxLength(45)
                            .HasColumnName("family");
        builder.Property(e => e.Name)
                            .HasMaxLength(25)
                            .HasColumnName("name");
        builder.Property(e => e.Patronymic)
                            .HasMaxLength(45)
                            .HasColumnName("patronymic");
        builder.Property(e => e.Phone)
                            .HasMaxLength(11)
                            .HasColumnName("phone");
    }
    internal static void ComponentConfigure(EntityTypeBuilder<Component> builder)
    {
        builder.ToTable("component");
/*        builder.HasKey(e => e.IdComponent)
    .HasName("component_pkey");*/
        builder.Property(e => e.IdComponent)
            .HasMaxLength(25)
            .HasColumnName("id_component");
        builder.Property(e => e.IdGuarantee)
            .HasMaxLength(15)
            .HasColumnName("id_guarantee");
        builder.Property(e => e.Manufacturer)
            .HasMaxLength(25)
            .HasColumnName("manufacturer");
        builder.Property(e => e.Name)
            .HasMaxLength(40)
            .HasColumnName("name");
        builder.Property(e => e.TypeC)
            .HasMaxLength(20)
            .HasColumnName("type_c");
        builder.HasOne(d => d.IdGuaranteeNavigation)
            .WithMany(p => p.Components)
            .HasForeignKey(d => d.IdGuarantee)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_comp_guarantee");
        builder.HasOne(d => d.ManufacturerNavigation)
            .WithMany(p => p.Components)
            .HasForeignKey(d => d.Manufacturer)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_comp_manufacturer");
    }
    internal static void EmployeeOfCompanyConfigure(EntityTypeBuilder<EmployeeOfCompany> builder)
    {
/*        entity.HasKey(e => e.IdEmployee)
    .HasName("employee_of_company_pkey");
*/
        builder.ToTable("employee_of_company");

        builder.HasIndex(e => e.IdEmploymentContract, "employee_of_company_id_employment_contract_key")
            .IsUnique();

        builder.HasIndex(e => e.Login, "employee_of_company_login_key")
            .IsUnique();

        builder.HasIndex(e => e.PassportNubmer, "employee_of_company_passport_nubmer_key")
            .IsUnique();

        builder.HasIndex(e => e.PassportSerial, "employee_of_company_passport_serial_key")
            .IsUnique();

        builder.HasIndex(e => e.Password, "employee_of_company_password_key")
            .IsUnique();

        builder.HasIndex(e => e.Phone, "employee_of_company_phone_key")
            .IsUnique();

        builder.Property(e => e.IdEmployee)
            .HasMaxLength(8)
            .HasColumnName("id_employee");

        builder.Property(e => e.Adres).HasColumnName("adres");

        builder.Property(e => e.DateOfEmployment).HasColumnName("date_of_employment");

        builder.Property(e => e.Family)
            .HasMaxLength(30)
            .HasColumnName("family");

        builder.Property(e => e.IdEmployeeType)
            .HasMaxLength(15)
            .HasColumnName("id_employee_type");

        builder.Property(e => e.IdEmploymentContract)
            .HasMaxLength(8)
            .HasColumnName("id_employment_contract");

        builder.Property(e => e.Login)
            .HasMaxLength(64)
            .HasColumnName("login")
            .HasDefaultValueSql("NULL::character varying");

        builder.Property(e => e.Name)
            .HasMaxLength(30)
            .HasColumnName("name");

        builder.Property(e => e.NameWorkshop)
            .HasMaxLength(35)
            .HasColumnName("name_workshop");

        builder.Property(e => e.PassportNubmer)
            .HasPrecision(6)
            .HasColumnName("passport_nubmer");

        builder.Property(e => e.PassportSerial)
            .HasPrecision(4)
            .HasColumnName("passport_serial");

        builder.Property(e => e.Password)
            .HasMaxLength(64)
            .HasColumnName("password")
            .HasDefaultValueSql("NULL::character varying");

        builder.Property(e => e.Patronymic)
            .HasMaxLength(30)
            .HasColumnName("patronymic");

        builder.Property(e => e.Phone)
            .HasMaxLength(11)
            .HasColumnName("phone");

        builder.HasOne(d => d.NameWorkshopNavigation)
            .WithMany(p => p.EmployeeOfCompanies)
            .HasForeignKey(d => d.NameWorkshop)
            .HasConstraintName("fk_emp_store");
    }
    internal static void GuaranteeConfigure(EntityTypeBuilder<Guarantee> builder)
    {
/*        entity.HasKey(e => e.IdGuarantee)
    .HasName("guarantee_pkey");
*/
        builder.ToTable("guarantee");

        builder.Property(e => e.IdGuarantee)
            .HasMaxLength(10)
            .HasColumnName("id_guarantee");

        builder.Property(e => e.Conditions).HasColumnName("conditions");

        builder.Property(e => e.PeriodInMonths).HasColumnName("period_in_months");
    }
    internal static void ListOfSupportedModelConfigure(EntityTypeBuilder<ListOfSupportedModel> builder)
    {
/*        entity.HasKey(e => e.IdListOfSupModels)
    .HasName("list_of_supported_models_pkey");
*/
        builder.ToTable("list_of_supported_models");

        builder.Property(e => e.IdListOfSupModels)
            .HasMaxLength(5)
            .HasColumnName("id_list_of_sup_models");

        builder.Property(e => e.IdComponent)
            .HasMaxLength(25)
            .HasColumnName("id_component");

        builder.Property(e => e.IdPhoneModel)
            .HasMaxLength(25)
            .HasColumnName("id_phone_model");

        builder.Property(e => e.ListSupmodelName)
            .HasMaxLength(25)
            .HasColumnName("list_supmodel_name");

        builder.HasOne(d => d.IdComponentNavigation)
            .WithMany(p => p.ListOfSupportedModels)
            .HasForeignKey(d => d.IdComponent)
            .HasConstraintName("fk_lm_component");

        builder.HasOne(d => d.IdPhoneModelNavigation)
            .WithMany(p => p.ListOfSupportedModels)
            .HasForeignKey(d => d.IdPhoneModel)
            .HasConstraintName("fk_lm_phone_model");
    }
    internal static void ManufacturerConfigure(EntityTypeBuilder<Manufacturer> builder)
    {
/*        entity.HasKey(e => e.IdManufacturer)
    .HasName("manufacturer_pkey");*/

        builder.ToTable("manufacturer");

        builder.HasIndex(e => e.Name, "manufacturer_name_key")
            .IsUnique();

        builder.Property(e => e.IdManufacturer)
            .HasMaxLength(25)
            .HasColumnName("id_manufacturer");

        builder.Property(e => e.Name)
            .HasMaxLength(150)
            .HasColumnName("name");
    }
    internal static void OrderConfigure(EntityTypeBuilder<Order> builder)
    {
/*        entity.HasKey(e => e.IdOrder)
    .HasName("orders_pkey");
*/
        builder.ToTable("orders");

        builder.Property(e => e.IdOrder).HasColumnName("id_order");

        builder.Property(e => e.Address)
            .HasMaxLength(255)
            .HasColumnName("address");

        builder.Property(e => e.IdClient).HasColumnName("id_client");

        builder.Property(e => e.IdOrderStatus)
            .HasMaxLength(10)
            .HasColumnName("id_order_status");

        builder.Property(e => e.OrderDate)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("order_date");

        builder.Property(e => e.PhoneNumber)
            .HasMaxLength(11)
            .HasColumnName("phone_number");

        builder.HasOne(d => d.IdClientNavigation)
            .WithMany(p => p.Orders)
            .HasForeignKey(d => d.IdClient)
            .HasConstraintName("fk_ord_client");

        builder.HasOne(d => d.IdOrderStatusNavigation)
            .WithMany(p => p.Orders)
            .HasForeignKey(d => d.IdOrderStatus)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_ord_ordstat");
    }
    internal static void OrderStatusConfigure(EntityTypeBuilder<OrderStatus> builder)
    {
/*        entity.HasKey(e => e.IdOrderStatus)
    .HasName("order_status_pkey");*/

        builder.ToTable("order_status");

        builder.Property(e => e.IdOrderStatus)
            .HasMaxLength(10)
            .HasColumnName("id_order_status");

        builder.Property(e => e.DescriptionOrderStatus)
            .HasMaxLength(25)
            .HasColumnName("description_order_status");
    }
    internal static void PhoneConfigure(EntityTypeBuilder<Phone> builder)
    {
/*        entity.HasKey(e => e.Imei)
    .HasName("phone_pkey");*/

        builder.ToTable("phone");

        builder.Property(e => e.Imei)
            .HasMaxLength(17)
            .HasColumnName("imei");

        builder.Property(e => e.IdPhoneModel)
            .HasMaxLength(25)
            .HasColumnName("id_phone_model");

        builder.HasOne(d => d.IdPhoneModelNavigation)
            .WithMany(p => p.Phones)
            .HasForeignKey(d => d.IdPhoneModel)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_phone_phmodel");
    }
    internal static void PhoneModelConfigure(EntityTypeBuilder<PhoneModel> builder)
    {
/*        entity.HasKey(e => e.IdPhoneModel)
    .HasName("phone_model_pkey");*/

        builder.ToTable("phone_model");

        builder.Property(e => e.IdPhoneModel)
            .HasMaxLength(25)
            .HasColumnName("id_phone_model");

        builder.Property(e => e.GuaranteePhoneModel)
            .HasMaxLength(15)
            .HasColumnName("guarantee_phone_model");

        builder.Property(e => e.Manufacturer)
            .HasMaxLength(25)
            .HasColumnName("manufacturer");

        builder.Property(e => e.NameModel)
            .HasMaxLength(35)
            .HasColumnName("name_model");

        builder.Property(e => e.Specifications).HasColumnName("specifications");

        builder.HasOne(d => d.GuaranteePhoneModelNavigation)
            .WithMany(p => p.PhoneModels)
            .HasForeignKey(d => d.GuaranteePhoneModel)
            .HasConstraintName("fk_phmod_guarante");

        builder.HasOne(d => d.ManufacturerNavigation)
            .WithMany(p => p.PhoneModels)
            .HasForeignKey(d => d.Manufacturer)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_phmod_manufacturer");
    }
    internal static void WorkshopConfigure(EntityTypeBuilder<Workshop> builder)
    {
/*        entity.HasKey(e => e.NameWorkshop)
    .HasName("workshop_pkey");*/

        builder.ToTable("workshop");

        builder.Property(e => e.NameWorkshop)
            .HasMaxLength(35)
            .HasColumnName("name_workshop");

        builder.Property(e => e.Address).HasColumnName("address");
    }
}