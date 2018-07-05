using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity;

namespace ExMan.AWS.WebApi.Core
{
    public class DependencyFactory
    {

        private static IUnityContainer unityContainer;

        /// <summary>
        ///     Public reference to the unity container which will
        ///     allow the ability to register instrances or take
        ///     other actions on the container.
        /// </summary>
        public static IUnityContainer Container
        {
            get
            {
                if (unityContainer == null)
                {
                    unityContainer = new UnityContainer();
                }
                return unityContainer;
            }
            private set { unityContainer = value; }
        }

        /// <summary>
        ///     Resolves the type parameter T to an instance of the appropriate type.
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
        public static T Resolve<T>()
        {
            T ret = default(T);
            ret = Container.Resolve<T>();
            return ret;
        }

        /// <summary>
        ///     Resolve dependency by key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param> 
        /// <returns></returns>
        public static T Resolve<T>(string key)
        {
            T ret = default(T);
            ret = Container.Resolve<T>(key);

            return ret;
        }

    }
}
