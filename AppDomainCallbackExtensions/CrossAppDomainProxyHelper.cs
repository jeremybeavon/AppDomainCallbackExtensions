using System;
using System.Collections.Generic;

namespace AppDomainCallbackExtensions
{
    public static class CrossAppDomainProxyHelper
    {
        private static readonly object SingletonInstanceLock = new object();

        private static readonly IDictionary<Guid, object> SingletonInstances =
            new Dictionary<Guid, object>();

        public static void RegisterSingletonInstance(Guid proxyId, object instance)
        {
            lock (SingletonInstanceLock)
            {
                if (SingletonInstances.ContainsKey(proxyId))
                {
                    throw new ArgumentException(
                        string.Format("Singleton instance already exists for proxyId {0}", proxyId),
                        "proxyId");
                }

                SingletonInstances.Add(proxyId, instance);
            }
        }

        public static T GetInstance<T>(Guid proxyId)
        {
            lock (SingletonInstanceLock)
            {
                object singleton;
                if (!SingletonInstances.TryGetValue(proxyId, out singleton))
                {
                    throw new ArgumentException(
                        string.Format("Singleton instance not found for proxyId {0}", proxyId),
                        "proxyId");
                }

                if (!(singleton is T))
                {
                    throw new ArgumentException(
                        string.Format("Singleton instance is wrong type for proxyId {0}", proxyId),
                        "proxyId");
                }

                return (T)singleton;
            }
        }
    }
}
