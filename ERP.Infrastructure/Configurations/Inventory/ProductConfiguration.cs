using ERP.Domain.Entities.Inventory;

namespace ERP.Infrastructure.Configurations.Inventory
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "Inventory");

            builder.HasIndex(e => new { e.Name, e.BranchId }).IsUnique();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(256);
            builder.Property(e => e.Price).IsRequired().HasDefaultValue(0);

            builder.HasOne(e => e.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);



            builder.HasCheckConstraint("CK_Product_Price", "Price >= 0 AND Price <= " + double.MaxValue);



        }
    }
}
