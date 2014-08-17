using System;
using System.Reflection;
#if !NET20
using System.Runtime.Serialization;
#endif

namespace AppDomainCallbackExtensions
{
    [Serializable]
#if !NET20
    [DataContract]
#endif
    public abstract class AbstractCrossAppDomainFuncCallback<TOutput> : AbstractCrossAppDomainDelegateCallback,
        ICrossAppDomainCallback<TOutput>
    {
        protected AbstractCrossAppDomainFuncCallback()
        {
        }

        protected AbstractCrossAppDomainFuncCallback(MethodInfo method)
            : base(method)
        {
        }

#if !NET20
        [DataMember]
#endif
        public virtual TOutput Response { get; set; }

        protected sealed override void ProcessResponse(object response)
        {
            Response = (TOutput)response;
        }
    }
}
