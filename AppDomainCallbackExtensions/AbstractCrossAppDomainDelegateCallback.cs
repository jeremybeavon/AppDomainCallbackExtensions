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
    public abstract class AbstractCrossAppDomainDelegateCallback : ICrossAppDomainCallback
    {
        private const BindingFlags Flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

        protected AbstractCrossAppDomainDelegateCallback()
        {
        }

        protected AbstractCrossAppDomainDelegateCallback(MethodInfo method)
        {
            AssemblyPath = method.DeclaringType.Assembly.Location;
            TypeName = method.DeclaringType.FullName;
            MethodName = method.Name;
        }

#if !NET20
        [DataMember]
#endif
        public virtual string AssemblyPath { get; set; }

#if !NET20
        [DataMember]
#endif
        public virtual string TypeName { get; set; }

#if !NET20
        [DataMember]
#endif
        public virtual string MethodName { get; set; }

        public void Callback()
        {
            Assembly assembly = Assembly.LoadFrom(AssemblyPath);
            Type type = assembly.GetType(TypeName, true);
            MethodInfo method = type.GetMethod(MethodName, Flags, null, GetParameterTypes(), null);
            if (method == null)
            {
                throw new InvalidOperationException("Method not found");
            }

            ProcessResponse(method.Invoke(null, GetParameterValues()));
        }

        protected abstract Type[] GetParameterTypes();

        protected abstract object[] GetParameterValues();

        protected virtual void ProcessResponse(object response)
        {
        }
    }
}
