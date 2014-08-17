using System;
using System.Reflection;

namespace AppDomainCallbackExtensions
{
    public class CrossAppDomainActionCallback<TInput1, TInput2> : AbstractCrossAppDomainDelegateCallback
    {
        public CrossAppDomainActionCallback()
        {
        }

        public CrossAppDomainActionCallback(MethodInfo method, TInput1 input1, TInput2 input2)
            : base(method)
        {
            Input1 = input1;
            Input2 = input2;
        }

        public virtual TInput1 Input1 { get; set; }

        public virtual TInput2 Input2 { get; set; }

        protected override Type[] GetParameterTypes()
        {
            return new Type[] { typeof(TInput1), typeof(TInput2) };
        }

        protected override object[] GetParameterValues()
        {
            return new object[] { Input1, Input2 };
        }
    }
}
