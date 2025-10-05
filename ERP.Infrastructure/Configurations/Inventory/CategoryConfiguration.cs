namespace ERP.Infrastructure.Configurations.Inventory
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "Inventory");

            builder.HasIndex(e => new { e.Name, e.BrandId }).IsUnique();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(256);



        }
    }
}
