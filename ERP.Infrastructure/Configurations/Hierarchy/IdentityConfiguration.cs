namespace ERP.Infrastructure.Configurations.Hierarchy
{
    internal class IdentityConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.ToTable("Employees", "Hierarchy");
        }
    }
}