namespace ChainOfResponsibilityPattern.BaseImplement
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    abstract class Handler
    {
        protected Handler _successor;

        public Handler()
        {
            _successor = null;
        }

        public void SetSuccessor(Handler successor) => _successor = successor;

        public abstract void HandlerRequest();
    }

    class ConcreteHandlerA : Handler
    {
        public ConcreteHandlerA()
        {
        }

        public ConcreteHandlerA(Handler successor)
        {
            base.SetSuccessor(successor);
        }

        public override void HandlerRequest()
        {
            base._successor?.HandlerRequest();
        }
    }

    class ConcreteHandlerB : Handler
    {
        public ConcreteHandlerB()
        {
        }

        public ConcreteHandlerB(Handler successor)
        {
            base.SetSuccessor(successor);
        }

        public override void HandlerRequest()
        {
            base._successor?.HandlerRequest();
        }
    }

    class ConcreteHandlerC : Handler
    {
        public ConcreteHandlerC()
        {
        }

        public ConcreteHandlerC(Handler successor)
        {
            base.SetSuccessor(successor);
        }

        public override void HandlerRequest()
        {
            base._successor?.HandlerRequest();
        }
    }

    class Client
    {
        public static void Run()
        {
            Handler handler1 = null, handler2 = null, handler3 = null;
            handler3 = new ConcreteHandlerC();
            handler2 = new ConcreteHandlerB(handler3);
            handler1 = new ConcreteHandlerA(handler2);
            
            handler1.HandlerRequest();
        }
    }
}
