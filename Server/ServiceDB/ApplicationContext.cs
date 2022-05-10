using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceDB.Models;

namespace ServiceDB;

// Scaffold-DbContext "host=45.10.244.15;port=55532;database=work100024;username=work100024;password= iS~pLC*gmrAgl6aJ1pL7" npgsql.entityframeworkcore.postgresql -OutputDir Models
public sealed class ApplicationContext : DbContext
{
    private const string ConfigFile = "appsettings.json";

    internal ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        Database.Migrate();
    }

    internal static string? ConnectionStrings { get; private set; }

    internal static DbContextOptions<ApplicationContext> GetDb()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
        if (!File.Exists(ConfigFile))
        {
            using var sw = File.Open(ConfigFile, FileMode.Create, FileAccess.Write);
            sw.Write(JsonSerializer.SerializeToUtf8Bytes(new
                {ConnectionStrings = new {DefaultConnection = "Host=;Port=;Database=;Username=;Password="}}));
        }

        builder.AddJsonFile(ConfigFile);
        var config = builder.Build();

        ConnectionStrings = config.GetConnectionString("DefaultConnection");
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
#if DEBUG
        optionsBuilder.LogTo(Console.WriteLine);
#endif
        return optionsBuilder.UseNpgsql(ConnectionStrings).Options;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(EntityConfigure.ClientConfigure);
        modelBuilder.Entity<Component>(EntityConfigure.ComponentConfigure);
        modelBuilder.Entity<EmployeeOfCompany>(EntityConfigure.EmployeeOfCompanyConfigure);
        modelBuilder.Entity<Guarantee>(EntityConfigure.GuaranteeConfigure);
        modelBuilder.Entity<ListOfSupportedModel>(EntityConfigure.ListOfSupportedModelConfigure);
        modelBuilder.Entity<Manufacturer>(EntityConfigure.ManufacturerConfigure);
        modelBuilder.Entity<Order>(EntityConfigure.OrderConfigure);
        modelBuilder.Entity<OrderStatus>(EntityConfigure.OrderStatusConfigure);
        modelBuilder.Entity<Phone>(EntityConfigure.PhoneConfigure);
        modelBuilder.Entity<PhoneModel>(EntityConfigure.PhoneModelConfigure);
        modelBuilder.Entity<Workshop>(EntityConfigure.WorkshopConfigure);

    }
    /*
        public override void Dispose()
        {
            DbWorker.UnLoad();
            base.Dispose();
        }
    */
    #region Tables

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

    internal DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
    

    #endregion
}