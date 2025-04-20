using Nora.Core.Domain.Contracts.Repositories;
using Nora.Products.Domain.Entities;

namespace Nora.Products.Domain.Contracts.Repositories;

public interface IProductRepository : IRepository<Product, int>;