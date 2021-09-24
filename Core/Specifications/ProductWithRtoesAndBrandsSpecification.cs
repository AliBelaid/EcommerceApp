using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecification :BaseSpecifications<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams) :  
         base(x=> ((!productParams.BrandId.HasValue || x.ProductBrandId==productParams.BrandId) && (!productParams.TypeId.HasValue ||x.ProductTypeId==productParams.TypeId)
         
          && (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search))
        ))
         
          {
          
         }}
}