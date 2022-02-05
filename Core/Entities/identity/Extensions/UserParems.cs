using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.identity.Extensions {
    public class UserParems {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        public string CurrentUserName { get; set; }
        public string Gender { get; set; }
        public int MinAge { get; set; } = 18;

        public int MaxAge { get; set; } = 99;
        public string OrderBy { get; set; } ="lastActive";
        
        
        private int _pageSize = 10;

        public int PageSize {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;

        }
    }
}