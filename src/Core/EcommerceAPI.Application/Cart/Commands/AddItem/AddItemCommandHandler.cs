using EcommerceAPI.Application.Cart.DTOs;
using MediatR;

namespace EcommerceAPI.Application.Cart.Commands.AddItem;

public class AddItemCommandHandler : IRequestHandler<AddItemCommand, CartDto>
{
    public async Task<CartDto> Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
        // 1. Find product
        // 2. Find user's cart
        // 3. Create cart if it doesn't exist
        // 4. Check if product already exists in cart
        // 5. Add item / increase quantity
        // 6. Save
        // 7. Return CartDto

        throw new NotImplementedException();
    }
}
