using EcommerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceAPI.Infrastructure.Persistence.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => new { x.OrderId, x.ProductId });

        builder.Property(x => x.UnitPrice).HasPrecision(18, 2).IsRequired();

        builder.Property(x => x.Quantity).IsRequired();

        builder.HasOne(x => x.Order).WithMany(x => x.Items).HasForeignKey(x => x.OrderId);

        builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
    }
}
