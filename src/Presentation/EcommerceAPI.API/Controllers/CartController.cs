using EcommerceAPI.Application.Cart.Queries.GetCart;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.API.Controllers;

[ApiController]
[Route("cart")]
public class CartController : ControllerBase
{
    private readonly IMediator _mediator;

    public CartController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> GetCart(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetCartQuery(), cancellationToken);

        return Ok(result);
    }
}
