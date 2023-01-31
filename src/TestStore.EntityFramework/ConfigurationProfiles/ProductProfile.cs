using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestStore.Core.Entities;

namespace TestStore.EntityFramework.ConfigurationProfiles
{
    class ProductProfile : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name);
            
            builder.Property(x => x.Price);
            
            builder.Property(x => x.OriginalCurrency)
                .HasDefaultValue("USD");

            builder.Ignore(x => x.ValidationResult);
        }
    }
}
