using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace PerFin.Desktop.Core
{
    internal class InMemoryCache: ICache
    {
        #region ICache Implementation

        /// <summary>
        /// Puts the item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="cacheItem">The state item.</param>
        public void Add<T>(string key, T value)
        {
            var cacheItemPolicy = new CacheItemPolicy();
            cacheItemPolicy.AbsoluteExpiration = DateTimeOffset.Now.AddDays(1);

            if (MemoryCache.Default[key] != null)
            {
                MemoryCache.Default[key] = value;
            }
            else
            {
                MemoryCache.Default.Add(key, value, cacheItemPolicy);
            }
        }

        /// <summary>
        /// Puts the item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="cacheItem"></param>
        /// <param name="slidingExpiration">The sliding expiration.</param>
        public void Add<T>(string key, T value, TimeSpan slidingExpiration)
        {
            var cacheItemPolicy = new CacheItemPolicy();
            cacheItemPolicy.SlidingExpiration = slidingExpiration;

            if (MemoryCache.Default[key] != null)
            {
                MemoryCache.Default[key] = value;
            }
            else
            {
                MemoryCache.Default.Add(key, value, cacheItemPolicy);
            }

        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            return (T)this.Get(key);
        }

        public object Get(string key)
        {
            return MemoryCache.Default.Get(key);
        }

        /// <summary>
        /// Removes the item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        public void Remove(string key)
        {
            MemoryCache.Default.Remove(key);
        }

        /// <summary>
        /// Clears the state.
        /// </summary>
        public void RemoveAll()
        {
            MemoryCache.Default.Dispose();
        }

        #endregion
    }
}
