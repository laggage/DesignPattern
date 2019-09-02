namespace ChainOfResponsibilityPattern.Apply
{
    using System;

    abstract class Approver
    {
        protected Approver _successor;

        public string Name { get; set; }

        public Approver()
        {
        }

        public Approver(string name)
        {
            Name = name;
        }

        public void SetSuccessor(Approver successor) => _successor = successor;

        public abstract void HandleRequest(PurchaseRequest request);
    }

    class President : Approver
    {
        private const double MaxHandleAmount = 500000;

        public President(string name)
        {
            base.Name = name;
        }

        public override void HandleRequest(PurchaseRequest request)
        {
            if (request.Amount > MaxHandleAmount)
                base._successor.HandleRequest(request);
            else
            {
                Console.WriteLine(
                    "{0} approved purchase: {1}", this.ToString(), request.ToString());
            }
        }

        public override string ToString()
        {
            return "主任 - " + Name;
        }
    }

    class VicePresident : Approver
    {
        private const double MaxHandleAmount = 100000;

        public VicePresident(string name)
        {
            base.Name = name;
        }

        public override void HandleRequest(PurchaseRequest request)
        {
            if (request.Amount > MaxHandleAmount)
                base._successor.HandleRequest(request);
            else
            {
                Console.WriteLine(
                    "{0} approved purchase: {1}", this.ToString(), request.ToString());
            }
        }

        public override string ToString()
        {
            return "主任 - " + Name;
        }
    }

    class Congress : Approver
    {
        public Congress(string name)
        {
            base.Name = name;
        }

        public override void HandleRequest(PurchaseRequest request)
        {
            Console.WriteLine(
                "{0} approved purchase: {1}", this.ToString(), request.ToString());
        }

        public override string ToString()
        {
            return "主任 - " + Name;
        }
    }

    class Director:Approver
    {
        private const double MaxHandleAmount = 50000;

        public Director(string name)
        {
            base.Name = name;
        }

        public override void HandleRequest(PurchaseRequest request)
        {
            if (request.Amount > MaxHandleAmount)
                base._successor.HandleRequest(request);
            else
            {
                Console.WriteLine(
                    "{0} approved purchase: {1}", this.ToString(), request.ToString());
            }
        }

        public override string ToString()
        {
            return "主任 - " + Name;
        }
    }
}
