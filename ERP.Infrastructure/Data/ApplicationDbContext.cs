namespace ERP.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasSequence<int>("UserId").StartsAt(1).IncrementsBy(1);

            builder.Entity<Employee>()
                .Property(e => e.UserId)
                .HasDefaultValueSql("NEXT VALUE FOR UserId");

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<SupplierAccount> SupplierAccounts { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Unit> Units { get; set; }

        public DbSet<PaymentVoucher> PaymentVouchers { get; set; }
        public DbSet<ReceiptVoucher> ReceiptVouchers { get; set; }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreHistory> StoreHistories { get; set; }
        public DbSet<StockHistory> StockHistories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<SaleInvoice> SaleInvoices { get; set; }
        public DbSet<SaleInvoiceItem> SaleInvoiceItems { get; set; }



    }
}
