using SamStore.Catalogo.API.Domain.Products;
using SamStore.Core.Infrastructure.Data;

namespace SamStore.Catalogo.API.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product> { }
}
