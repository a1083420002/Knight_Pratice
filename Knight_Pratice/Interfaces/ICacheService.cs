using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knight_Pratice.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace Knight_Pratice.Interfaces
{
    public interface ICacheService
    {
        public Number.NumberSingleResult InsertData();

        public Number.NumberSingleResult GetData();

        public void InsertData<T>(string key, T value, DistributedCacheEntryOptions options) where T : class;
        public T GetData<T>(string key) where T : class;
        public void ClearCache(string key);

    }
}
