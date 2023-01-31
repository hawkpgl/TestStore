using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestStore.Core.Entities;

namespace TestStore.EntityFramework.ConfigurationProfiles
{
    class OrderItemProfile : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedNever();
            
            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasColumnType("nvarchar(100)");

            builder.Property(x => x.Quantity);
            
            builder.Property(x => x.SingleProductPrice);

            builder.HasOne(x => x.Order)
                .WithMany(o => o.OrderItems);

            builder.Ignore(x => x.ValidationResult);
        }
    }
}
