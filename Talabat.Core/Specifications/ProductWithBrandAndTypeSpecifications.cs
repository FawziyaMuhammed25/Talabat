using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
    public class ProductWithBrandAndTypeSpecifications: BaseSpecification<Product>
    {
        // this constructor is used for get all Products 
        public ProductWithBrandAndTypeSpecifications()
        {
            Includes.Add(p => p.productBrand);
            Includes.Add(p => p.productType);
        }

        // this constructor is used for get  Product By Id
        public ProductWithBrandAndTypeSpecifications(int id ):base(p => p.Id == id)
        {
            Includes.Add(p => p.productBrand);
            Includes.Add(p => p.productType);
        }
    }
}
