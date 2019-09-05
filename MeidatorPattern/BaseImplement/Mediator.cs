namespace MeidatorPattern.BaseImplement
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    abstract class Mediator
    {
        protected List<Colleague> colleagues;

        public Mediator()
        {
            colleagues = new List<Colleague>();
        }

        public void Register(Colleague colleague)
        {
            colleagues.Add(colleague);
        }

        public abstract void Operation();
    }

    class ConcreteMediator:Mediator
    {
        public override void Operation()
        {
            throw new NotImplementedException();
        }
    }

    class Colleague
    {
        private readonly Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public void Method2()
        {
            mediator.Operation();
        }
    }

    class ConcreteColleagueA : Colleague
    {
        public ConcreteColleagueA(Mediator mediator):base(mediator)
        {
        }
    }

    class ConcreteColleagueB : Colleague
    {
        public ConcreteColleagueB(Mediator mediator) : base(mediator)
        {
        }
    }
}
