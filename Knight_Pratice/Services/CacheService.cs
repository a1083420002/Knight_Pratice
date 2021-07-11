using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;
using Knight_Pratice.Interfaces;
using Knight_Pratice.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Knight_Pratice.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDateService _fooBarQixService;

        public CacheService(IDateService fooBarQixService, IMemoryCache memoryCache, IInputService inputService)
        {
            _fooBarQixService = fooBarQixService;
        }

        public Number.NumberSingleResult InsertData()
        {
            var numSingleResult = _fooBarQixService.GetRandom();
            
            var result= CacheHelper.AddNumber(numSingleResult);

            return result;
        }

        public Number.NumberSingleResult GetData()
        {
            var newRandom = _fooBarQixService.GetRandom();
            var stringArr = CacheHelper.ReadFile(newRandom);

            var result = new Number.NumberSingleResult
            {
                Number = int.Parse(stringArr[0]),
                Result = stringArr[1]
            };


            return result;
        }
    }
}
