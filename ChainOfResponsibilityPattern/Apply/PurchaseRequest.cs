namespace ChainOfResponsibilityPattern.Apply
{
    class PurchaseRequest
    {
        public double Amount { get; set; }
        public string Purpose { get; set; }

        public PurchaseRequest(double amount, string purpose)
        {
            Amount = amount;
            Purpose = purpose;
        }

        public override string ToString()
        {
            return "Purchase total amount " + Amount + " for purpose: " + Purpose;
        }
    }

    class Client
    {
        public static void Run()
        {
            PurchaseRequest req = new PurchaseRequest(60000,"Purchase PC for employee. ");
            Approver approver = new Director("刘主任");
            Approver approver1 = new President("张董事");
            Approver approver2 = new VicePresident("王副董");
            Approver approver3 = new Congress("董事会");

            approver.SetSuccessor(approver2);
            approver1.SetSuccessor(approver3);
            approver2.SetSuccessor(approver1);

            approver.HandleRequest(req);
        }
    }
}
