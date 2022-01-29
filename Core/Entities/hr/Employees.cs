using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.hr
{
    public class Employees: BaseEntity
    { 
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
   

        public  Departments Departments { get; set; }
        public int DepartmentsId { get; set; }
        public  Designation Designation { get; set; }
        public int DesignationId { get; set; }
    
        public string phone { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string joindate { get; set; }
        public string role { get; set; }
        public string employeeId { get; set; }
        public string company { get; set; }
      
    }

    
}