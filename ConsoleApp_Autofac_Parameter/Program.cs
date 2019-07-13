using System;
using Autofac;

namespace ConsoleApp_Autofac_Parameter
{
    class Program
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<MultiConstructor>();
            builder.RegisterType<ArgW>();
            IContainer container = builder.Build();
            var obj1 = container.Resolve<MultiConstructor>(
                new PositionalParameter(0, 1),
                new PositionalParameter(1, 2),
                new PositionalParameter(2, new ArgY())
            );
            var obj2 = container.Resolve<MultiConstructor>(
                new TypedParameter(typeof(ArgY), new ArgY()),
                new TypedParameter(typeof(ArgZ), new ArgZ())
            );
            var obj3 = container.Resolve<MultiConstructor>();
            var obj4 = container.Resolve<MultiConstructor>(
                new NamedParameter("x", new ArgX())
            );
            try
            {
                var obj5 = container.Resolve<MultiConstructor>(
                    new NamedParameter("x", new ArgX()),
                    new NamedParameter("z", new ArgX()));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
            var obj6 = container.Resolve<MultiConstructor>(
                new NamedParameter("i", 1),
                new NamedParameter("y", new ArgX()));
            Console.ReadLine();

        }
    }


  
}
