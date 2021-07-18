using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Knight_Pratice.Interfaces;
using Knight_Pratice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Knight_Pratice.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumbersController : ControllerBase
    {
        private readonly IDateService _dateService;
        private readonly ILogger<NumbersController> _logger;
        private readonly ICacheService _cacheService;
        public NumbersController(IDateService dateService, ILogger<NumbersController> logger, ICacheService cacheService)
        {
            _dateService = dateService;
            _logger = logger;
            _cacheService = cacheService;
        }
        [HttpGet("{input:int}")]
        public async Task<Number.NumberSingleResult> GetNumber(int input)
        {
            StringBuilder inform = new StringBuilder(DateTime.Now.ToString());
            inform.Append($"NumbersController的GetNumber方法被呼叫，傳入參數為{input.ToString()}");

            _logger.LogWarning(2001, inform.ToString());

            var result = await _dateService.GetResultAsync(input);

            return result;
        }
        [Route("api/[controller]/InsertData")]
        [HttpGet]
        public Number.NumberSingleResult InsertData()
        {
            StringBuilder inform = new StringBuilder(DateTime.Now.ToString());
            inform.Append($"NumbersController的InsertData方法被呼叫");

            _logger.LogWarning(2001, inform.ToString());

            var result = _cacheService.InsertData();

            return result;
        }

        [Route("api/[controller]/GetData")]
        [HttpGet]
        public Number.NumberSingleResult GetData()
        {
            StringBuilder inform = new StringBuilder(DateTime.Now.ToString());
            inform.Append($"NumbersController的GetData方法被呼叫");

            _logger.LogWarning(2001, inform.ToString());

            var result = _dateService.GetResult();

            return result;
        }
    }
}
