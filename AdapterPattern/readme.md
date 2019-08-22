# 适配器模式

## 定义
将一个类的接口转换成客户希望的另一个接口, 适配器模式让那些接口不兼容的类可以一起工作.

## 结构
![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190822121035020-478113378.png)

## 代码实现
```
namespace AdapterPattern.Adapter
{
    /// <summary>
    /// 客户所期待的接口, 可以是具体或抽象的类, 也可以是接口
    /// </summary>
    class Target
    {
        public virtual void Request() { }
    }

    /// <summary>
    /// 需要适配的类
    /// </summary>
    class Adaptee
    {
        public void SpecificRequest() { }
    }

    class Adapter:Target
    {
        private Adaptee _adaptee;

        public Adapter()
        {
            _adaptee = new Adaptee();
        }

        public override void Request()
        {
            this._adaptee.SpecificRequest();
        }
    }
}
```

## 适配器模式的缺点
- 对于C# java等不支持多重继承的语言, 一次最多只能适配一个适配者类, 不能同时适配多个适配者;
- 适配者类不能为最终类, C#中不能为**sealed**类;


## 何时使用

当我们想使用一个已经存在的类, 但是它的接口, 也就是它的方法和我们要求的不同时, 考虑使用适配器模式, 也就是两个类所作的事情相同或相似, 但具有不同的接口时要使用它.
客户代码可以调用统一的接口, 更简单, 更直接, 更紧凑;

注意, 不可滥用适配器, 适配器模式其实是一种 **无奈之举**, 更好的选择是再设计阶段, 就把类似的功能类的就扣设计成相同的. 当接口不相同时, 首先应该考虑重构统一的接口.
只有再双方都不太容易修改的时候再使用适配器模式.
也有在设计之初就需要考虑使用适配器模式的时候, 例如设计系统时考虑使用第三方开发组件, 而这个组件的接口与我们自己的接口不相同, 我们没有必要为了迎合它而改动自己的接口.

##　适配器模式再.net中的应用
**`DataAdapter`**, `DataAdapter` 用作 DataSet 和数据源之间的适配器以便检索和保存数据.
