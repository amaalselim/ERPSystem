
using ERP.Domain.Entities.Hierarchy;

namespace ERP.Infrastructure.Configurations.Hierarchy
{
    internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies", "Hierarchy");

            builder.HasIndex(e => e.Name).IsUnique();
            builder.Property(e => e.Name).HasMaxLength(256).IsRequired();
            builder.Property(e => e.Activity).HasMaxLength(256).IsRequired();
            builder.Property(e => e.TaxNumber).HasMaxLength(50).IsRequired();
            builder.Property(e => e.RecordNumber).HasMaxLength(50).IsRequired();
            builder.Property(e => e.PhoneNumber).HasMaxLength(30).IsRequired();
            builder.Property(e => e.Code).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(256).IsRequired();
            builder.Property(e => e.LogoPath).HasMaxLength(450).IsRequired();
            builder.Property(e => e.Address).HasMaxLength(450).IsRequired();
            builder.Property(e => e.Seal).HasMaxLength(450).IsRequired();
            //builder.Property(e => e.IsActive).HasDefaultValue(true);
        }
    }
}
