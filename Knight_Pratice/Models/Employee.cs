using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Knight_Pratice.Controllers
{
    public class Employee
    {
        public class EmployeeBaseModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public DateTime Birth { get; set; }
        }
        

        public class EmployeeSingleResult : EmployeeBaseModel
        {

        }
        public class EmployeeListResult 
        {
            public List<EmployeeSingleResult> EmployeeList { get; set; }
        }
    }

   
}
