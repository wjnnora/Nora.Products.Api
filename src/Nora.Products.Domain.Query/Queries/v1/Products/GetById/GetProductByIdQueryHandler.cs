using MediatR;
using Nora.Products.Domain.Contracts.Repositories;
using Nora.Products.Domain.Entities;

namespace Nora.Products.Domain.Query.Queries.v1.Products.GetById;

public sealed class GetProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, Product>
{
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        => await productRepository.GetByIdAsync(request.Id);
}