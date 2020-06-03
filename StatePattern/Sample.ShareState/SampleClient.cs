namespace StatePattern.Sample.ShareState
{
    class SampleClient
    {
        public static void Run()
        {
            Switch s1 = new Switch();
            Switch s2 = new Switch();
            s1.On();
            s2.On();

            s2.Off();
            s2.Off();
        }

    }
}
