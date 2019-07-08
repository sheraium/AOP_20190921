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

            // 註冊攔截器的型別與物件供 Interceptor attribute 使用
            Container.Register(
                Component.For<LogInterceptor>()
                    .ImplementedBy<LogInterceptor>().LifestyleTransient());

            Container.Register(
                Component.For<IOrder>()
                    .ImplementedBy<Order>().LifestyleTransient());

            Container.Register(
                Component.For<ICustomer>()
                    .ImplementedBy<Customer>().LifestyleTransient());
        }
    }
}