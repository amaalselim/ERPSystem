using ERP.Domain.Entities.Inventory;

namespace ERP.Infrastructure.Configurations.Inventory
{
    internal class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Stores", "Inventory");

            builder.HasIndex(e => new { e.Name, e.BranchId }).IsUnique();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(256);
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(256);
            builder.Property(e => e.Address).IsRequired().HasMaxLength(450);
            builder.Property(e => e.IsActive).HasDefaultValue(true);

        }
    }
}
