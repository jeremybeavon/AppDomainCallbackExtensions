# Overview
Provides extension methods for AppDomain.DoCallBack that allows data to be passed back and forth between AppDomains.

Calling methods on AppDomains can be problematic, especially if the base directories of the AppDomains are different.
It often means the same DLL is to 2 locations and this means the same DLL is loaded twice in the AppDomain.
This causes confusion and complexity. If you try and create an object than extends MarshalByRefObject using
AppDomain.CreateInstanceFromAndUnwrap, you get a exception that something like "[object] cannot be cast to [object]".
If you use the AppDomain.DoCallback method, you do not have this problem, but you cannot pass data between the AppDomains.
AppDomainCallbackExtensions solves this problem by allowing static methods to be called in a different AppDomain using the following steps:

1. Serialize the static method name and parameters and store these using AppDomain.GetData
2. Call AppDomain.DoCallback, which moves the execution to a new AppDomain
3. Deserialize the static method name and parameters using AppDomain.SetData
4. Call the static method
5. Serialize the return value and store this using AppDomain.SetData
6. End the callback and return to the original AppDomain
7. Deserialize the return value using AppDomain.GetData

# Examples

```csharp
using System;
using AppDomainCallbackExtensions

// This program should write the following to the console:
//
// Domain: newDomain, Message: Callback
//
public static class Program
{
  public static void Main(string[] args)
  {
    AppDomain appDomain = AppDomain.CreateDomain("newDomain");
    appDomain.DoCallback(LogInformation, "Callback");
  }
  
  private static void LogInformation(string text)
  {
    Console.WriteLine("Domain: {0}, Message: {1}", AppDomain.CurrentDomain.FriendlyName, text);
  }
}
```
