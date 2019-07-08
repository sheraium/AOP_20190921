using System;
using Castle.Core;

namespace ConsoleApp_AOP
{
    public interface IOrder
    {
        int Update(string id, string name);

        void Delete(string id);
    }

    [Interceptor(typeof(LogInterceptor))]
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