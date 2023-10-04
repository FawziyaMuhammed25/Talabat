using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity 
    {
        Task<IEnumerable<T>> GetAllAsync(); // static query
        Task<T> GetByIdAsync(int id); // static query
        Task<IEnumerable<T>> GetAllWithSpecAsync(Ispecification<T> spec);
        Task<T> GetByIdWithSpecAsync(Ispecification<T> spec);
    }
}
