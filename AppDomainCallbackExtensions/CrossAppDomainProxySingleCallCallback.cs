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
    public class CrossAppDomainProxySingleCallCallback<T> : AbstractCrossAppDomainProxyCallback<T>
    {
        public CrossAppDomainProxySingleCallCallback()
        {
        }

        public CrossAppDomainProxySingleCallCallback(IMethodMessage message)
            : base(message)
        {
        }

#if !NET20
        [DataMember]
#endif
        public T Instance { get; set; }

        protected override T GetInstance()
        {
            return Instance;
        }
    }
}
