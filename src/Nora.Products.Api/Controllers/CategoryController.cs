using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nora.Products.Domain.Command.Commands.v1.Categories.Create;
using Nora.Products.Domain.Query.Queries.v1.Categories.GetById;

namespace Nora.Products.Api.Controllers;

[ApiController]
[Route("api/v1/categories")]
public sealed class CategoryController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryCommand command)
    {
        await mediator.Send(command);

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var category = await mediator.Send(new GetCategoryByIdQuery(id));

        return Ok(category);        
    }
}