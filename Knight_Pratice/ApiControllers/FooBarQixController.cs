using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knight_Pratice.Interfaces;
using Knight_Pratice.Models;
using System.Text;

namespace Knight_Pratice.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooBarQixController : ControllerBase
    {
        private readonly IDateService _dateService;
        private readonly ILogger<FooBarQixController> _logger;

        public FooBarQixController(IDateService dateService, ILogger<FooBarQixController> logger)
        {
            _dateService = dateService;
            _logger = logger;
        }
        [HttpGet("{num:int}")]
        public async Task<Number.NumberSingleResult> GetNumber(int num)
        {
            StringBuilder inform = new StringBuilder(DateTime.Now.ToString());
            inform.Append($"FooBarQixController的GetNumber方法被呼叫，傳入參數為{num.ToString()}");

            _logger.LogWarning(2001, inform.ToString());

            var result = await _dateService.GetNumber(num);
            return result;
        }
    }
}
