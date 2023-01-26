using SamStore.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Core.Infrastructure.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        void Add(T entity);
        void Update(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        IUnitOfWork UnitOfWork { get; }
    }
}
