using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text.Json;
using System.Threading.Tasks;
using Knight_Pratice.Interfaces;
using Knight_Pratice.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace Knight_Pratice.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDateService _fooBarQixService;
        private readonly IDistributedCache _cache;
        public CacheService(IDateService fooBarQixService, IMemoryCache memoryCache, IInputService inputService, IDistributedCache cache)
        {
            _fooBarQixService = fooBarQixService;
            _cache = cache;
        }

        public Number.NumberSingleResult InsertData()
        {
            var numSingleResult = _fooBarQixService.GetRandom();
            
            var result= FileCacheHelper.AddNumber(numSingleResult);

            return result;
        }

        public Number.NumberSingleResult GetData()
        {
            var newRandom = _fooBarQixService.GetRandom();
            var stringArr = FileCacheHelper.ReadFile(newRandom);

            var result = new Number.NumberSingleResult
            {
                Number = int.Parse(stringArr[0]),
                Result = stringArr[1]
            };


            return result;
        }

        public void InsertData<T>(string key,T value, DistributedCacheEntryOptions options) where T : class
        {
           
        }

        public T GetData<T>(string key) where T : class
        {
            var response = _cache.GetString(key);
            return response == null ? null : JsonSerializer.Deserialize<T>(response);
        }

        public void ClearCache(string key)
        {

        }
    }
}
