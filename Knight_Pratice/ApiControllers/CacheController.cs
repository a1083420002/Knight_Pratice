using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knight_Pratice.Controllers;
using Knight_Pratice.Models;
using Knight_Pratice.Services;
using Microsoft.Extensions.Caching.Memory;

namespace Knight_Pratice.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public CacheController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        [HttpGet("{key}")]
        public Employee.EmployeeSingleResult Cache(string key)
        {
            _memoryCache.Set(key, new Employee.EmployeeSingleResult(){Id = 1,Department = "UPD2",Birth = new DateTime(2000,1,1),Name = "JhenYe"});
            
            return _memoryCache.Get(key) as Employee.EmployeeSingleResult;
            

            
        }

        [HttpGet]
        public Number.NumberSingleResult GetFileCache()
        {
            var numSingleResult = new Number.NumberSingleResult
            {
                Number = 1,
                Result = "1"
            };
            var list = CacheHelper.GetAll();
           

            CacheHelper.AddNumber(numSingleResult);

            var result = CacheHelper.GetInfo(1);

            return result;
        }

    }
}
