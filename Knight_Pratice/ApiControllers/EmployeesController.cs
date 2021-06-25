using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Knight_Pratice.Controllers;
using Knight_Pratice.Interfaces;
using Knight_Pratice.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Knight_Pratice.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(IEmployeeService employeeService, ILogger<EmployeesController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }
        /// <summary>
        /// 得到所有員工資料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<BaseViewModel.BaseResult<Employee.EmployeeListResult>> GetAll()
        {
            var result = new BaseViewModel.BaseResult<Employee.EmployeeListResult>();
            StringBuilder inform = new StringBuilder(DateTime.Now.ToString());
            inform.Append("EmployeesController的GetAll方法被呼叫");

            _logger.LogWarning(2001, inform.ToString());

            try
            {
                result.Body = await _employeeService.GetAll();
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Msg = ex.Message;
                return result;
            }
        }
        
    }

}
