using System;
using TextSerialization;

namespace AppDomainCallbackExtensions
{
    public static class AppDomainCallbackExtensions
    {
        private static readonly CrossDomainId CrossDomainActionId = new CrossDomainId("CrossDomainAction");

#if NET20
        public static TOutput DoCallBack<TOutput, TSerializer>(
            AppDomain domain,
            Func<TOutput> staticCallback,
            TSerializer serializer)
#else
        public static TOutput DoCallBack<TOutput, TSerializer>(
            this AppDomain domain,
            Func<TOutput> staticCallback,
            TSerializer serializer)
#endif
            where TSerializer : ITextSerialization, new()
        {
            ValidateCallback(staticCallback);
            return DoCallBackWithResponse<CrossAppDomainFuncCallback<TOutput>, TSerializer, TOutput>(
                domain,
                new CrossAppDomainFuncCallback<TOutput>(staticCallback.Method),
                serializer);
        }

#if NET20
        public static TOutput DoCallBack<TInput, TOutput, TSerializer>(
            AppDomain domain,
            TInput input,
            Func<TInput, TOutput> staticCallback,
            TSerializer serializer)
#else
        public static TOutput DoCallBack<TInput, TOutput, TSerializer>(
            this AppDomain domain,
            TInput input,
            Func<TInput, TOutput> staticCallback,
            TSerializer serializer)
#endif
        where TSerializer : ITextSerialization, new()
        {
            ValidateCallback(staticCallback);
            return DoCallBackWithResponse<CrossAppDomainFuncCallback<TInput, TOutput>, TSerializer, TOutput>(
                domain,
                new CrossAppDomainFuncCallback<TInput, TOutput>(staticCallback.Method, input),
                serializer);
        }

#if NET20
        public static TOutput DoCallBack<TInput1, TInput2, TOutput, TSerializer>(
            AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            Func<TInput1, TInput2, TOutput> staticCallback,
            TSerializer serializer)
#else
        public static TOutput DoCallBack<TInput1, TInput2, TOutput, TSerializer>(
            this AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            Func<TInput1, TInput2, TOutput> staticCallback,
            TSerializer serializer)
#endif
            where TSerializer : ITextSerialization, new()
        {
            ValidateCallback(staticCallback);
            return DoCallBackWithResponse<CrossAppDomainFuncCallback<TInput1, TInput2, TOutput>, TSerializer, TOutput>(
                domain,
                new CrossAppDomainFuncCallback<TInput1, TInput2, TOutput>(staticCallback.Method, input1, input2),
                serializer);
        }

#if NET20
        public static TOutput DoCallBack<TInput1, TInput2, TInput3, TOutput, TSerializer>(
            AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            TInput3 input3,
            Func<TInput1, TInput2, TInput3, TOutput> staticCallback,
            TSerializer serializer)
#else
        public static TOutput DoCallBack<TInput1, TInput2, TInput3, TOutput, TSerializer>(
            this AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            TInput3 input3,
            Func<TInput1, TInput2, TInput3, TOutput> staticCallback,
            TSerializer serializer)
#endif
            where TSerializer : ITextSerialization, new()
        {
            ValidateCallback(staticCallback);
            return DoCallBackWithResponse<CrossAppDomainFuncCallback<TInput1, TInput2, TInput3, TOutput>, TSerializer, TOutput>(
                domain,
                new CrossAppDomainFuncCallback<TInput1, TInput2, TInput3, TOutput>(staticCallback.Method, input1, input2, input3),
                serializer);
        }

#if NET20
        public static TOutput DoCallBack<TInput1, TInput2, TInput3, TInput4, TOutput, TSerializer>(
            AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            TInput3 input3,
            TInput4 input4,
            Func<TInput1, TInput2, TInput3, TInput4, TOutput> staticCallback,
            TSerializer serializer)
#else
        public static TOutput DoCallBack<TInput1, TInput2, TInput3, TInput4, TOutput, TSerializer>(
            AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            TInput3 input3,
            TInput4 input4,
            Func<TInput1, TInput2, TInput3, TInput4, TOutput> staticCallback,
            TSerializer serializer)
#endif
            where TSerializer : ITextSerialization, new()
        {
            ValidateCallback(staticCallback);
            return DoCallBackWithResponse<CrossAppDomainFuncCallback<TInput1, TInput2, TInput3, TInput4, TOutput>, TSerializer, TOutput>(
                domain,
                new CrossAppDomainFuncCallback<TInput1, TInput2, TInput3, TInput4, TOutput>(staticCallback.Method, input1, input2, input3, input4),
                serializer);
        }

#if NET20
        public static TOutput DoCallBack<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput, TSerializer>(
            AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            TInput3 input3,
            TInput4 input4,
            TInput5 input5,
            Func<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput> staticCallback,
            TSerializer serializer)
#else
        public static TOutput DoCallBack<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput, TSerializer>(
            this AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            TInput3 input3,
            TInput4 input4,
            TInput5 input5,
            Func<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput> staticCallback,
            TSerializer serializer)
#endif
            where TSerializer : ITextSerialization, new()
        {
            ValidateCallback(staticCallback);
            return DoCallBackWithResponse<CrossAppDomainFuncCallback<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput>, TSerializer, TOutput>(
                domain,
                new CrossAppDomainFuncCallback<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput>(staticCallback.Method, input1, input2, input3, input4, input5),
                serializer);
        }

#if NET20
        public static TOutput DoCallBack<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput, TSerializer>(
            AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            TInput3 input3,
            TInput4 input4,
            TInput5 input5,
            TInput6 input6,
            Func<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput> staticCallback,
            TSerializer serializer)
#else
        public static TOutput DoCallBack<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput, TSerializer>(
            this AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            TInput3 input3,
            TInput4 input4,
            TInput5 input5,
            TInput6 input6,
            Func<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput> staticCallback,
            TSerializer serializer)
#endif
            where TSerializer : ITextSerialization, new()
        {
            ValidateCallback(staticCallback);
            return DoCallBackWithResponse<CrossAppDomainFuncCallback<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput>, TSerializer, TOutput>(
                domain,
                new CrossAppDomainFuncCallback<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput>(staticCallback.Method, input1, input2, input3, input4, input5, input6),
                serializer);
        }

#if NET20
        public static void DoCallBack<TInput, TSerializer>(
            AppDomain domain,
            TInput input,
            Action<TInput> staticCallback,
            TSerializer serializer)
#else
        public static void DoCallBack<TInput, TSerializer>(
            this AppDomain domain,
            TInput input,
            Action<TInput> staticCallback,
            TSerializer serializer)
#endif
            where TSerializer : ITextSerialization, new()
        {
            ValidateCallback(staticCallback);
            DoCallBack(
                domain,
                new CrossAppDomainActionCallback<TInput>(staticCallback.Method, input),
                serializer);
        }

#if NET20
        public static void DoCallBack<TInput1, TInput2, TSerializer>(
            AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            Action<TInput1, TInput2> staticCallback,
            TSerializer serializer)
#else
        public static void DoCallBack<TInput1, TInput2, TSerializer>(
            this AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            Action<TInput1, TInput2> staticCallback,
            TSerializer serializer)
#endif
            where TSerializer : ITextSerialization, new()
        {
            ValidateCallback(staticCallback);
            DoCallBack(
                domain,
                new CrossAppDomainActionCallback<TInput1, TInput2>(staticCallback.Method, input1, input2),
                serializer);
        }

#if NET20
        public static void DoCallBack<TInput1, TInput2, TInput3, TSerializer>(
            AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            TInput3 input3,
            Action<TInput1, TInput2, TInput3> staticCallback,
            TSerializer serializer)
#else
        public static void DoCallBack<TInput1, TInput2, TInput3, TSerializer>(
            AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            TInput3 input3,
            Action<TInput1, TInput2, TInput3> staticCallback,
            TSerializer serializer)
#endif
            where TSerializer : ITextSerialization, new()
        {
            ValidateCallback(staticCallback);
            DoCallBack(
                domain,
                new CrossAppDomainActionCallback<TInput1, TInput2, TInput3>(staticCallback.Method, input1, input2, input3),
                serializer);
        }

#if NET20
        public static void DoCallBack<TInput1, TInput2, TInput3, TInput4, TSerializer>(
            AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            TInput3 input3,
            TInput4 input4,
            Action<TInput1, TInput2, TInput3, TInput4> staticCallback,
            TSerializer serializer)
#else
        public static void DoCallBack<TInput1, TInput2, TInput3, TInput4, TSerializer>(
            this AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            TInput3 input3,
            TInput4 input4,
            Action<TInput1, TInput2, TInput3, TInput4> staticCallback,
            TSerializer serializer)
#endif
            where TSerializer : ITextSerialization, new()
        {
            ValidateCallback(staticCallback);
            DoCallBack(
                domain,
                new CrossAppDomainActionCallback<TInput1, TInput2, TInput3, TInput4>(staticCallback.Method, input1, input2, input3, input4),
                serializer);
        }

#if NET20
        public static void DoCallBack<TInput1, TInput2, TInput3, TInput4, TInput5, TSerializer>(
            AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            TInput3 input3,
            TInput4 input4,
            TInput5 input5,
            Action<TInput1, TInput2, TInput3, TInput4, TInput5> staticCallback,
            TSerializer serializer)
#else
        public static void DoCallBack<TInput1, TInput2, TInput3, TInput4, TInput5, TSerializer>(
            this AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            TInput3 input3,
            TInput4 input4,
            TInput5 input5,
            Action<TInput1, TInput2, TInput3, TInput4, TInput5> staticCallback,
            TSerializer serializer)
#endif
            where TSerializer : ITextSerialization, new()
        {
            ValidateCallback(staticCallback);
            DoCallBack(
                domain,
                new CrossAppDomainActionCallback<TInput1, TInput2, TInput3, TInput4, TInput5>(staticCallback.Method, input1, input2, input3, input4, input5),
                serializer);
        }

#if NET20
        public static void DoCallBack<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TSerializer>(
            AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            TInput3 input3,
            TInput4 input4,
            TInput5 input5,
            TInput6 input6,
            Action<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6> staticCallback,
            TSerializer serializer)
#else
        public static void DoCallBack<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TSerializer>(
            AppDomain domain,
            TInput1 input1,
            TInput2 input2,
            TInput3 input3,
            TInput4 input4,
            TInput5 input5,
            TInput6 input6,
            Action<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6> staticCallback,
            TSerializer serializer)
#endif
            where TSerializer : ITextSerialization, new()
        {
            ValidateCallback(staticCallback);
            DoCallBack(
                domain,
                new CrossAppDomainActionCallback<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6>(staticCallback.Method, input1, input2, input3, input4, input5, input6),
                serializer);
        }

#if NET20
        public static void DoCallBack<TCallback, TSerializer>(
            AppDomain domain,
            TCallback callback,
            TSerializer serializer)
#else
        public static void DoCallBack<TCallback, TSerializer>(
            AppDomain domain,
            TCallback callback,
            TSerializer serializer)
#endif
            where TCallback : ICrossAppDomainCallback
            where TSerializer : ITextSerialization, new()
        {
            domain.SetData(CrossDomainActionId.Id, serializer.ToText(callback));
            domain.DoCallBack(DoCallBack<TCallback, TSerializer>);
        }

#if NET20
        public static TResponse DoCallBackWithResponse<TCallback, TSerializer, TResponse>(
            AppDomain domain,
            TCallback callback,
            TSerializer serializer)
#else
        public static TResponse DoCallBackWithResponse<TCallback, TSerializer, TResponse>(
            AppDomain domain,
            TCallback callback,
            TSerializer serializer)
#endif
            where TCallback : ICrossAppDomainCallback<TResponse>
            where TSerializer : ITextSerialization, new()
        {
            domain.SetData(CrossDomainActionId.Id, serializer.ToText(callback));
            domain.DoCallBack(DoCallBackWithResponse<TCallback, TSerializer, TResponse>);
            string responseText = (string)domain.GetData(CrossDomainActionId.Id);
            return serializer.FromText<TCallback>(responseText).Response;
        }

        private static void DoCallBack<TCallback, TSerializer>()
            where TCallback : ICrossAppDomainCallback
            where TSerializer : ITextSerialization, new()
        {
            CreateCallback<TCallback>(new TSerializer()).Callback();
        }

        private static void DoCallBackWithResponse<TCallback, TSerializer, TResponse>()
            where TCallback : ICrossAppDomainCallback<TResponse>
            where TSerializer : ITextSerialization, new()
        {
            TSerializer serializer = new TSerializer();
            ICrossAppDomainCallback<TResponse> callback = CreateCallback<TCallback>(serializer);
            callback.Callback();
            AppDomain.CurrentDomain.SetData(CrossDomainActionId.Id, serializer.ToText(callback));
        }

        private static TCallback CreateCallback<TCallback>(ITextSerialization serializer)
            where TCallback : ICrossAppDomainCallback
        {
            return serializer.FromText<TCallback>((string)AppDomain.CurrentDomain.GetData(CrossDomainActionId.Id));
        }

        private static void ValidateCallback(Delegate staticCallback)
        {
            if (staticCallback == null)
            {
                throw new ArgumentNullException("staticCallback");
            }

            if (!staticCallback.Method.IsStatic)
            {
                throw new ArgumentException("staticCallback must be a static method", "staticCallback");
            }
        }
    }
}
