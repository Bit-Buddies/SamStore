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

        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
        }

        public void Update(Customer entity)
        {
            _context.Customers.Update(entity);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Customer> GetById(Guid id)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Customer> GetByCPF(string cPF)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.CPF.Number == cPF); 
        }
    }
}
