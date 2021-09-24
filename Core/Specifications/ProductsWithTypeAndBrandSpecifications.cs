using Core.Entities;

namespace Core.Specifications {
    public class ProductsWithTypeAndBrandSpecifications : BaseSpecifications<Product> {
        public ProductsWithTypeAndBrandSpecifications(ProductSpecParams productParams):
        base(x=> ((!productParams.BrandId.HasValue || x.ProductBrandId==productParams.BrandId) && 
        (!productParams.TypeId.HasValue ||x.ProductTypeId==productParams.TypeId)
       && (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search))
        )) {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x=>x.Name);
                            ApplayPaging(productParams.PageSize*(productParams.PageIndex-1),productParams.PageSize);

            if(!string.IsNullOrEmpty(productParams.sort)){

                switch(productParams.sort) {
                    case "priceAsc":
                    AddOrderBy(p=>p.Price);
                    break;
                     case "priceDesc":
                    AddOrderByDescending(p=>p.Price);
                    break;
                    default:
                    AddOrderBy(x=>x.Name);
                    break;
                }
            }

        }

        public ProductsWithTypeAndBrandSpecifications (int id) : base (x => x.Id == id) {
            AddInclude (x => x.ProductType);
            AddInclude (x => x.ProductBrand);
        }
    }
}