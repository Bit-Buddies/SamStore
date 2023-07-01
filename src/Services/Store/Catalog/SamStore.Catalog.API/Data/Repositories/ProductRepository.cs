using Microsoft.EntityFrameworkCore;
using SamStore.Catalog.API.Data.Contexts;
using SamStore.Catalog.API.Domain.Interfaces;
using SamStore.Catalog.API.Domain.Products;
using SamStore.Core.Infrastructure.Data;
using System.Linq.Expressions;

namespace SamStore.Catalog.API.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogDbContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ProductRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public IRepository<Product> Include(params string[] includes)
        {
            foreach (string include in includes)
            {
                _context.Products.Include(include);
            }

            return this;
        }

        public void Insert(Product entity)
        {
            _context.Products.Add(entity);
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
        }

        public void Delete(Product entity)
        {
            _context.Products.Remove(entity);
        }

        public async Task<List<Product>> FindAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _context.Products.Where(predicate).ToListAsync();
        }

        public async Task<Product> FirstOrDefaultAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _context.Products.FirstOrDefaultAsync(predicate);
        }

        public void DeleteRangeAsync(Expression<Func<Product, bool>> predicate)
        {
            var entities = _context.Products.Where(predicate);

            _context.RemoveRange(entities);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
