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
    public class CrossAppDomainFuncCallback<TInput1, TInput2, TInput3, TOutput> :
        CrossAppDomainFuncCallback<TInput1, TInput2, TOutput>
    {
        public CrossAppDomainFuncCallback()
        {
        }

        public CrossAppDomainFuncCallback(MethodInfo method, TInput1 input1, TInput2 input2, TInput3 input3)
            : base(method, input1, input2)
        {
            Input3 = input3;
        }

#if !NET20
        [DataMember]
#endif
        public virtual TInput3 Input3 { get; set; }

        protected override Type[] GetParameterTypes()
        {
            return new Type[] { typeof(TInput1), typeof(TInput2), typeof(TInput3) };
        }

        protected override object[] GetParameterValues()
        {
            return new object[] { Input1, Input2, Input3 };
        }
    }
}
