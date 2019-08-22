# 装饰模式(Decorator)

## 概述
装饰模式是一种用于替代继承的技术, 通过一种无需定义子类的方式给对象动态添加职责, 使对象之间的关联关系取代类之间的继承关系.

## 定义
动态的给一个对象增加一些额外的职责. 就扩展功能而言, 装饰模式提供了一种比使用子类更加灵活的替代方案.

## 结构

1. 抽象构件(Component)
2. 具体构件(ConcreteComponent)
3. 抽象装饰类(Decorator)
4. 具体装饰类(ConcreteDecorator)

![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190823013016899-806795745.png)

## 实现

```
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

```
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

