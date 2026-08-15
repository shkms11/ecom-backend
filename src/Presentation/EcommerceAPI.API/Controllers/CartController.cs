using EcommerceAPI.Application.Cart.Commands.AddItem;
using EcommerceAPI.Application.Cart.Commands.ClearCart;
using EcommerceAPI.Application.Cart.Commands.RemoveItem;
using EcommerceAPI.Application.Cart.Commands.UpdateQuantity;
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

    [HttpPost("items")]
    public async Task<ActionResult> AddItem(
        AddItemCommand command,
        CancellationToken cancellationToken
    )
    {
        var result = await _mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpPatch("items/{id}")]
    public async Task<ActionResult> UpdateQuantity(
        int id,
        UpdateQuantityCommand command,
        CancellationToken cancellationToken
    )
    {
        var result = await _mediator.Send(command with { CartItemId = id }, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("items/{id}")]
    public async Task<ActionResult> RemoveItem(int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new RemoveItemCommand(id), cancellationToken);

        return Ok(result);
    }

    [HttpDelete]
    public async Task<ActionResult> ClearCart(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new ClearCartCommand(), cancellationToken);

        return Ok(result);
    }
}
