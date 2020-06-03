using DecoratorPattern.Sample.TimeLogger;
using DesignParttern.Shared;
using System;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ISampleClient client = new TimeLoggerSampleClient();
            client.Run();

            Console.ReadKey();
        }
    }
}
