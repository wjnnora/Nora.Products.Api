using AutoMapper;
using Nora.Products.Domain.Command.Commands.v1.Products.Create;
using Nora.Products.Domain.Entities;

namespace Nora.Products.Domain.Command.Mappers;

public sealed class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductCommand, Product>();                  
    }
}