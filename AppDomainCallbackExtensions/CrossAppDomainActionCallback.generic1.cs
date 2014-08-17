using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AppDomainCallbackExtensions
{
    public class CrossAppDomainActionCallback<TInput> : AbstractCrossAppDomainDelegateCallback
    {
        public CrossAppDomainActionCallback()
        {
        }

        public CrossAppDomainActionCallback(MethodInfo method, TInput input)
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
