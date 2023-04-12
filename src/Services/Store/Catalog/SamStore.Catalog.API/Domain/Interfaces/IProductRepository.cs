using SamStore.Catalog.API.Domain.Products;
using SamStore.Core.Infrastructure.Data;

namespace SamStore.Catalog.API.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product> { }
}
