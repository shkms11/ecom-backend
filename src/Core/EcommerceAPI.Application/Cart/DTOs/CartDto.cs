namespace EcommerceAPI.Application.Cart.DTOs;

public class CartDto
{
    public List<CartItemDto> Items { get; set; } = [];
    public decimal TotalAmount { get; set; }
}
