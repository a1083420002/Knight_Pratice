using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace WinForms_MemoryCache
{
    public class CacheHelper
    {
        public static IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());
        /// <summary>
        /// 快取絕對過期時間 : 時間到後就會消失
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="min">The minimum.</param>
        public static void CacheInsertAddMin(string key, object value, int min)
        {
            if(value==null)
                return;
            _memoryCache.Set(key, value,
                new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(min)));
        }
        /// <summary>
        /// 快取相對過期時間：每次讀取值後會重新計算過期時間
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="min">The minimum.</param>
        public static void CacheInsertFromMin(string key, object value, int min)
        {
            if (value == null)
                return;
            _memoryCache.Set(key, value,
                new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(min)));
        }
        /// <summary>
        /// 以 Key : Value 保存快取。如果不主動清空，就會保存在記憶體中
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void CacheInsert(string key, object value)
        {
            _memoryCache.Set(key, value);
        }
        /// <summary>
        /// 移除快取
        /// </summary>
        /// <param name="key">The key.</param>
        public static void CacheRemove(string key)
        {
            _memoryCache.Remove(key);
        }
        /// <summary>
        /// 根據 Key ，返回 Value 快取
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static object CacheRead(string key)
        {
            return _memoryCache.Get(key);
        }

    }
}
