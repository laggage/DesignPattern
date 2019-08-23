namespace FlyweightPattern.BaseImplement
{
    using System.Collections;

    abstract class Flyweight
    {
        public abstract void Operation(string extrinsicState);
    }

    class ConcreteFlyweight: Flyweight
    {
        // 同一个享元的内部状态是一致的
        private string _intrinsicState;

        public ConcreteFlyweight(string intrinsicState)
        {
            _intrinsicState = intrinsicState;
        }

        public override void Operation(string extrinsicState)
        {
            //实现业务方法
        }
    }

    class UnSharedConcreteFlyweight : Flyweight
    {
        public override void Operation(string extrinsicState)
        {
            // 实现业务方法
        }
    }

    /// <summary>
    /// 享元工厂, 用于存储享元对象的享元池, 用户需要对象是, 首先从享元池获取, 享元池不存在时,
    /// 则创建一个新的对象返回给用户, 并在享元池保存该新增对象
    /// </summary>
    class FlyweightFactory
    {
        // 存储享元对象, 实现享元池
        private Hashtable _flyweights;

        public FlyweightFactory()
        {
            _flyweights = new Hashtable();
        }

        public Flyweight GetFlyweight(string key)
        {
            //对象存在, 直接从享元池获取
            if (_flyweights.ContainsKey(key))
                return _flyweights[key] as Flyweight;
            //对象不存在, 先创建对象, 添加到享元池, 然后返回
            else
            {
                Flyweight fw = new ConcreteFlyweight("state");
                _flyweights.Add(key, fw);
                return fw;
            }
        }
    }
}
