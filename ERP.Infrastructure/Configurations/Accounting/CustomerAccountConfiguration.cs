namespace ERP.Infrastructure.Configurations.Accounting
{
    internal class CustomerAccountConfiguration : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {
            builder.ToTable("CustomerAccounts", "Accounting");

            builder.Property(e => e.ItemId).IsRequired().HasMaxLength(256);
            builder.Property(e => e.Debtor).HasColumnType("decimal(18,2)").HasDefaultValue(0);
            builder.Property(e => e.Creditor).HasColumnType("decimal(18,2)").HasDefaultValue(0);
            builder.Property(e => e.Total).HasColumnType("decimal(18,2)").HasDefaultValue(0);

            builder.HasOne(e => e.Customer)
                .WithMany(c => c.CustomerAccounts)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasCheckConstraint("CK_CustomerAccount_Debtor", "Debtor >= 0 AND Debtor <= " + double.MaxValue);
            builder.HasCheckConstraint("CK_CustomerAccount_Creditor", "Creditor >= 0 AND Creditor <= " + double.MaxValue);
            builder.HasCheckConstraint("CK_CustomerAccount_Total", "Total >= 0 AND Total <= " + double.MaxValue);

        }
    }
}
