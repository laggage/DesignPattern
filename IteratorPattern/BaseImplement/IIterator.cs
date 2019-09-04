namespace IteratorPattern.BaseImplement
{
    using System;

    interface IIterator
    {
        void First(); //游标指向第一个元素
        void Next(); // 游标指向下一个元素
        bool HasNext();
        object CurrentItem();
    }

    class ConcreteIterator:IIterator
    {
        private ConcreteAggregate objects;  // 维持对具体聚合对象的引用, 以便于访问存储在聚合
                                            // 对象中的数据
                                                
        private int cursor;           // 定义游标, 用于访问当前位置

        public void First()
        {
            // 实现代码
        }

        public void Next()
        {
            // 实现代码
        }

        public bool HasNext()
        {
            // 实现代码
            throw new NotImplementedException();
        }

        public object CurrentItem()
        {
            // 实现代码
            throw new NotImplementedException();
        }
    }

    abstract class Aggregate
    {

    }

    class ConcreteAggregate: Aggregate
    {

    }
}
