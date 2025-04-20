using MediatR;

namespace Nora.Products.Domain.Command.Commands.v1.Categories.Create;

public sealed class CreateCategoryCommand : IRequest<Unit>
{
    public string Description { get; set; }
}