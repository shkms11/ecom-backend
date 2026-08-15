using EcommerceAPI.Application.Cart.DTOs;
using MediatR;

namespace EcommerceAPI.Application.Cart.Commands.ClearCart;

public record ClearCartCommand : IRequest<CartDto>;
