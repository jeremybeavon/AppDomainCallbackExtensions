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
    public class CrossAppDomainFuncCallback<TOutput> : AbstractCrossAppDomainFuncCallback<TOutput>
    {
        public CrossAppDomainFuncCallback()
        {
        }

        public CrossAppDomainFuncCallback(MethodInfo method)
            : base(method)
        {
        }

        protected override Type[] GetParameterTypes()
        {
            return new Type[0];
        }

        protected override object[] GetParameterValues()
        {
            return new object[0];
        }
    }
}
