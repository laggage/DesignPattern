namespace StatePattern.Sample
{
    public class SampleClient
    {
        public static void Run()
        {
            Account acc = new Account("李逍遥");
            acc.Deposit(1000);
            acc.WithDraw(2000);
            acc.WithDraw(1000);
            acc.WithDraw(500);
        }
    }
}
