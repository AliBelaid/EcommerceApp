using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.identity.Extensions {
    public class UserParems:PaginationParems {
 
        public string CurrentUserName { get; set; }
        public string Gender { get; set; }
        public int MinAge { get; set; } = 18;

        public int MaxAge { get; set; } = 99;
        public string OrderBy { get; set; } ="lastActive";
        
        
  
    }
}