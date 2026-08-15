using EcommerceAPI.Application.Cart.DTOs;
using MediatR;

namespace EcommerceAPI.Application.Cart.Commands.UpdateQuantity;

public class UpdateQuantityCommandHandler : IRequestHandler<UpdateQuantityCommand, CartDto>
{
    public async Task<CartDto> Handle(
        UpdateQuantityCommand request,
        CancellationToken cancellationToken
    )
    {
        // 1. Find cart item
        // 2. Make sure it exists
        // 3. Change quantity
        // 4. Save
        // 5. Return CartDto

        throw new NotImplementedException();
    }
}
