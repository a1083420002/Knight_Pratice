using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Knight_Pratice.Interfaces;
using Knight_Pratice.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace Knight_Pratice.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public Number.NumberSingleResult GetData()
        {
            var num = new Number.NumberSingleResult {Number = 1, Result = "1"};

            return num;
        }

        public void InsertData<T>(string key,T value, DistributedCacheEntryOptions options) where T : class
        {
           
           var response = JsonSerializer.Serialize(value);

            _cache.SetString(key,response,options);

        }

        public T GetData<T>(string key) where T : class
        {
            var response = _cache.GetString(key);
            return response == null ? null : JsonSerializer.Deserialize<T>(response);
        }

        public void ClearCache(string key)
        {
             _cache.Remove(key);
        }

        public Number.NumberSingleResult InsertData()
        {
            var key = "key";

            var numSingleResult = new Number.NumberSingleResult {Number = 1, Result = "1"};

          

            return numSingleResult;
        }
    }
}
