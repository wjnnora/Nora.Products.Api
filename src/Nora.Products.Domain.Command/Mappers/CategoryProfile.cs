using AutoMapper;
using Nora.Products.Domain.Command.Commands.v1.Categories.Create;
using Nora.Products.Domain.Entities;

namespace Nora.Products.Domain.Command.Mappers;

public sealed class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CreateCategoryCommand, Category>();
    }
}