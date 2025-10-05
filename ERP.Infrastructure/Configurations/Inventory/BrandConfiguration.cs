using ERP.Domain.Entities.Inventory;

namespace ERP.Infrastructure.Configurations.Inventory
{
    internal class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands", "Inventory");

            builder.HasIndex(e => new { e.Name, e.BranchId }).IsUnique();
            builder.Property(e => e.ImgPath).IsRequired().HasMaxLength(450);

            builder.Property(e => e.ImgPath)
                .HasDefaultValue("/Images/Users/DefaultUser.jpg");


        }
    }
}
