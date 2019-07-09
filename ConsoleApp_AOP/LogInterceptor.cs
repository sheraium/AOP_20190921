using System;
using Castle.DynamicProxy;

namespace ConsoleApp_AOP
{
    public class LogInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var typeName = invocation.TargetType.FullName;
            var methodName = invocation.Method.Name;

            Console.WriteLine($"== {typeName}.{methodName} log is starting ==");

            foreach (var arg in invocation.Arguments)
            {
                Console.WriteLine($"argument:{arg}");
            }

            invocation.Proceed();

            Console.WriteLine($"return value:{invocation.ReturnValue ?? "null"}");
            Console.WriteLine($"== {typeName}.{methodName} log is stopping ==");
            Console.WriteLine();
        }
    }
}