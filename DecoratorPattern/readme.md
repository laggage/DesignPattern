# 装饰模式(Decorator)

## 概述
装饰模式是一种用于替代继承的技术, 通过一种无需定义子类的方式给对象动态添加职责, 使对象之间的关联关系取代类之间的继承关系.

装饰器的价值在于装饰, 他并不影响被装饰类本身的核心功能. 在一个继承的体系中, **子类通常是互斥的**;
比如一辆车, 品牌只能要么是奥迪、要么是宝马, 不可能同时属于奥迪和宝马, 而品牌也是一辆车本身的重要属性特征; 但**当你想要给汽车喷漆**, **换坐垫**, 或者**更换音响**时，这些功能是互相可能兼容的，并且他们的存在不会影响车的核心属性:那就是他是一辆什么车; 这时你就**可以定义一个装饰器**: **喷了漆的车**; 不管他装饰的车是宝马还是奥迪, 他的喷漆效果都可以实现;

## 定义
动态的给一个对象增加一些额外的职责. 就扩展功能而言, 装饰模式提供了一种比使用子类更加灵活的替代方案.

## 结构

1. 抽象构件(Component)
2. 具体构件(ConcreteComponent)
3. 抽象装饰类(Decorator)
4. 具体装饰类(ConcreteDecorator)

![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190823013016899-806795745.png)

## 实现

```csharp
namespace DecoratorPattern.BaseImplement
{
    abstract class Component
    {
        public abstract void Operation();
    }

    class ConcreteComponent: Component
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

    class ConcreteDecorator:Decorator
    {
        public ConcreteDecorator(Component component):base(component)
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
```

## 应用实例

> 开发图形界面构件库 ---- VisualComponent
> 该构件库提供了大量基本构件, 如窗体, 文本框, 列表框等; 由于在使用构件库时, 用户经常要求定制一些特殊的显示效果, 如带滚动条的窗体, 带黑色边框的文本框, 既带滚动条又带黑色边框的列表框等, 因此经常需要扩展该构件库.

### 实现

![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190823020159607-1519977072.png)

```csharp
namespace DecoratorPattern.VisualComponent
{
    using System;

    public abstract class ComponentDecorator : VisualComponent
    {
        VisualComponent _component;

        public ComponentDecorator(VisualComponent component)
        {
            _component = component;
        }

        public override void Display()
        {
            _component.Display();
        }
    }

    public abstract class VisualComponent
    {
        public abstract void Display();
    }

    public class Window : VisualComponent
    {
        public override void Display()
        {
            Console.WriteLine("--- Window ---"); 
        }
    }

    public class TextBox : VisualComponent
    {
        public override void Display()
        {
            Console.WriteLine("--- Textbox ---");
        }
    }

    public class ListBox : VisualComponent
    {
        public override void Display()
        {
            Console.WriteLine("--- ListBox ---");
        }
    }

    public class ScrollBarDecorator :  ComponentDecorator
    {
        public ScrollBarDecorator(VisualComponent component):base(component)
        {
        }

        public override void Display()
        {
            ShowScrollBar();
            base.Display();
        }

        private void ShowScrollBar()
        {
            Console.WriteLine("--- ScrollBar ---");
        }
    }

    public class BlackBorderDecorator :  ComponentDecorator
    {
        public BlackBorderDecorator(VisualComponent component):base(component)
        {
        }

        public override void Display()
        {
            Console.WriteLine("<==== BlackBorder ====>");
            base.Display();
            Console.WriteLine("<==== BlackBorder ====>\r\n");
        }
    }
}

namespace DecoratorPattern
{
    using System;
    using DecoratorPattern.VisualComponent;

    class Program
    {
        static void Main(string[] args)
        {
            VisualComponent.VisualComponent txtBox = new TextBox();
            var lstBox = new ListBox();

            var borderListBox = new BlackBorderDecorator(lstBox);
            var scrollBorderListBox = new ScrollBarDecorator(borderListBox);
            var scrollTextBox = new ScrollBarDecorator(txtBox);

            borderListBox.Display();
            scrollBorderListBox.Display();
            scrollTextBox.Display();

            Console.ReadKey();
        }
    }
}
```

![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190823020331819-182002911.png)

## 应用实例 - 基础日志的功能上加上打印时间的功能

已经完成了一个日志的接口和它的各个实现类, 但是这些类只有输出日志到不同地方的功能,`LoggerFileSystem`能将日志输出到文件系统（磁盘）中, `LoggerCloud`能将日志输出到云端的某个文件中。现在新需求来了, 我想要在每条日志输出前输出这条日志的时间, 又不想去修改每个实现类的方法, 这时候就能使用装饰者模式, 为这个接口编写一个装饰类, 修饰原来的日志输出;(这只是一个简单的例子，正常的日志输出一般都带有时间)



## .net core中的装饰模式

**Stream**类

![image](https://user-images.githubusercontent.com/38829279/83660292-3ac95680-a5f7-11ea-9714-47e20f9df2d8.png)

`BufferedStream` `CryptoStream` 充当了 `ConcreteDecorator` 角色, 注意这里没有抽象`Decorator`;
