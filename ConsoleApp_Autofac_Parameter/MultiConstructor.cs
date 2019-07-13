using System;

namespace ConsoleApp_Autofac_Parameter
{
    public class ArgW { }
    public class ArgX { }
    public class ArgY { }
    public class ArgZ { }

    public class MultiConstructor
    {
        public MultiConstructor(ArgW w)
        {
            Console.WriteLine("Constructor ArgW");
        }
        public MultiConstructor(int i, int j, ArgY y)
        {
            Console.WriteLine("Constructor int, int, ArgY");
        }
        public MultiConstructor(ArgY y, ArgZ z)
        {
            Console.WriteLine("Constructor ArgY, ArgZ");
        }
        public MultiConstructor(ArgX x)
        {
            Console.WriteLine("Constructor ArgX");
        }
        public MultiConstructor(ArgW w, ArgX x)
        {
            Console.WriteLine("Constructor ArgW, ArgX");
        }
        public MultiConstructor(ArgX x, ArgZ z)
        {
            Console.WriteLine("Constructor ArgX, ArgZ");
        }
    }
}