using System.Threading;

namespace AppDomainCallbackExtensions
{
    internal sealed class CrossDomainId
    {
        private readonly string id;

        public CrossDomainId(string id)
        {
            this.id = id;
        }

        public string Id
        {
            get { return string.Concat(id, Thread.CurrentThread.ManagedThreadId); }
        }
    }
}
