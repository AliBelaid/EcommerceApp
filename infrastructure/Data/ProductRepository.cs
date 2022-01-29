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

    

        public async  Task<ProductWebSite> GetProductByIdAsync(int id) {
        return await _ctx.ProductsWebSite.Include(i=>i.images).Include(i=>i.tags).SingleOrDefaultAsync(i=>i.Id==id);
        }

        public async Task<IReadOnlyList<ProductWebSite>> GetProductsAsync() {
        return await _ctx.ProductsWebSite.Include(i=>i.images).Include(i=>i.tags).ToListAsync();
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