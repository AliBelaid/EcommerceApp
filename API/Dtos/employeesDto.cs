using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
  
            public class employeesDto
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }
        public string department { get; set; }
        public string designation { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string joindate { get; set; }
        public string role { get; set; }
        public string employeeId { get; set; }
        public string company { get; set; }
        public int id { get; set; }
    }
     
}