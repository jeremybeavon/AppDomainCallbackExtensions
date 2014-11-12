using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using TextSerialization;

namespace AppDomainCallbackExtensions
{
    public class CrossAppDomainProxy<T, TInterface, TSerializer> : RealProxy, IRemotingTypeInfo
        where T : TInterface
        where TSerializer : ITextSerialization, new()
    {
        private readonly AppDomain domain;
        private readonly T instance;
        private readonly WellKnownObjectMode mode;
        private readonly TSerializer serializer;

        public CrossAppDomainProxy(AppDomain domain, T instance, WellKnownObjectMode mode, TSerializer serializer)
            : base(typeof(ContextBoundObject))
        {
            this.domain = domain;
            ProxyId = Guid.NewGuid();
            this.instance = instance;
            this.mode = mode;
            this.serializer = serializer;
            if (mode == WellKnownObjectMode.Singleton)
            {
                AppDomainCallbackExtensions.DoCallBack(
                    domain,
                    ProxyId,
                    (object)instance,
                    CrossAppDomainProxyHelper.RegisterSingletonInstance,
                    serializer);
            }
        }

        public Guid ProxyId { get; private set; }

        public string TypeName
        {
            get { return typeof(TInterface).FullName; }
            set { }
        }

        public virtual bool CanCastTo(Type fromType, object o)
        {
            return fromType == typeof(TInterface);
        }

        public override IMessage Invoke(IMessage msg)
        {
            IMethodCallMessage message = msg as IMethodCallMessage;
            if (message == null)
            {
                throw new ArgumentException("msg must be IMethodCallMessage", "msg");
            }

            object response = null;
            if (mode == WellKnownObjectMode.SingleCall)
            {
                response = AppDomainCallbackExtensions.DoCallBackWithResponse<CrossAppDomainProxySingleCallCallback<T>, TSerializer, object>(
                    domain,
                    new CrossAppDomainProxySingleCallCallback<T>(message),
                    serializer);
            }
            else if (mode == WellKnownObjectMode.Singleton)
            {
                response = AppDomainCallbackExtensions.DoCallBackWithResponse<CrossAppDomainProxySingletonCallback<T>, TSerializer, object>(
                    domain,
                    new CrossAppDomainProxySingletonCallback<T>(message, ProxyId),
                    serializer);
            }

            return new ReturnMessage(response, message.Args, message.ArgCount, message.LogicalCallContext, message);
        }
    }
}
