using System;

namespace ConsoleApp_AOP
{
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
}