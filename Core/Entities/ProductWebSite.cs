using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
  
    public class ProductWebSite :BaseEntity
    {
public ProductWebSite()
{
    
}
  
        public ProductWebSite(string title, string type, string category, bool sale, int stock, IReadOnlyList<Image> images, string[] tags) 
        {
            this.title = title;
    this.type = type;
    this.category = category;
    this.sale = sale;
    this.stock = stock;
   this.images = images;
   this.tags=tags;
        }
                public string title { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string brand { get; set; }

        public string category { get; set; }
        public int price { get; set; }
        public bool sale { get; set; }
        public string discount { get; set; }
        public int stock { get; set; }
        public bool news { get; set; }
  
         public string[] tags { get; set; }
 

        public IReadOnlyList<Image> images { get; set; } 
     

     
    }
 
 





 
    public class Image:BaseEntity
    { 
       public   ProductWebSite  ProductWebSite { get; set; }
        public int ProductWebSiteId { get; set; }
  
        public string alt { get; set; }
        public string src { get; set; }
 
    }

   

}