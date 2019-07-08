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

            ICustomer customer = Factory.GetCustomerInstance();
            customer.Contact();
        }
    }

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

    internal class Factory
    {
        internal static IOrder GetOrderInstance()
        {
            Console.WriteLine("請輸入true或false，決定是否啟用Log");
            var isLogEnabled = Boolean.Parse(Console.ReadLine());

            if (isLogEnabled)
            {
                //return new LogOrder(new Order());
                return CastleConfig.Container.Resolve<IOrder>("logOrder");
            }
            else
            {
                //return new Order();
                return CastleConfig.Container.Resolve<IOrder>();
            }
        }

        internal static ICustomer GetCustomerInstance()
        {
            // 直接回傳Log裝飾過的Customer
            return CastleConfig.Container.Resolve<ICustomer>();
        }
    }

    public class LogCustomer : ICustomer
    {
        private ICustomer _customer;

        public LogCustomer(ICustomer customer)
        {
            this._customer = customer;
        }

        public void Contact()
        {
            Console.WriteLine("== Contact log is starting ==");
            this._customer.Contact();
            Console.WriteLine("== Contact log is stopping ==");
            Console.WriteLine();
        }
    }

    public interface ICustomer
    {
        void Contact();
    }

    public class Customer : ICustomer
    {
        public void Contact()
        {
            Console.WriteLine("contact customer...");
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