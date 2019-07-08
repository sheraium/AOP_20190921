using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;

namespace ConsoleApp_AOP
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 加上 IoC container 註冊與初始化
            CastleConfig.Initialized();

            IOrder order = Factory.GetOrderInstance();

            order.Update("91", "Joey");
            order.Delete("92");

            IOrder order2 = Factory.GetOrderInstance();

            order2.Update("91", "Joey");
            order2.Delete("92");
        }
    }

    internal static class CastleConfig
    {
        public static IWindsorContainer Container;

        internal static void Initialized()
        {
            Container = new WindsorContainer();

            Container.Register(
                Component.For<IOrder>()
                    .ImplementedBy<Order>().LifestyleTransient());

            Container.Register(
                Component.For<IOrder>()
                    .Instance(new LogOrder(Container.Resolve<IOrder>())).Named("logOrder").LifestyleTransient());
        }
    }

    internal class Factory
    {
        public static IOrder GetOrderInstance()
        {
            Console.WriteLine("請輸入true或false，決定是否啟用Log");
            var isLogEnabled = Boolean.Parse(Console.ReadLine());

            if (isLogEnabled)
            {
                return new LogOrder(new Order());
            }
            else
            {
                return new Order();
            }
        }
    }

    public interface IOrder
    {
        int Update(string id, string name);

        void Delete(string id);
    }

    public class Order : IOrder
    {
        public int Update(string id, string name)
        {
            Console.WriteLine($"Update order, id={id}, name={name}");
            return 1;
        }

        public void Delete(string id)
        {
            Console.WriteLine($"Delete order, id={id}");
        }
    }

    public class LogOrder : IOrder
    {
        private IOrder _order;

        public LogOrder(IOrder order)
        {
            this._order = order;
        }

        public int Update(string id, string name)
        {
            Console.WriteLine("== update log is starting ==");
            var result = this._order.Update(id, name);
            Console.WriteLine("== update log is stopping ==");
            Console.WriteLine();

            return result;
        }

        public void Delete(string id)
        {
            Console.WriteLine("== delete log is starting ==");
            this._order.Delete(id);
            Console.WriteLine("== delete log is stopping ==");
            Console.WriteLine();
        }
    }
}