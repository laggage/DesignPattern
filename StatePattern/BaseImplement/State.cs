namespace StatePattern.BaseImplement
{
    abstract class State
    {
        public abstract void Handle();
    }

    class ConcreteState : State
    {
        public override void Handle()
        {
            // 
        }
    }
}
