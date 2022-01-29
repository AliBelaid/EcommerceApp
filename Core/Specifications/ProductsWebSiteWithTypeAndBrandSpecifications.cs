using Core.Entities;

namespace Core.Specifications {
    public class ProductsWebSiteWithTypeAndBrandSpecifications : BaseSpecifications<ProductWebSite> {
        public ProductsWebSiteWithTypeAndBrandSpecifications()
         {
            AddInclude(x => x.images);
        

            // if(!string.IsNullOrEmpty(productParams.sort)){

            //     switch(productParams.sort) {
            //         case "priceAsc":
            //         AddOrderBy(p=>p.price);
            //         break;
            //          case "priceDesc":
            //         AddOrderByDescending(p=>p.price);
            //         break;
            //         default:
            //         AddOrderBy(x=>x.title);
            //         break;
            //     }
            // }

        }

        public ProductsWebSiteWithTypeAndBrandSpecifications (int id) : base (x => x.Id == id) {
              AddInclude(x => x.images);
       
        }
    }
}