using System;
using System.Runtime.Remoting.Messaging;
#if !NET20
using System.Runtime.Serialization;
#endif

namespace AppDomainCallbackExtensions
{
    [Serializable]
#if !NET20
    [DataContract]
#endif
    public class CrossAppDomainProxySingletonCallback<T> : AbstractCrossAppDomainProxyCallback<T>
    {
        public CrossAppDomainProxySingletonCallback()
        {
        }

        public CrossAppDomainProxySingletonCallback(IMethodMessage message)
            : base(message)
        {
        }

#if !NET20
        [DataMember]
#endif
        public Guid ProxyId { get; set; }

        protected override T GetInstance()
        {
            return CrossAppDomainProxyHelper.GetInstance<T>(ProxyId);
        }
    }
}
