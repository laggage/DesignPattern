namespace BridgePattern.Implement
{
    using System;

    interface IImplementor
    {
        void OperationImpl();
    }

    class ConcreteImplementorA:IImplementor
    {
        public void OperationImpl()
        {
            Console.WriteLine("ConcreteImplementorA implement operation. ");
            //throw new NotImplementedException();
        }
    }

    class ConcreteImplementorB : IImplementor
    {
        public void OperationImpl()
        {
            Console.WriteLine("ConcreteImplementorB implement operation. ");
        }
    }

    abstract class Abstraction
    {
        protected IImplementor _impl;

        public void SetImpl(IImplementor impl)
        {
            _impl = impl;
        }

        public abstract void Operation();
    }

    class RefinedAbstration : Abstraction
    {
        public override void Operation()
        {
            _impl.OperationImpl();
        }
    }
    
    /// <summary>
    /// 客户端, 桥接模式下, 客户端可以针对两个维度的抽象层编程, 在程序运行时动态的缺点两个维度的子类
    /// 动态的组合对象, 将两个独立的变化完全解耦, 以便能够灵活的扩充任一维度而对另一维度不造成任何影响.
    /// </summary>
    class BridgePatternClient
    {
        static void Run()
        {
            Abstraction abstraction = new RefinedAbstration();
            abstraction.SetImpl(new ConcreteImplementorA());
            abstraction.Operation();
        }
    }
}
