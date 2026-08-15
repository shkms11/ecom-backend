using EcommerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceAPI.Infrastructure.Persistence.Configurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("CartItems");

        builder.HasKey(item => item.Id);

        builder.Property(item => item.CartId).IsRequired();

        builder.Property(item => item.ProductId).IsRequired();

        builder.Property(item => item.Quantity).IsRequired();

        // A product can appear only once in a cart
        builder.HasIndex(item => new { item.CartId, item.ProductId }).IsUnique();

        // CartItem -> Product
        builder
            .HasOne(item => item.Product)
            .WithMany()
            .HasForeignKey(item => item.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
