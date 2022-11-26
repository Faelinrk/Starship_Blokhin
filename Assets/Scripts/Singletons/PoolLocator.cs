using System;
using System.Collections.Generic;
using UnityEngine;

namespace SorryForSingletons
{
    public static class PoolLocator
    {
        private static readonly Dictionary<Type, object> _poolsContainer = new Dictionary<Type, object>();

        public static void SetPool<IPoolable>(IPoolable pool)
        {
            var typeofPool = typeof(IPoolable);
            if (!_poolsContainer.ContainsKey(typeofPool))
            {
                Debug.Log("Pool has been set");
                _poolsContainer[typeofPool] = pool;
            }
        }

        public static IPoolable Resolve<IPoolable>()
        {
            var typeofPool = typeof(IPoolable);
            if (_poolsContainer.ContainsKey(typeofPool))
            {
                Debug.Log("Pool has been resolved");
                return (IPoolable)_poolsContainer[typeofPool];
            }
            return default;
        }
    }

}
