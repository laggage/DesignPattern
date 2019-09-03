namespace CommandPattern.BaseImplement
{
    abstract class Command
    {
        public abstract void Execute();
    }

    class ConcreteCommand : Command
    {
        private Receiver _receiver;

        public override void Execute()
        {
            _receiver.Action();
        }
    }

    class Invoker
    {
        public Command Command { get; set; }

        public void Invoke()
        {
            Command?.Execute();
        }
    }

    class Receiver
    {
        public void Action()
        {
        }
    }
}
