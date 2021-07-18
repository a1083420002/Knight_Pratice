﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace Knight_Pratice.Helpers
{
    public class RedisCacheHelper
    {
        private readonly IDistributedCache _cache;

        public RedisCacheHelper(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetFromCache<T>(string key) where T : class
        {
            var cachedResponse = await _cache.GetStringAsync(key);
            return cachedResponse == null ? null : JsonSerializer.Deserialize<T>(cachedResponse);
        }
        public async Task SetCache<T>(string key, T value, DistributedCacheEntryOptions options) where T : class
        {
            var response = JsonSerializer.Serialize(value);
            await _cache.SetStringAsync(key, response, options);
        }
        public async Task ClearCache(string key)
        {
            await _cache.RemoveAsync(key);
        }
    }
}
