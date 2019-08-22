# 单例模式(SingletonPattern)

## 定义
确保一个类只有一个实例, 并提供全局访问点来访问这个实例.

## 结构
![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190822113754461-1672076142.png)

## 要点
1. 某个类只能有一个实例
2. 它必须自行创建这个实例
3. 必须自行向整个系统提供这个实例

## 实现
```
namespace SingletonPattern.Singleton
{
    class Singleton
    {
        private Singleton _instance;

        private Singleton()
        { }

        public Singleton GetInstance()
        {
            if (_instance == null)
                _instance = new Singleton();
            return _instance;
        }
    }
}
```

## 饿汉式与懒汉式单例
### 饿汉式单例
```
namespace SingletonPattern.Singleton
{
    class EagerSingleton
    {
        private static readonly EagerSingleton _instance = new EagerSingleton();

        private EagerSingleton() { }

        public EagerSingleton GetInstance() => _instance;
    }
}

```
当类被加载时, 静态变量 `_instance` 会被初始化, 此时类的私有构造函数被调用, 单例类的唯一实例被创建.

### 懒汉式单例与双重检查锁定
```
namespace SingletonPattern.Singleton
{
    class LazySingle
    {
        private LazySingle _instance;
        private readonly object _syncRoot;

        private LazySingle()
        {
            _syncRoot = new object();
        }

        public LazySingle GetInstance()
        {
            ////单重锁定, 每次调用此方法都会加锁, 造成性能损失
            //lock(_syncRoot)
            //{
            //    if (_instance == null)
            //        _instance = new LazySingle();
            //}
           
            // 双重锁定
            if(_instance == null)
            {
                lock(_syncRoot)
                {
                    if (_instance == null)
                        _instance = new LazySingle();
                }
            }

            return _instance;
        }
    }
}

```

使用了 **双重检查锁定(Double Check Locking)** 机制.
 