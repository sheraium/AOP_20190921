using System;

namespace ConsoleApp_Autofac_PropertyInjection
{
    public class Worker
    {
        public ILogger Logger { get; set; }
        public void DoSomething(string command)
        {
            Console.WriteLine("JOB:" + command);
            Logger.Log(command);
        }
    }
}