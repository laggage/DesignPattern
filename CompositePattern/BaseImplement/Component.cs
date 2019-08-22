namespace CompositePattern.BaseImplement
{
    using System;
    using System.Collections.Generic;

    abstract class Component
    {
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract Component GetChild(int i);
        public abstract void Operation();
    }

    /// <summary>
    /// 叶子构件典型结构
    /// </summary>
    class Leaf:Component
    {
        public override void Add(Component c)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Component c)
        {
            throw new NotImplementedException();
        }

        public override Component GetChild(int i)
        {
            return null;
        }

        public override void Operation()
        {
           // 叶子构件具体的业务方法的实现
        }
    }

    class Composite:Component
    {
        private List<Component> _childs;

        public Composite()
        {
            _childs = new List<Component>();
        }

        public override void Add(Component c)
        {
            _childs.Add(c);
        }

        public override void Remove(Component c)
        {
            _childs.Remove(c);
        }

        public override Component GetChild(int i)
        {
            return _childs[i];
        }

        public override void Operation()
        {
            //容器构件具体业务方法的实现
            foreach(Component child in _childs)
            {
                child.Operation();
            }
        }
    }
}
