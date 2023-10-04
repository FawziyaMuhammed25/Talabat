using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data.DataSeed
{
    public static class StoreContextSeed
    {
      public static async Task seedAsync (StoreContext dbcontext)
        {
            if (! dbcontext.ProductBrands.Any())
            {
                var BrandsData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/brands.json");
                var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);
                if (Brands?.Count>0)
                {
                    foreach (var brand in Brands)
                    {
                        await dbcontext.Set<ProductBrand>().AddAsync(brand);
                    }
                    await dbcontext.SaveChangesAsync();
                }

            }
            if (!dbcontext.ProductType.Any())
            {
                var DataTypes = File.ReadAllText("../Talabat.Repository/Data/DataSeed/types.json");
                var Types = JsonSerializer.Deserialize<List<ProductType>>(DataTypes);
                if (Types?.Count > 0)
                {
                    foreach (var type in Types)
                    {
                        await dbcontext.Set<ProductType>().AddAsync(type);
                    }
                    await dbcontext.SaveChangesAsync();
                }

            }
            if (!dbcontext.products.Any())
            {
                var DataPro = File.ReadAllText("../Talabat.Repository/Data/DataSeed/products.json");
                var Product = JsonSerializer.Deserialize<List<Product>>(DataPro);
                if (Product?.Count > 0)
                {
                    foreach (var p in Product)
                    {
                        await dbcontext.Set<Product>().AddAsync(p);
                    }
                    await dbcontext.SaveChangesAsync();
                }

            }
        }
    }
}
