using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestStore.Core.Entities;

namespace TestStore.EntityFramework.ConfigurationProfiles
{
    class OrderProfile : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.TotalPrice);

            builder.HasMany(x => x.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            builder.Navigation(x => x.OrderItems)
                .AutoInclude();

            builder.Ignore(x => x.ValidationResult);
        }
    }
}
