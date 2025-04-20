using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nora.Products.Domain.Command.Commands.v1.Products.Create;
using Nora.Products.Domain.Query.Queries.v1.Products.GetById;

namespace Nora.Products.Api.Controllers;

[ApiController]
[Route("api/v1/products")]
public sealed class ProductController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateProductCommand command)
    {
        await mediator.Send(command);        

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var response = await mediator.Send(new GetProductByIdQuery(id));

        return Ok(response);
    }
}