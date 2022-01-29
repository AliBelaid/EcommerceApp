using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.hr
{
    public class leaveType:BaseEntity
    {
            public string leaveTypeName { get; set; }
        public string leaveDays { get; set; }
     
    }
}