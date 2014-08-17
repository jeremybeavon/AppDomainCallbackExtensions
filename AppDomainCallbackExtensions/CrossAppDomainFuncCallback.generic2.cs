using System;
using System.Reflection;

namespace AppDomainCallbackExtensions
{
    [Serializable]
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
