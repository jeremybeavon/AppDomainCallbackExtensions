namespace AppDomainCallbackExtensions
{
    public interface ICrossAppDomainCallback<TResponse> : ICrossAppDomainCallback
    {
        TResponse Response { get; }
    }
}
