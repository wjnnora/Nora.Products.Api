using AutoMapper;
using MediatR;
using Nora.Core.Database.Contracts;
using Nora.Core.Database.Contracts.Repositories;
using Nora.Products.Domain.Contracts.Repositories;
using Nora.Products.Domain.Entities;

namespace Nora.Products.Domain.Command.Commands.v1.Products.Create;

public sealed class CreateProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork<ISqlContext> unitOfWork,
    IMapper mapper) : IRequestHandler<CreateProductCommand, Unit>
{
    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = mapper.Map<Product>(request);        

        await productRepository.AddAsync(product);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}