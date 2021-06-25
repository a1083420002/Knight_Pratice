using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knight_Pratice.Controllers;


namespace Knight_Pratice.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee.EmployeeListResult> GetAll();

       
    }
}
