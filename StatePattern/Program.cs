namespace StatePattern
{
    using System;
    using StatePattern.Sample;
    using StatePattern.Sample.ShareState;
    using SampleClient = Sample.ShareState.SampleClient;

    class Program
    {
        static void Main(string[] args)
        {
            //SampleClient.Run();
            SampleClient.Run();
            Console.Read();
        }
    }
}
