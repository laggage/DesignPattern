namespace MeidatorPattern.Sample
{
    abstract class Component
    {
        protected Mediator mediator;

        public void SetMediator(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public void Changed()
        {
            mediator.ComponentChanged(this);
        }

        public abstract void Update();
    }
}
