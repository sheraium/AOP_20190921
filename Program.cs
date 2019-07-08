using System;

namespace ConsoleApp_AOP
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order();
            order.Update("91", "Joey");
            order.Delete("92");
        }
    }

    internal class Order
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
}
