using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace ConsoleApp_AOP
{
    internal static class CastleConfig
    {
        public static IWindsorContainer Container;

        internal static void Initialized()
        {
            Container = new WindsorContainer();

            // 透過 key 來決定取回的 IOrder 物件為何
            Container.Register(
                Component.For<IOrder>()
                    .ImplementedBy<Order>().LifestyleTransient());

            Container.Register(
                Component.For<IOrder>()
                    .Instance(new LogOrder(Container.Resolve<IOrder>())).Named("logOrder").LifestyleTransient());

            // 可以透過註冊的順序，直接決定 LogCustomer Decorator 的生成方式
            Container.Register(
                Component.For<ICustomer>()
                    .ImplementedBy<LogCustomer>().LifestyleTransient());

            Container.Register(
                Component.For<ICustomer>()
                    .ImplementedBy<Customer>().LifestyleTransient());
        }
    }
}