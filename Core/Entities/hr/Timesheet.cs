using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.hr
{
      public class       Timesheet  
    {
        public int id { get; set; }
        public string employee { get; set; }
        public string designation { get; set; }
        public string date { get; set; }
        public string deadline { get; set; }
        public string project { get; set; }
        public string assignedhours { get; set; }
        public string hrs { get; set; }
        public string description { get; set; }
    }


}