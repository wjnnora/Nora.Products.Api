using AutoMapper;
using MediatR;
using Nora.Core.Database.Contracts;
using Nora.Core.Database.Contracts.Repositories;
using Nora.Core.Domain.Exceptions;
using Nora.Products.Domain.Contracts.Repositories;
using Nora.Products.Domain.Entities;

namespace Nora.Products.Domain.Command.Commands.v1.Categories.Create;

public sealed class CreateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork<ISqlContext> unitOfWork,
    IMapper mapper) : IRequestHandler<CreateCategoryCommand, Unit>
{
    public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await ValidateAsync(request);

        var category = mapper.Map<Category>(request);

        await categoryRepository.AddAsync(category);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }

    private async Task ValidateAsync(CreateCategoryCommand request)
    {
        var categories = await categoryRepository.GetByDescriptionAsync(request.Description);

        if (categories.Any())
            throw new DomainException($"Category with description {request.Description} already exists");
    }
}