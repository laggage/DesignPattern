namespace DecoratorPattern.BaseImplement
{
    abstract class Component
    {
        public abstract void Operation();
    }

    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            //基本功能
        }
    }

    abstract class Decorator : Component
    {
        private Component _component;

        public Decorator(Component component)
        {
            _component = component;
        }

        public override void Operation()
        {
            _component.Operation(); //调用原有业务方法
        }
    }

    class ConcreteDecorator : Decorator
    {
        public ConcreteDecorator(Component component) : base(component)
        {
        }

        public override void Operation()
        {
            base.Operation(); //调用原有业务方法
            AddedBehavior();
        }

        //扩展业务方法
        public void AddedBehavior()
        {
            //功能扩展
        }
    }
}
