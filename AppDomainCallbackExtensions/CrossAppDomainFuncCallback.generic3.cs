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
    public class CrossAppDomainFuncCallback<TInput1, TInput2, TOutput> : AbstractCrossAppDomainFuncCallback<TOutput>
    {
        public CrossAppDomainFuncCallback()
        {
        }

        public CrossAppDomainFuncCallback(MethodInfo method, TInput1 input1, TInput2 input2)
            : base(method)
        {
            Input1 = input1;
            Input2 = input2;
        }

#if !NET20
        [DataMember]
#endif
        public virtual TInput1 Input1 { get; set; }

#if !NET20
        [DataMember]
#endif
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
