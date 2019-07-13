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

            Test2();

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

        static void Test2()
        {
            var scope1 = container.BeginLifetimeScope();
            var scope2 = container.BeginLifetimeScope();
            var one1 = scope1.Resolve<TheNewOne>();
            Console.WriteLine("1->");
            one1.ShowUniqueKey();
            var one2A = scope2.Resolve<TheNewOne>();
            var one2B = scope2.Resolve<TheNewOne>();
            Console.WriteLine("2A->");
            one2A.ShowUniqueKey();
            Console.WriteLine("2B->");
            one2B.ShowUniqueKey();
        }


        private static void AutofacConfig()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ResourceMonster>();
            builder.RegisterType<TheNewOne>().InstancePerLifetimeScope();
            container = builder.Build();
        }
    }
}