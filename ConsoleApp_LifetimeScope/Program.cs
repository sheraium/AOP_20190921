using System;
using Autofac;

namespace ConsoleApp_LifetimeScope
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ResourceMonster>();
            var container = builder.Build();

            var monster = container.Resolve<ResourceMonster>();
            monster.Test();
            Console.WriteLine("Before IContainer Dispose");
            container.Dispose();
            Console.WriteLine("After IContainer Dispose");

            Console.ReadLine();
        }
    }
}
