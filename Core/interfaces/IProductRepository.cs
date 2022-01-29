using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.interfaces
{
    public interface IProductRepository
    {
        Task<ProductWebSite> GetProductByIdAsync(int id);
        Task<IReadOnlyList<ProductWebSite>> GetProductsAsync();
        
      Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        
      Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}