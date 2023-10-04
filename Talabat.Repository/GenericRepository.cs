using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _dbContext;

        public GenericRepository( StoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            //if (typeof(T) == typeof(Product))
            //{
            //    return (IEnumerable<T>) await _dbContext.Set<Product>().Include(p => p.productBrand)
            //                                          .Include(p => p.productType)
            //                                          .ToListAsync();
            //}
            return await _dbContext.Set<T>().ToListAsync();
        }
        private IQueryable<T> ApplySpecification(Ispecification<T> spec)
        {
            return SpecificationEvalutor<T>.GetQuery(_dbContext.Set<T>(), spec);
        }

        public async Task<IEnumerable<T>> GetAllWithSpecAsync(Ispecification<T> spec)
        {
            return  await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIdWithSpecAsync(Ispecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
    }
}
