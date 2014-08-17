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
    public class CrossAppDomainFuncCallback<TInput, TOutput> : AbstractCrossAppDomainFuncCallback<TOutput>
    {
        public CrossAppDomainFuncCallback()
        {
        }

        public CrossAppDomainFuncCallback(MethodInfo method, TInput input)
            : base(method)
        {
            Input = input;
        }

#if !NET20
        [DataMember]
#endif
        public virtual TInput Input { get; set; }

        protected override Type[] GetParameterTypes()
        {
            return new Type[] { typeof(TInput) };
        }

        protected override object[] GetParameterValues()
        {
            return new object[] { Input };
        }
    }
}
