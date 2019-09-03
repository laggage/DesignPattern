namespace CommandPattern
{
    using System.IO;
    using CommandPattern.Sample;
    using Microsoft.Extensions.Configuration;

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

        static void Main(string[] args)
        {
            SampleClient.Run();
        }
    }
}
