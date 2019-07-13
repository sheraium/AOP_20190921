using System;

namespace ConsoleApp_Autofac_PropertyInjection
{
    public interface ILogger
    {
        void Log(string msg);
    }
    public class Logger : ILogger
    {
        public void Log(string msg)
        {
            Console.WriteLine("LOG:" + msg);
        }
    }
}