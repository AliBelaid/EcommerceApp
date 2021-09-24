using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository {
        private readonly StoreContext _ctx;
        public ProductRepository (StoreContext ctx) {
            _ctx = ctx;
        }

    

        public async  Task<Product> GetProductByIdAsync(int id) {
        return await _ctx.Products.Include(i=>i.ProductBrand).Include(i=>i.ProductType).SingleOrDefaultAsync(i=>i.Id==id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync() {
        return await _ctx.Products.Include(i=>i.ProductBrand).Include(i=>i.ProductType).ToListAsync();
        }

     public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
      {
       return await _ctx.ProductType.ToListAsync();
      }    public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
       {
               return await _ctx.ProductBrand.ToListAsync();
        }
    }
}