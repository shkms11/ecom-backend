using EcommerceAPI.Application.Cart.DTOs;
using MediatR;

namespace EcommerceAPI.Application.Cart.Commands.UpdateQuantity;

public record UpdateQuantityCommand(int CartItemId, int Quantity) : IRequest<CartDto>;
