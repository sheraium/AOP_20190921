using System;
using System.Threading;

namespace ConsoleApp_LifetimeScope
{
    public class TheNewOne
    {
        private Guid UniqueKey = Guid.NewGuid();
        public TheNewOne()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Constructor Executed");
        }
        public void ShowUniqueKey()
        {
            Console.WriteLine("Unique Key={0}", UniqueKey);
        }
    }
}