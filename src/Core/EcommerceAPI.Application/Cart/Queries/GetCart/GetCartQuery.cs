using EcommerceAPI.Application.Cart.DTOs;
using MediatR;

namespace EcommerceAPI.Application.Cart.Queries.GetCart;

public record GetCartQuery : IRequest<CartDto>;
