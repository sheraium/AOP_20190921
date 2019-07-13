using Autofac;
using System;

namespace ConsoleApp_Autofac_PropertyInjection
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Test1();

            Test2();

            Test3();

            Console.ReadLine();
        }

        private static void Test3()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Logger>().As<ILogger>();

            //透過PropertyAutowired()交由Autofac自動解析
            builder.RegisterType<Worker>().PropertiesAutowired();
            var container = builder.Build();

            var worker = container.Resolve<Worker>();
            worker.DoSomething("Wash the dog");
        }

        private static void Test2()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Logger>().As<ILogger>();

            //利用OnActivated事件，物件建立後指定Property
            //OnActivated事件會傳入IActivatedEventArgs，
            //其中的Instance為剛建好的物件、Context為IContainer或ILifetimeScope容器
            builder.RegisterType<Worker>().OnActivated(e => e.Instance.Logger = e.Context.Resolve<ILogger>());

            var container = builder.Build();

            var worker = container.Resolve<Worker>();
            worker.DoSomething("Wash the dog");
        }

        private static void Test1()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Logger>().As<ILogger>();

            //方法自訂建構程序，傳回物件。建立物件時一併指定Property
            builder.Register(c =>
                new Worker()
                {
                    Logger = c.Resolve<ILogger>()
                });
            var container = builder.Build();

            var worker = container.Resolve<Worker>();
            worker.DoSomething("Wash the dog");
        }
    }
}