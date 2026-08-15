using EcommerceAPI.Application.Cart.DTOs;
using MediatR;

namespace EcommerceAPI.Application.Cart.Commands.ClearCart;

public class ClearCartCommandHandler : IRequestHandler<ClearCartCommand, CartDto>
{
    public async Task<CartDto> Handle(ClearCartCommand request, CancellationToken cancellationToken)
    {
        // 1. Find user's cart
        // 2. Remove all cart items
        // 3. Save changes
        // 4. Return CartDto

        throw new NotImplementedException();
    }
}
