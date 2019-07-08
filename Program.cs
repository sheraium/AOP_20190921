using System;

namespace ConsoleApp_AOP
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Order order = new Order();            
            IOrder order = new LogOrder(new Order());
            order.Update("91", "Joey");
            order.Delete("92");
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