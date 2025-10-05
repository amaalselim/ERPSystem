using ERP.Domain.Entities.Hierarchy;

namespace ERP.Infrastructure.Configurations.Hierarchy
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments", "Hierarchy");
            builder.HasIndex(e => new { e.Name, e.BranchId }).IsUnique();
            builder.Property(e => e.Name).HasMaxLength(256).IsRequired();
        }
    }
}
