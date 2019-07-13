using System;

namespace ConsoleApp_LifetimeScope
{
    class ResourceMonster : IDisposable
    {
        public string Name = "Anonymous";
        public void Test()
        {
            Console.WriteLine("{0}: Hi there.", Name);
        }
        public void Dispose()
        {
            Console.WriteLine("{0}: Disposed.", Name);
        }
    }
}