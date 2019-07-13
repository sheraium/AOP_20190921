using System;
using Autofac;

namespace ConsoleApp_Autofac_NamedService
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SoundSensor>().Keyed<ISensor>(SensorType.Sound);
            builder.Register(c => new TemperatureeSensor()).Keyed<ISensor>(SensorType.Temperature);
            var container = builder.Build();

            var ss = container.ResolveKeyed<ISensor>(SensorType.Sound);
            Console.WriteLine(ss.Detect());

            var ts = container.ResolveKeyed<ISensor>(SensorType.Temperature);
            Console.WriteLine(ts.Detect());

            Console.ReadLine();
        }
    }

    public interface ISensor
    {
        string Detect();
    }
    public class TemperatureeSensor : ISensor
    {
        public string Detect()
        {
            return "It's hot";
        }
    }
    public class SoundSensor : ISensor
    {
        public string Detect()
        {
            return "It's noisy";
        }
    }

    public enum SensorType
    {
        Temperature,
        Sound
    }

}
