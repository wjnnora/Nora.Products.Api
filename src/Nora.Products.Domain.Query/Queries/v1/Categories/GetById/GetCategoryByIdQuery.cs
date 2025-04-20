using MediatR;
using Nora.Products.Domain.Entities;

namespace Nora.Products.Domain.Query.Queries.v1.Categories.GetById;

public sealed class GetCategoryByIdQuery(int id) : IRequest<Category>
{
    public int Id { get; set; } = id;
}