using DesignParttern.Shared;
using System;

namespace MementoPattern
{
    class Program
    {
        static void Main()
        {
            var manager = new SampleClientManager();
            manager.Run();

            Console.Read();
        }
    }
}
