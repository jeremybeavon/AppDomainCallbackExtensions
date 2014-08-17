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
    public class CrossAppDomainFuncCallback<TInput1, TInput2, TInput3, TInput4, TOutput> :
        CrossAppDomainFuncCallback<TInput1, TInput2, TInput3, TOutput>
    {
        public CrossAppDomainFuncCallback()
        {
        }

        public CrossAppDomainFuncCallback(MethodInfo method, TInput1 input1, TInput2 input2, TInput3 input3, TInput4 input4)
            : base(method, input1, input2, input3)
        {
            Input4 = input4;
        }

#if !NET20
        [DataMember]
#endif
        public virtual TInput4 Input4 { get; set; }

        protected override Type[] GetParameterTypes()
        {
            return new Type[] { typeof(TInput1), typeof(TInput2), typeof(TInput3), typeof(TInput4) };
        }

        protected override object[] GetParameterValues()
        {
            return new object[] { Input1, Input2, Input3, Input4 };
        }
    }
}
