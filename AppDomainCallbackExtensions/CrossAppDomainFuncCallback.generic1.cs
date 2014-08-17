using System;
using System.Reflection;

namespace AppDomainCallbackExtensions
{
    [Serializable]
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
