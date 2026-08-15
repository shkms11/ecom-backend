using EcommerceAPI.Application.Cart.DTOs;
using MediatR;

namespace EcommerceAPI.Application.Cart.Commands.RemoveItem;

public class RemoveItemCommandHandler : IRequestHandler<RemoveItemCommand, CartDto>
{
    public async Task<CartDto> Handle(
        RemoveItemCommand request,
        CancellationToken cancellationToken
    )
    {
        // 1. Find cart item
        // 2. Make sure it exists
        // 3. Remove it
        // 4. Save changes
        // 5. Return CartDto

        throw new NotImplementedException();
    }
}
