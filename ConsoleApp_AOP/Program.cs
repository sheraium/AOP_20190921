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
}