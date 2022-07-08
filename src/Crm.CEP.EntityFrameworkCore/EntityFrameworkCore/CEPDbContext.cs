using Crm.CEP.Coupons;
using Crm.CEP.CustomerCoupons;
using Crm.CEP.Customers;
using Crm.CEP.Items;
using Crm.CEP.Passwords;
using Crm.CEP.Queries;
using Crm.CEP.Referrals;
using Crm.CEP.SaltKeys;
using Crm.CEP.Segments;
using Crm.CEP.Settings;
using Crm.CEP.Stores;
using Crm.CEP.Terms;
using Crm.CEP.Transactions;
using Crm.CEP.TransactionsItems;
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
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Crm.CEP.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class CEPDbContext :
    AbpDbContext<CEPDbContext>,
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

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion
    public DbSet<Customer> Customers { get; set; }


    public DbSet<Coupon> Coupons { get; set; }


    public DbSet<Transaction> Transactions { get; set; }


    public DbSet<Item> Items { get; set; }


    public DbSet<TransactionItem> TransactionItems { get; set; }

    public DbSet<CustomerCoupon> CustomerCoupons { get; set; }

    public DbSet<Segment> Segments { get; set; }

    public DbSet<Query> Queries { get; set; }
    public DbSet<Referral> Referrals { get; set; }
    /* public DbSet<SaltKey> SaltKeys { get; set; }
     public DbSet<Password> Passwords { get; set; }
     public DbSet<Setting> Settings { get; set; }*/
    public DbSet<Store> Stores { get; set; }
    public DbSet<TermsConditions> Terms { get; set; }
    public CEPDbContext(DbContextOptions<CEPDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(CEPConsts.DbTablePrefix + "YourEntities", CEPConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.Entity<Customer>(x =>
        {
            x.ToTable(CEPConsts.DbTablePrefix + nameof(Customer) + "s", CEPConsts.DbSchema);

            x.ConfigureByConvention();//auto configure for the base class props

            x.HasKey(x => x.CustomerId);

            //Lengths & attributes
            x.Property(p => p.CustomerName)
            .HasMaxLength(CustomerConsts.MaxNameLength)
            .IsRequired();

            x.Property(p => p.Nationality)
            .HasMaxLength(CustomerConsts.MaxNationalityLength)
            .IsRequired();

            x.Property(p => p.DOB).IsRequired();

            x.Property(p => p.Gender).IsRequired();

        });


        builder.Entity<Coupon>(x =>
        {
            x.ToTable(CEPConsts.DbTablePrefix + nameof(Coupon) + "s", CEPConsts.DbSchema);

            x.ConfigureByConvention();

            x.HasKey(x => x.Id);

            x.Property(p => p.Name)
            .HasMaxLength(CouponConsts.MaxNameLength)
            .IsRequired();

            x.Property(p => p.Status).IsRequired();


        });

        builder.Entity<Transaction>(x => {
            x.ToTable(CEPConsts.DbTablePrefix + nameof(Transaction) + "s", CEPConsts.DbSchema);
            x.HasKey(x => x.TransactionId);

            x.HasOne(p => p.Customer)
            .WithMany(p => p.Transactions)
            .HasForeignKey(p => p.CustomerId);

            x.Property(p => p.TransactionId).IsRequired();
            x.Property(p => p.PurchaseDate).IsRequired();

            x.Property(x => x.InvoiceValue)
            //.HasColumnType(TransactionConsts.ColumnTypeInvoiceValue)
            .IsRequired();
        });

        builder.Entity<Item>(x =>
        {
            x.ToTable(CEPConsts.DbTablePrefix + nameof(Item) + "s", CEPConsts.DbSchema);

            x.ConfigureByConvention();

            x.HasKey(x => x.ItemID);

            x.Property(p => p.Name)
            .HasMaxLength(ItemConsts.MaxNameLength)
            .IsRequired();
        });

        //manytomany

        builder.Entity<TransactionItem>(x =>
        {
            x.HasKey(p => new { p.ItemID, p.TransactionID });

            x.HasOne(p => p.Item)
            .WithMany(p => p.TransactionItems)
            .HasForeignKey(k => k.ItemID);

            x.HasOne(p => p.Transaction)
            .WithMany(p => p.TransactionItems)
            .HasForeignKey(k => k.TransactionID);

        });

        builder.Entity<CustomerCoupon>(x =>
        {
            x.HasKey(p => new { p.CustomerId, p.CouponId });

            x.HasOne(p => p.Customer)
            .WithMany(p => p.CustomerCoupons)
            .HasForeignKey(k => k.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

             x.HasOne(p => p.Coupon)
            .WithMany(p => p.CustomerCoupons)
            .HasForeignKey(k => k.CouponId)
            .OnDelete(DeleteBehavior.Cascade);

        });

        builder.Entity<Segment>(x =>
        {
            x.ToTable(CEPConsts.DbTablePrefix + nameof(Segment) + "s", CEPConsts.DbSchema);

            x.HasOne(p => p.Query)
            .WithOne(p => p.Segment)
            .HasForeignKey<Query>(k => k.SegmentId);

            x.Property(p => p.Name)
            .HasMaxLength(SegmentConsts.MaxNameLength)
            .IsRequired();
        });

        builder.Entity<Query>(x =>
        {
            x.ToTable(CEPConsts.DbTablePrefix + nameof(Query) + "s", CEPConsts.DbSchema);

            x.HasOne(p => p.Segment)
            .WithOne(p => p.Query)
            .HasForeignKey<Query>(k => k.SegmentId).OnDelete(DeleteBehavior.Cascade);

            x.Property(p => p.JSONQueryField).IsRequired();
        });

      /*  builder.Entity<Password>(x =>
        {
            x.ToTable(CEPConsts.DbTablePrefix + nameof(Password) + "s", CEPConsts.DbSchema);

            x.ConfigureByConvention();

            x.HasKey(x => x.Id);

            x.HasOne(p => p.SaltKey)
           .WithOne(p => p.password)
           .HasForeignKey<Password>(k => k.SaltKeyID);

            x.HasOne(p => p.Setting)
         .WithOne(p => p.Password)
         .HasForeignKey<Password>(k => k.Id);



        });*/


       /* builder.Entity<SaltKey>(x =>
        {
            x.ToTable(CEPConsts.DbTablePrefix + nameof(SaltKey) + "s", CEPConsts.DbSchema);

            x.ConfigureByConvention();

            x.HasKey(x => x.Id);
            x.HasOne(p => p.password)
           .WithOne(p => p.SaltKey)
           .HasForeignKey<Password>(k => k.SaltKeyID);


            x.Property(p => p.SaltKeyvalue).IsRequired();


        });*/


      /*  builder.Entity<Setting>(x =>
        {
            x.ToTable(CEPConsts.DbTablePrefix + nameof(Setting) + "s", CEPConsts.DbSchema);

            x.ConfigureByConvention();

            x.HasKey(x => x.Id);

            x.HasOne(p => p.Password)
            .WithOne(p => p.Setting)
            .HasForeignKey<Setting>(k => k.Id);


            //x.HasOne(p => p.Password)
            //.WithMany(p => p.Settings)
            //.HasForeignKey(p => p.PasswordId)
            //.OnDelete(DeleteBehavior.Cascade);
        });*/

        builder.Entity<Store>(x =>
        {
            x.ToTable(CEPConsts.DbTablePrefix + nameof(Store) + "s", CEPConsts.DbSchema);

            x.HasKey(x => x.StoreID);

            x.ConfigureByConvention();
            //x.Property(p => p.StoreName).IsRequired();
        });

        builder.Entity<Referral>(x =>
        {
            x.ToTable(CEPConsts.DbTablePrefix + nameof(Referral) + "s", CEPConsts.DbSchema);

            x.HasKey(x => x.Id);

            x.ConfigureByConvention();
            //x.Property(p => p.StoreName).IsRequired();
        });

        builder.Entity<TermsConditions>(x =>
        {
            x.ToTable(CEPConsts.DbTablePrefix + nameof(TermsConditions) + "s", CEPConsts.DbSchema);

            x.HasKey(x => x.Id);

            x.ConfigureByConvention();
            //x.Property(p => p.StoreName).IsRequired();
        });
    }
}
