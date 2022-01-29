using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductWebDto
    {
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
  
         public List<String>   tags { get; set; }
 

        public IReadOnlyList<ImageDto> images { get; set; } 
    }

 public class ImageDto
    {  
        public string alt { get; set; }
        public string src { get; set; }
 
    }





}