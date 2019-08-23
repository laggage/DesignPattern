# 享元模式(FlyweightPattern)

[TOC]

## 定义
> **运用共享技术有效的支持大量细粒度对象的复用.**

## 概述
如果一个软件系统在运行时创建相同或相似的对象数量太多, 将导致运行代价过高, 带来系统资源的浪费, 性能下降等问题. 享元模式通过相似对象的重用, 在逻辑上每一个出现的实例都有对象与之对应, 然而物理上它们却共享同一个享元对象. 享元模式中, 存储共享实例的地方称为享元池(Flyweight Pool).
享元模式以共享的方式高效的支持大量细粒度对象的重用, 享元对象能做到共享的关键是区分了内部状态(**Intrinsic State**)和外部状态(**Extrinsic State**).
### 内部状态
内部状态是存储在享元对象内部并且不会随环境改变而改变的状态,**内部状态可以共享**
### 外部状态
外部状态是随环境改变而改变的, **不可以共享**的状态.
享元对象的外部状态通常由客户端保存, 并在享元对象被创建之后, 需要使用的时候再传入享元对象的内部. 
一个外部状态与另一个外部状态之间相互独立.
例如, 字符的颜色, 在不同的地方, 有不同的颜色; 有的"a"是红色的, 有的"a"是绿色的, 字符的大小也是如此, 它们可以独立变化, 相互没有影响, 客户端可以在使用时将外部状态注入享元对象.

<br/>
<br/>

正因为区分了外部状态和内部状态, 可以将具有相同内部状态的对象存储到享元池中, 享元池中的对象可以实现共享, 需要的时候从享元池中取出, 即可实现复用.

### 其他
享元模式要求能够被共享的对象必须是细粒度对象, 又被称为**轻量级模式**.

## 结构

1. **抽象享元类(Flyweight)**
2. **具体享元类(ConcreteFlyweight)**
3. **非共享具体享元类(UnsharedConcreteFlyweight)**
4. **享元工厂类(FlyweightFactory)**

### UML
![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190823150408305-1309536435.png)

### 典型实现
```
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
```
## 应用实例

> 围棋软件的棋子, 围棋棋盘中包含大量黑子和白子, 它们形状, 大小都一模一样, 只是出现的位置不同. 若将每一个棋子都作为一个独立的对象存储在内存中, 将导致围棋软件运行时所需的内存空间较大. 

![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190823180015732-79475166.png)

```
namespace FlyweightPattern.Chessman
{
    using System;
    using System.Collections;

    public abstract class Chessman
    {
        public abstract ChessmanColor Color { get; }
        public abstract void Display();
    }

    public class WhiteChessman : Chessman
    {
        public override ChessmanColor Color { get; }

        public override void Display()
        {
            Console.WriteLine("-- White chessman --");
        }
    }

    public class BlackChessman :Chessman
    {
        public override ChessmanColor Color => ChessmanColor.Black;

        public override void Display()
        {
            Console.WriteLine("-- Black chessman --");
        }
    }

    public enum ChessmanColor
    {
        White,
        Black
    }

    public interface IChessmanFactory
    {
        Chessman GetBlackChessman();
        Chessman GetWhiteChessman();
    }

    public class ChessmanFactory : IChessmanFactory
    {
        #region ImplementSingleton

        private static ChessmanFactory _instance;
        private static object _syncRoot;
        public static ChessmanFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null) _instance = new ChessmanFactory();
                    }
                }
                return _instance;
            }
        }

        #endregion

        private Hashtable _chessman;
        private const string BlackChessmanKey = "Black";
        private const string WhiteChessmanKey = "White";

        #region Constructor

        static ChessmanFactory()
        {
            _syncRoot = new object();
        }

        public ChessmanFactory()
        {
            _chessman = new Hashtable();
        }

        #endregion

        public Chessman GetBlackChessman()
        {
            return GetOrCreateChessman(ChessmanColor.Black);
        }

        public Chessman GetWhiteChessman()
        {
            return GetOrCreateChessman(ChessmanColor.White);
        }

        private Chessman GetOrCreateChessman(ChessmanColor color)
        {
            string key = color == ChessmanColor.Black ? BlackChessmanKey : WhiteChessmanKey;
            if (_chessman.ContainsKey(key)) return _chessman[key] as Chessman;
            else
            {
                Chessman chessman;
                if (color == ChessmanColor.Black) chessman = new BlackChessman();
                else chessman = new WhiteChessman();
                _chessman.Add(key, chessman);
                return chessman;
            }
        }
    }
}

namespace FlyweightPattern
{
    using FlyweightPattern.Chessman;

    class Program
    {
        static void Main(string[] args)
        {
            Chessman.Chessman blackChess = ChessmanFactory.Instance.GetBlackChessman();
            Chessman.Chessman whiteChess = ChessmanFactory.Instance.GetWhiteChessman();

            blackChess.Display();
            whiteChess.Display();
        }
    }
}
```

<br/>
<br/>
<br/>

> 标准的享元模式结构图中既包含可以共享的具体享元类, 也包含不可以共享的具体享元类.

## 单纯享元模式
单纯享元模式中, 所有具体的享元类都是可以共享的, 不存在非共享具体享元类.
![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190823181913856-286187541.png)

## 复合享元模式
将一些单纯享元对象使用组合模式加以组合, 可以形成复合享元对象, 这样的复合享元对象本身不能共享, 但是它们可以分解成单纯享元对象, 而后者可以共享.
![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190823182216387-330388175.png)
通过使用复合享元模式, 可以让复合享元类(`CompositeConcreteFlyweight`) 中所包含的每个单纯享元类`ConcreteFlyweight` 都具有相同的外部状态, 而这些单纯享元的内部状态往往不同. 如果希望为多个内部状态不同的享元对象设置相同的外部状态, 可以考虑使用复合享元模式.
