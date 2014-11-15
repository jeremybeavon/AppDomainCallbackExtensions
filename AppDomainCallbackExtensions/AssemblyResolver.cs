using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace AppDomainCallbackExtensions
{
    internal sealed class AssemblyResolver : MarshalByRefObject
    {
        private static readonly IList<string> ResolveDirectories = new List<string>();
        private static readonly object ResolveDirectoriesLock = new object();

        public void AddResolveDirectory(string directory)
        {
            lock (ResolveDirectoriesLock)
            {
                if (ResolveDirectories.Count == 0)
                {
                    AppDomain.CurrentDomain.AssemblyResolve += ResolveAssembly;
                }

                if (!ResolveDirectories.Contains(directory))
                {
                    ResolveDirectories.Add(directory);
                }
            }
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

        private Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        {
            string assemblyName = new AssemblyName(args.Name).Name + ".dll";
            lock (ResolveDirectoriesLock)
            {
                foreach (string directory in ResolveDirectories)
                {
                    string assemblyFile = Path.Combine(directory, assemblyName);
                    if (File.Exists(assemblyFile))
                    {
                        return Assembly.LoadFrom(assemblyFile);
                    }
                }
            }

            return null;
        }
    }
}
