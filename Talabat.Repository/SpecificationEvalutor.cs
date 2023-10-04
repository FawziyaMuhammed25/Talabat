using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Repository
{
    public sealed class SpecificationEvalutor<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery , Ispecification<TEntity> specfication)
        {
            var query = inputQuery; // _dbContext.Products
            if (specfication.Criteria is not null)
                query = query.Where(specfication.Criteria);
            query = specfication.Includes.Aggregate(query, (currentQuery, includeEx) => currentQuery.Include(includeEx)); // _dbContext.Products.where(p=>p.id).include(p=>p.productBrand)
            return query; 
        }
    }
}
