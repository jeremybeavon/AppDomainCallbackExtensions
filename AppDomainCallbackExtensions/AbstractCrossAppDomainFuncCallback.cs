using System.Reflection;

namespace AppDomainCallbackExtensions
{
    public abstract class AbstractCrossAppDomainFuncCallback<TOutput> : AbstractCrossAppDomainDelegateCallback,
        ICrossAppDomainCallback<TOutput>
    {
        protected AbstractCrossAppDomainFuncCallback()
        {
        }

        protected AbstractCrossAppDomainFuncCallback(MethodInfo method)
            : base(method)
        {
        }

        public virtual TOutput Response { get; set; }

        protected sealed override void ProcessResponse(object response)
        {
            Response = (TOutput)response;
        }
    }
}
