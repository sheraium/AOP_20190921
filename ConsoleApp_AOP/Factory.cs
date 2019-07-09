using System;

namespace ConsoleApp_AOP
{
    internal class Factory
    {
        internal static IOrder GetOrderInstance()
        {
            Console.WriteLine("請輸入true或false，決定是否啟用Log");
            var isLogEnabled = Boolean.Parse(Console.ReadLine());

            if (isLogEnabled)
            {
                return CastleConfig.Container.Resolve<IOrder>("logOrder");
            }
            else
            {
                return CastleConfig.Container.Resolve<IOrder>();
            }
        }

        internal static ICustomer GetCustomerInstance()
        {
            // 直接回傳Log裝飾過的Customer
            //return CastleConfig.Container.Resolve<ICustomer>();

            return CastleConfig.Container.Resolve<ICustomer>();
        }
    }
}