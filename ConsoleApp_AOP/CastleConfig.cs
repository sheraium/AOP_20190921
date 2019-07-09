using System;
using System.Linq;
using Castle.Core;
using Castle.DynamicProxy;
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

            // 額外註冊有加載攔截器的Order
            //Container.Register(
            //    Component.For<IOrder>()
            //        .ImplementedBy<Order>().LifestyleTransient().Named("logOrder")
            //        .Interceptors(InterceptorReference.ForType<LogInterceptor>()).Anywhere);

            Container.Register(
                Component.For<IOrder>()
                    .ImplementedBy<Order>().LifestyleTransient().Named("logOrder")
                    .Interceptors(InterceptorReference.ForType<LogInterceptor>()).Anywhere
                    .SelectInterceptorsWith(new OnlyUpdateMethodBeSelected()));

            Container.Register(
                Component.For<ICustomer>()
                    .ImplementedBy<Customer>().LifestyleTransient()
                    .Interceptors(InterceptorReference.ForType<LogInterceptor>()).Anywhere);
        }
    }

    internal class OnlyUpdateMethodBeSelected : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, System.Reflection.MethodInfo method, IInterceptor[] interceptors)
        {
            if (method.Name.Contains("Update"))
            {
                return interceptors;
            }
            else
            {
                return Enumerable.Empty<IInterceptor>().ToArray();
            }
        }
    }
}