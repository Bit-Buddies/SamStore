using Microsoft.EntityFrameworkCore;
using SamStore.Costumer.Domain.Customers;
using SamStore.Costumer.Domain.Interfaces;
using SamStore.Costumer.Infrastructure.Contexts;
using SamStore.Core.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SamStore.Costumer.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetByCPF(string cPF)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.CPF.Number == cPF); 
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<List<Customer>> FindAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await _context.Customers.Where(predicate).ToListAsync();
        }

        public async Task<Customer> FirstOrDefaultAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await _context.Customers.FirstOrDefaultAsync(predicate);
        }

        public IRepository<Customer> Include(params string[] includes)
        {
            foreach (string include in includes)
            {
                _context.Customers.Include(include);
            }

            return this;
        }

        public void Insert(Customer entity)
        {
            _context.Customers.Add(entity);
        }

        public void Update(Customer entity)
        {
            _context.Customers.Update(entity);
        }

        public void Delete(Customer entity)
        {
            _context.Customers.Remove(entity);
        }

        public void DeleteRangeAsync(Expression<Func<Customer, bool>> predicate)
        {
            var entities = _context.Customers.Where(predicate);

            if (!entities.Any())
                return;

            _context.Customers.RemoveRange(entities);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
