using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knight_Pratice.Controllers;
using Knight_Pratice.Interfaces;
using static Knight_Pratice.Controllers.Employee;

namespace Knight_Pratice.Services
{
    public class EmployeeService : IEmployeeService
    {
        /// <summary>
        /// 讀取所有員工資料
        /// </summary>
        /// <returns></returns>
        public Task<Employee.EmployeeListResult> GetAll()
        {
            return Task.Run(() =>
            {
                Employee.EmployeeListResult result = new Employee.EmployeeListResult();
                result.EmployeeList = new List<Employee.EmployeeSingleResult>
                {
                    new EmployeeSingleResult
                    {
                        Id = 1,
                        Name="Jhen Ye",
                        Department="UPD",
                        Birth=new DateTime(1990,11,03)

                    },
                    new EmployeeSingleResult
                    {
                        Id=2,
                        Name="Jacko Chen",
                        Department="UPD",
                        Birth=new DateTime(1990,1,1)
                    },
                    new EmployeeSingleResult
                    {
                        Id=3,
                        Name="XianEn Lin",
                        Department="UPD",
                        Birth=new DateTime(2000,1,1)
                    }
                }.ToList();
                return result;
            });
        }

       
    }
}
