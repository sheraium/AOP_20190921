using Autofac;
using System;

namespace ConsoleApp_LifetimeScope
{
    internal class Program
    {
        private static IContainer container = null;

        private static void Main(string[] args)
        {
            AutofacConfig();

            Test();

            Console.ReadLine();
        }

        private static void Test()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var monster1 = scope.Resolve<ResourceMonster>();
                monster1.Name = "No1";
                monster1.Test();

                var monster2 = scope.Resolve<ResourceMonster>();
                monster2.Name = "No2";
                monster2.Test();
            }
        }

        private static void AutofacConfig()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ResourceMonster>();
            container = builder.Build();
        }
    }
}