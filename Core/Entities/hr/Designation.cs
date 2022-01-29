using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.hr
{
    public class Designation:BaseEntity
    {
        public string DesignationName { get; set; }
        
   public  Departments Departments { get; set; }
        public int DepartmentsId { get; set; }

    }
}