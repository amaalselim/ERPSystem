namespace ERP.Infrastructure.Configurations.Hierarchy
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees", "Hierarchy");
            builder.HasIndex(e => e.Email).IsUnique();
            builder.HasIndex(e => e.PhoneNumber).IsUnique();

            builder.HasIndex(e => e.UserId).IsUnique();
            builder.Property(e => e.FullName).HasMaxLength(256).IsRequired();
            builder.Property(e => e.ImagePath).HasMaxLength(450).IsRequired();
            builder.Property(e => e.Signature).HasMaxLength(450).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(150).IsRequired();

            builder.HasCheckConstraint("CK_Employee_IsActive", "IsActive IN (0,1)");
            builder.HasCheckConstraint("CK_Employee_IsUser", "IsUser IN (0,1)");



        }
    }
}