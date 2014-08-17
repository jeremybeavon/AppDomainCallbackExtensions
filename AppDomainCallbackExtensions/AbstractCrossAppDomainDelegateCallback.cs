using System;
using System.Reflection;

namespace AppDomainCallbackExtensions
{
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

        public virtual string AssemblyPath { get; set; }

        public virtual string TypeName { get; set; }

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
