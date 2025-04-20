using MediatR;
using Nora.Products.Domain.Entities;

namespace Nora.Products.Domain.Query.Queries.v1.Products.GetById;

public sealed class GetProductByIdQuery(int id) : IRequest<Product>
{
    public int Id { get; set; } = id;
}