# 职责链模式(Chain of Responsibility)

## 定义

又称为责任链模式;

职责链模式: **避免将一个请求的发送者与接收者耦合在一起，让多个对象都有机会处理请求。将接收请求的对象连接成一条链，并且沿着这条链传递请求，直到有一个对象能够处理它为止。**
Chain of Responsibility Pattern: **Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. Chain the receiving objects and pass the request along the chain until an object handles it.**

## 结构

### Handler（抽象处理者）
定义了处理请求的接口, 一般设计为抽象类, 不同的处理者处理请求的方法不同, 因此其中定义了抽象请求处理方法.
```
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
```
### ConcreteHandler（具体处理者）
抽象处理者的子类, 可以处理用户请求
```
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
```

### 典型客户端代码
```
Handler handler1 = null, handler2 = null, handler3 = null;
handler3 = new ConcreteHandlerC();
handler2 = new ConcreteHandlerB(handler3);
handler1 = new ConcreteHandlerA(handler2);

handler1.HandlerRequest();
```

## 应用实例

> 某企业的SCM(Supply Chain Management，供应链管理)系统中包含一个采购审批子系统。该企业的采购审批是分级进行的，即根据采购金额的不同由不同层次的主管人员来审批，主任可以审批5万元以下（不包括5万元）的采购单，副董事长可以审批5万元至10万元（不包括10万元）的采购单，董事长可以审批10万元至50万元（不包括50万元）的采购单，50万元及以上的采购单就需要开董事会讨论决定。如图所示: 
![image](https://user-images.githubusercontent.com/38829279/64084642-0838b780-cd60-11e9-9d36-d57612076b1a.png)

### 实现
![image](https://user-images.githubusercontent.com/38829279/64108970-e4519200-cdb0-11e9-9016-15ce06f60e2a.png)

```
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

```

```
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
```