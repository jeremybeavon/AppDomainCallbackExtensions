using System;
using System.Threading;
using TextSerialization;

namespace AppDomainCallbackExtensions
{
    public static class AppDomainCallbackExtensions
    {
        private const string crossDomainActionId = "CrossDomainAction";

        private static string CrossDomainActionId
        {
            get { return string.Concat(crossDomainActionId, Thread.CurrentThread.ManagedThreadId); }
        }

        public static void DoCallBack<TCallback, TSerializer>(
#if NET20
            AppDomain domain,
#else
            this AppDomain domain,
#endif
            TCallback callback,
            TSerializer serializer)
            where TCallback : ICrossAppDomainCallback
            where TSerializer : ITextSerialization, new()
        {
            domain.SetData(CrossDomainActionId, serializer.ToText(callback));
            domain.DoCallBack(DoCallBack<TCallback, TSerializer>);
        }

        public static TResponse DoCallBack<TCallback, TSerializer, TResponse>(
#if NET20
            AppDomain domain,
#else
            this AppDomain domain,
#endif
            TCallback callback,
            TSerializer serializer)
            where TCallback : ICrossAppDomainCallback<TResponse>
            where TSerializer : ITextSerialization, new()
        {
            DoCallBack(domain, callback, serializer);
            string responseText = (string)domain.GetData(CrossDomainActionId);
            return serializer.FromText<ICrossAppDomainCallback<TResponse>>(responseText).Response;
        }

        private static void DoCallBack<TCallback, TSerializer>()
            where TCallback : ICrossAppDomainCallback
            where TSerializer : ITextSerialization, new()
        {
            new TSerializer().FromText<TCallback>((string)AppDomain.CurrentDomain.GetData(CrossDomainActionId)).Callback();
        }
    }
}
