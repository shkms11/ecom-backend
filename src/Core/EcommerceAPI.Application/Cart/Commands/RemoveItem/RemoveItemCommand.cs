using EcommerceAPI.Application.Cart.DTOs;
using MediatR;

namespace EcommerceAPI.Application.Cart.Commands.RemoveItem;

public record RemoveItemCommand(int CartItemId) : IRequest<CartDto>;
