using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerFin.Desktop.Core
{
    public interface ICache
    {
        /// <summary>
        /// Adds or replaces an object in the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void Add<T>(string key, T value);

        /// <summary>
        /// Adds or replaces an object in the cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void Add<T>(string key, T value, TimeSpan slidingExpiration);

        /// <summary>
        /// Gets an object from the cache using the specified key.
        /// </summary>
        /// <typeparam name="T">Generic Type.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>object from the cache </returns>
        T Get<T>(string key);

        /// <summary>
        /// Gets an object from the cache using the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>object from the cache.</returns>
        object Get(string key);

        /// <summary>
        /// Removes the object from the cache using the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        void Remove(string key);

        /// <summary>
        /// Removes all objects from the cache.
        /// </summary>
        void RemoveAll();
    }

}
