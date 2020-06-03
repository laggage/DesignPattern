namespace StatePattern
{
    using StatePattern.Sample.Player;
    using System;
    using SampleClient = Sample.ShareState.SampleClient;

    class Program
    {
        static void Main(string[] args)
        {
            //SampleClient.Run();
            PlayerSampleClient.Run();
            Console.Read();
        }
    }
}
