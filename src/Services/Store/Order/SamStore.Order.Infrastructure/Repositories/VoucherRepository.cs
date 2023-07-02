using Microsoft.EntityFrameworkCore;
using SamStore.Core.Infrastructure.Data;
using SamStore.Order.Domain.Interfaces;
using SamStore.Order.Domain.Vouchers;
using SamStore.Order.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Order.Infrastructure.Repositories
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly OrderContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public VoucherRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task<List<Voucher>> FindAsync(Expression<Func<Voucher, bool>> predicate)
        {
            return await _context.Vouchers.Where(predicate).ToListAsync();
        }

        public async Task<Voucher> FirstOrDefaultAsync(Expression<Func<Voucher, bool>> predicate)
        {
            return await _context.Vouchers.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<Voucher>> GetAllAsync()
        {
            return await _context.Vouchers.ToListAsync();
        }

        public async Task<Voucher> GetByIdAsync(Guid id)
        {
            return await _context.Vouchers.FindAsync(id);
        }

        public IRepository<Voucher> Include(params string[] includes)
        {
            foreach (string include in includes)
            {
                _context.Vouchers.Include(include);
            }

            return this;
        }

        public void Insert(Voucher entity)
        {
            _context.Vouchers.Add(entity);
        }

        public void Update(Voucher entity)
        {
            _context.Vouchers.Update(entity);
        }

        public void Delete(Voucher entity)
        {
            _context.Vouchers.Remove(entity);
        }

        public void DeleteRangeAsync(Expression<Func<Voucher, bool>> predicate)
        {
            var entities = _context.Vouchers.Where(predicate);

            if (!entities.Any())
                return;

            _context.RemoveRange(entities);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
