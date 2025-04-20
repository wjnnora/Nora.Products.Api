using AutoMapper;
using MediatR;
using Nora.Core.Database.Contracts;
using Nora.Core.Database.Contracts.Repositories;
using Nora.Core.Domain.Exceptions;
using Nora.Products.Domain.Contracts.Repositories;
using Nora.Products.Domain.Entities;

namespace Nora.Products.Domain.Command.Commands.v1.Products.Create;

public sealed class CreateProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork<ISqlContext> unitOfWork,
    IMapper mapper,
    ICategoryRepository categoryRepository) : IRequestHandler<CreateProductCommand, Unit>
{
    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await ValidateAsync(request);

        var product = mapper.Map<Product>(request);        

        await productRepository.AddAsync(product);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }

    private async Task ValidateAsync(CreateProductCommand request)
    {
        _ = await categoryRepository.GetByIdAsync(request.CategoryId)
            ?? throw new DomainException($"Category with id {request.CategoryId} does not exists");
    }
}