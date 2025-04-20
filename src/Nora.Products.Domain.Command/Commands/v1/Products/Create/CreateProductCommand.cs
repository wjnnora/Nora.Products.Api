using MediatR;

namespace Nora.Products.Domain.Command.Commands.v1.Products.Create;

public sealed class CreateProductCommand : IRequest<Unit>
{
    public string Description { get; set; }
    public decimal Value { get; set; }
    public int CategoryId { get; set; }
}