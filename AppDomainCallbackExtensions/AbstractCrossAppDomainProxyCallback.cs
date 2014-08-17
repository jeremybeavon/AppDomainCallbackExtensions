using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
#if !NET20
using System.Runtime.Serialization;
#endif

namespace AppDomainCallbackExtensions
{
    [Serializable]
#if !NET20
    [DataContract]
#endif
    public abstract class AbstractCrossAppDomainProxyCallback<T> : ICrossAppDomainCallback<object>
    {
        protected AbstractCrossAppDomainProxyCallback()
        {
        }

        protected AbstractCrossAppDomainProxyCallback(IMethodMessage message)
        {
            MethodBase method = message.MethodBase;
            MethodName = method.Name;
            ParameterInfo[] parameters = method.GetParameters();
            ParameterTypes = new string[parameters.Length];
            for (int index = 0; index < parameters.Length; index++)
            {
                ParameterTypes[index] = parameters[index].ParameterType.AssemblyQualifiedName;
            }

            ParameterValues = message.Args;
        }

#if !NET20
        [DataMember]
#endif
        public object Response { get; set; }

#if !NET20
        [DataMember]
#endif
        public string MethodName { get; set; }

#if !NET20
        [DataMember]
#endif
        public string[] ParameterTypes { get; private set; }

#if !NET20
        [DataMember]
#endif
        public object[] ParameterValues { get; set; }

        public void Callback()
        {
            T instance = GetInstance();
            Type[] parameterTypes = new Type[ParameterTypes.Length];
            for (int index = 0; index < parameterTypes.Length; index++)
            {
                parameterTypes[index] = Type.GetType(ParameterTypes[index], true);
            }

            MethodInfo method = instance.GetType().GetMethod(MethodName, parameterTypes);
            if (method == null)
            {
                throw new InvalidOperationException("Method not found.");
            }

            Response = method.Invoke(instance, ParameterValues);
        }

        protected abstract T GetInstance();
    }
}
