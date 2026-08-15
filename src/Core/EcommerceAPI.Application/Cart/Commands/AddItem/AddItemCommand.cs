using EcommerceAPI.Application.Cart.DTOs;
using MediatR;

namespace EcommerceAPI.Application.Cart.Commands.AddItem;

public record AddItemCommand(int ProductId, int Quantity) : IRequest<CartDto>;
