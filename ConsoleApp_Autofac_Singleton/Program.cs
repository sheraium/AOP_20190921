using System;
using System.Threading.Tasks;
using Autofac;

namespace ConsoleApp_Autofac_Singleton
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TheNewOne>().SingleInstance();
            var container = builder.Build();
            for (int i = 0; i < 3; i++)
            {
                Task.Run(() =>
                {
                    var theOne = container.Resolve<TheNewOne>();
                    theOne.ShowUniqueKey();
                });
            }

            Console.ReadLine();
        }
    }
}