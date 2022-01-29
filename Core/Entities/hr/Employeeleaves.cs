using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.hr
{
      public class Employeeleaves
    {
        public int id { get; set; }
        public string employeeName { get; set; }
        public string designation { get; set; }
        public string leaveType { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string noofDays { get; set; }
        public string remainleaves { get; set; }
        public string reason { get; set; }
        public string status { get; set; }
    }


}