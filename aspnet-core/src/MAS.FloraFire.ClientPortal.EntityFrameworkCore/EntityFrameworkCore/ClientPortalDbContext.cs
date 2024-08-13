using MAS.FloraFire.ClientPortal.CustomerComments;
using MAS.FloraFire.ClientPortal.Customers;
using MAS.FloraFire.ClientPortal.StoreWorkHours;
using MAS.FloraFire.ClientPortal.EmailDirectories;
using MAS.FloraFire.ClientPortal.PhoneDirectories;
using MAS.FloraFire.ClientPortal.Values;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using MAS.FloraFire.ClientPortal.StateProvinces;
using MAS.FloraFire.ClientPortal.Countries;
using MAS.FloraFire.ClientPortal.Vehicles;
using MAS.FloraFire.ClientPortal.Shops;
using MAS.FloraFire.ClientPortal.Stores;
using MAS.FloraFire.ClientPortal.Logs;

namespace MAS.FloraFire.ClientPortal.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class ClientPortalDbContext :
    AbpDbContext<ClientPortalDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<ValueType> ValueTypes { get; set; }
    public DbSet<Value> Value { get; set; }
    public DbSet<Shop> Shops { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    //Client Portal
    public DbSet<Country> Countries { get; set; }
    public DbSet<StateProvince> StateProvince { get; set; }

    public DbSet<CustomerComment> CustomerComments { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Store> Stores { get; set; }
    public DbSet<StoreWorkHour> StoreWorkHours { get; set; }

    //Email and Phone Directory
    public DbSet<EmailDirectory> EmailDirectories { get; set; }
    public DbSet<PhoneDirectory> PhoneDirectories { get; set; }

    public DbSet<Vehicle> Vehicles { get; set; }

    //Logs
    public DbSet<AuditType> AuditTypes { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }

    public DbSet<ErrorLog> ErrorLogs { get; set; }

    #endregion

    #region Ctor
    public ClientPortalDbContext(DbContextOptions<ClientPortalDbContext> options)
        : base(options)
    {

    }
    #endregion

    #region Methods
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */
        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();
        builder.Entity<Country>(b =>
        {
            b.ToTable(ClientPortalConsts.DbTablePrefix + "Country",
                ClientPortalConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Name).IsRequired().HasMaxLength(100);
            b.Property(x => x.TwoLetterIsoCode).HasMaxLength(2);
            b.Property(x => x.ThreeLetterIsoCode).HasMaxLength(3);
        });

        builder.Entity<StateProvince>(b =>
        {
            b.ToTable(ClientPortalConsts.DbTablePrefix + "StateProvince",
                ClientPortalConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Name).IsRequired().HasMaxLength(100);
            b.Property(x => x.Abbreviation).HasMaxLength(100);
            b.Property(x => x.CountryId).IsRequired();
            b.HasOne<Country>()
                .WithMany()
                .HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<CustomerComment>(b =>
        {
            b.ToTable(ClientPortalConsts.DbTablePrefix + "CustomerComments", ClientPortalConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Comment).IsRequired();
        });

        builder.Entity<ValueType>(b =>
        {
            b.ToTable(ClientPortalConsts.DbTablePrefix + "ValueType",
               ClientPortalConsts.DbSchema);
            b.HasIndex(x => x.Name);
            b.ConfigureByConvention();
            b.ConfigureSoftDelete();
            b.Property(x => x.Name).IsRequired().HasMaxLength(200);
        });

        builder.Entity<Value>(b =>
        {
            b.ToTable(ClientPortalConsts.DbTablePrefix + "Value",
               ClientPortalConsts.DbSchema);
            b.HasIndex(x => x.Name);
            b.ConfigureByConvention();
            b.ConfigureSoftDelete();
            b.Property(x => x.Name).IsRequired().HasMaxLength(200);
            b.HasOne<ValueType>().WithMany().HasForeignKey(x => x.ValueTypeId).IsRequired();
        });

        builder.Entity<Shop>(b =>
        {
            b.ToTable(ClientPortalConsts.DbTablePrefix + "Shop",
               ClientPortalConsts.DbSchema);
            b.HasIndex(x => x.Name);
            b.ConfigureByConvention();
            b.ConfigureSoftDelete();
            b.Property(x => x.Name).IsRequired().HasMaxLength(500);
            b.Property(x => x.ShopCode).IsRequired().HasMaxLength(50);
            b.Property(x => x.ZipCode).IsRequired().HasMaxLength(50);
            b.Property(x => x.Phone).IsRequired(false).HasMaxLength(20);
            b.Property(x => x.Email).IsRequired(false).HasMaxLength(500);
        });

        builder.Entity<Customer>(b =>
        {
            b.ToTable(ClientPortalConsts.DbTablePrefix + "Customer",
               ClientPortalConsts.DbSchema);
            b.HasIndex(x => x.Name);
            b.ConfigureByConvention();
            b.ConfigureSoftDelete();
            b.ConfigureAuditedAggregateRoot();
            b.Property(x => x.Name).IsRequired().HasMaxLength(200);
            b.Property(x => x.Address1).IsRequired().HasMaxLength(500);
            b.Property(x => x.Address2).IsRequired(false).HasMaxLength(200);
            b.Property(x => x.CountryId).IsRequired();
            b.Property(x => x.StateProvinceId).IsRequired();
            b.Property(x => x.City).IsRequired().HasMaxLength(100);
            b.Property(x => x.Zip).HasMaxLength(100);
            b.Property(x => x.Fax).IsRequired(false).HasMaxLength(200);
            b.Property(x => x.StatusValueId).IsRequired();
            b.Property(x => x.TypeId).IsRequired();
            b.Property(x => x.AcctClassValueId).IsRequired();
            b.Property(x => x.StoreId).IsRequired();
            b.Property(x => x.TermValueId).IsRequired();
            b.Property(x => x.InvoicePaymentSchedulerValueId).IsRequired();
            b.Property(x => x.CustomerReference).IsRequired(false).HasMaxLength(200);
            b.Property(x => x.Discount).HasColumnType("decimal(18,4)");
            b.Property(x => x.DiscountOnWireout).HasColumnType("decimal(18,4)");
            b.Property(x => x.YTDPayments).HasColumnType("decimal(18,4)");
            b.Property(x => x.LYTDPayments).HasColumnType("decimal(18,4)");
            b.Property(x => x.LifetimePayments).HasColumnType("decimal(18,4)");
            b.Property(x => x.LifetimeCreditLimit).HasColumnType("decimal(18,4)");
            b.Property(x => x.YTDAmount).HasColumnType("decimal(18,4)");
            b.Property(x => x.LYTDsalesAmount).HasColumnType("decimal(18,4)");
            b.Property(x => x.LifetimeSalesAmount).HasColumnType("decimal(18,4)");
            b.Property(x => x.Comment).IsRequired(false);
        });

        builder.Entity<StoreWorkHour>(b =>
        {
            b.ToTable(ClientPortalConsts.DbTablePrefix + "StoreWorkHours",
               ClientPortalConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.StartTime).IsRequired(false).HasMaxLength(8);
            b.Property(x => x.EndTime).IsRequired(false).HasMaxLength(8);
        });


        builder.Entity<EmailDirectory>(b =>
        {
            b.ToTable(ClientPortalConsts.DbTablePrefix + "EmailDirectory",
               ClientPortalConsts.DbSchema);
            b.HasIndex(x => x.Email);
            b.ConfigureByConvention();
            b.Property(x => x.Email).IsRequired().HasMaxLength(200);
        });

        builder.Entity<PhoneDirectory>(b =>
        {
            b.ToTable(ClientPortalConsts.DbTablePrefix + "PhoneDirectory",
               ClientPortalConsts.DbSchema);
            b.HasIndex(x => x.PhoneNumber);
            b.ConfigureByConvention();
            b.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(50);
        });

        builder.Entity<Vehicle>(b =>
        {
            b.ToTable(ClientPortalConsts.DbTablePrefix + "Vehicles", ClientPortalConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.LicensePlate).IsRequired().HasMaxLength(30);
            b.Property(x => x.VIN).IsRequired().HasMaxLength(200);
            b.Property(x => x.Model).IsRequired(false).HasMaxLength(200);
            b.Property(x => x.StatusValueId).IsRequired();
        });

        builder.Entity<Store>(b =>
        {
            b.ToTable(ClientPortalConsts.DbTablePrefix + "Store", ClientPortalConsts.DbSchema);
            b.HasIndex(x => x.StoreCode);
            b.ConfigureByConvention();
            b.Property(x => x.StoreCode).HasMaxLength(50);
            b.Property(x => x.ContactName).IsRequired(false).HasMaxLength(500);
            b.Property(x => x.Email).HasMaxLength(500);
            b.Property(x => x.AddressLine1).HasMaxLength(500);
            b.Property(x => x.AddressLine2).IsRequired(false).HasMaxLength(500);
            b.Property(x => x.City).HasMaxLength(200);
            b.Property(x => x.ZipCode).HasMaxLength(50);
            b.Property(x => x.Phone).HasMaxLength(20);
            b.Property(x => x.TimeZone).IsRequired();
            b.Property(x => x.FaxNumber).IsRequired(false).HasMaxLength(50);
            b.Property(x => x.DateTimeFormate).IsRequired(false).HasMaxLength(10);
            b.Property(x => x.FacebookUrl).IsRequired(false).HasMaxLength(500);
            b.Property(x => x.TwitterUrl).IsRequired(false).HasMaxLength(500);
            b.Property(x => x.PinterestUrl).IsRequired(false).HasMaxLength(500);
            b.Property(x => x.SalesTax).HasColumnType("decimal(18,4)");
            b.Property(x => x.Latitude).HasColumnType("decimal(9, 6)");
            b.Property(x => x.Longitude).HasColumnType("decimal(9, 6)");
            b.Property(x => x.ReceiptFooterNote).IsRequired(false);
        });

        builder.Entity<AuditType>(b =>
        {
            b.ToTable(ClientPortalConsts.DbTablePrefix + nameof(AuditType), ClientPortalConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.SystemKeyWord).IsRequired().HasMaxLength(100);
            b.Property(x => x.Name).IsRequired().HasMaxLength(200);
            b.Property(x => x.IsActive).IsRequired();
        });

        builder.Entity<AuditLog>(b =>
        {
            b.ToTable(ClientPortalConsts.DbTablePrefix + nameof(AuditLog), ClientPortalConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne(x => x.AuditType)
                    .WithMany()
                    .HasForeignKey(x => x.AuditTypeId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);
            b.Property(x => x.Comment).IsRequired();
            b.Property(x => x.IpAddress).IsRequired().HasMaxLength(100);
            b.Property(x => x.EntityName).IsRequired(false).HasMaxLength(400);
            b.Property(x => x.EntityId).IsRequired(false);
            b.Property(x => x.CustomerId).IsRequired(false);
            b.Property(x => x.ShopId).IsRequired(false);
        });

        builder.Entity<ErrorLog>(b =>
        {
            b.ToTable(ClientPortalConsts.DbTablePrefix + nameof(ErrorLog), ClientPortalConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.ShortMessage).IsRequired();
            b.Property(x => x.FullMessage).IsRequired();
            b.Property(x => x.IpAddress).IsRequired().HasMaxLength(100);
            b.Property(x => x.UserId).IsRequired(false);
            b.Property(x => x.CustomerId).IsRequired(false);
            b.Property(x => x.StoreId).IsRequired(false);
            b.Property(x => x.PageUrl).IsRequired(false);
            b.Property(x => x.ReferredUrl).IsRequired(false);
            b.Property(x => x.LogLevel).IsRequired();
        });
    }
    #endregion
}