using System.IO;
using CommandPattern.Sample;
using DesignParttern.Shared;
using Microsoft.Extensions.Configuration;

namespace CommandPattern
{
    class Program
    {
        private static readonly IConfigurationBuilder _configurationBuilder;

        public static IConfigurationRoot Configuration { get; }

        static Program()
        {
            _configurationBuilder = new ConfigurationBuilder();
            Configuration = _configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json",true,true)
                .Build();
        }

        static void Main()
        {
            var manager = new SampleClientManager();
            manager.Run();
        }
    }
}
