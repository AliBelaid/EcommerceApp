using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.hr
{
     public class   Holidays :BaseEntity
    {
         public string title { get; set; }
        public string holidaydate { get; set; }
        public string day { get; set; }
    }


}