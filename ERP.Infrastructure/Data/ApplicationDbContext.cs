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
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public virtual DbSet<SupplierAccount> SupplierAccounts { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<PaymentVoucher> PaymentVouchers { get; set; }
        public virtual DbSet<ReceiptVoucher> ReceiptVouchers { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreHistory> StoreHistories { get; set; }
        public virtual DbSet<StockHistory> StockHistories { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public virtual DbSet<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<SaleInvoice> SaleInvoices { get; set; }
        public virtual DbSet<SaleInvoiceItem> SaleInvoiceItems { get; set; }

    }
}
