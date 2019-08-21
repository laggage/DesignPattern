## 建造者模式(Builder Pattern)

### 结构图
![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190821191126553-1265976807.png)

### 定义
将一个复杂对象的构建与它的表示分离, 使得同样的构建过程可以创建不同的表示.

### 适用场景
建造者模式是在当创建复杂对象的算法应该独立于该对象的组成部分以及他们的装配方式时适用的模式.

### 应用实例

#### 画小人( <<大话设计模式>> )
![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190821212510889-1147683575.png)
```
namespace BuilderPattern.DrawPerson
{
    using System;
    using System.Drawing;

    public abstract class PersonBuilder
    {
        private readonly Graphics _graphics;
        private readonly Pen _pen;

        public PersonBuilder(Graphics graphics, Pen pen)
        {
            _pen = pen;
            _graphics = graphics;
        }

        public abstract void BuildArmLeft();
        public abstract void BuildArmRight();
        public abstract void BuildLegLeft();
        public abstract void BuildLegRight();
        public abstract void BuildHead();
        public abstract void BuildBody();
    }

    public class ThinPersonBuilder : PersonBuilder
    {
        public ThinPersonBuilder(Graphics graphics, Pen pen):base(graphics,pen)
        {
        }

        public override void BuildArmLeft()
        {
            Console.WriteLine("Left Arm");
        }

        public override void BuildArmRight()
        {
            Console.WriteLine("Right Arm");
        }

        public override void BuildLegLeft()
        {
            Console.WriteLine("Left Leg");
        }

        public override void BuildLegRight()
        {
            Console.WriteLine("Right Leg");
        }

        public override void BuildHead()
        {
            Console.WriteLine("Head");
        }

        public override void BuildBody()
        {
            Console.WriteLine("Thin body");
        }
    }

    public class FatPersonBuilder : PersonBuilder
    {
        public FatPersonBuilder(Graphics graphics, Pen pen) : base(graphics, pen)
        {
        }

        public override void BuildArmLeft()
        {
            Console.WriteLine("Left Arm");
        }

        public override void BuildArmRight()
        {
            Console.WriteLine("Right Arm");
        }

        public override void BuildLegLeft()
        {
            Console.WriteLine("Left Leg");
        }

        public override void BuildLegRight()
        {
            Console.WriteLine("Right Leg");
        }

        public override void BuildHead()
        {
            Console.WriteLine("Head");
        }

        public override void BuildBody()
        {
            Console.WriteLine("Fat body");
        }
    }  
}

namespace BuilderPattern.DrawPerson
{
    public class PersonDirector
    {
        private PersonBuilder _personBuilder;

        public PersonDirector(PersonBuilder builder)
        {
            _personBuilder = builder;
        }

        public void CreatePerson()
        {
            _personBuilder.BuildHead();
            _personBuilder.BuildBody();
            _personBuilder.BuildArmLeft();
            _personBuilder.BuildArmRight();
            _personBuilder.BuildLegLeft();
            _personBuilder.BuildLegRight();
        }
    }
}

namespace BuilderPattern
{
    using System;
    using BuilderPattern.DrawPerson;

    class Program
    {
        static void Main(string[] args)
        {
            ThinPersonBuilder thinPersonBuilder = new ThinPersonBuilder(null,null);
            FatPersonBuilder fatPersonBuilder = new FatPersonBuilder(null, null);
            PersonDirector director = new PersonDirector(fatPersonBuilder);
            Console.WriteLine("<============== Build fat person ==============>");
            director.CreatePerson();
            Console.WriteLine("<============== Build fat person ==============>");

            Console.WriteLine();
            director = new PersonDirector(thinPersonBuilder);
            Console.WriteLine("<============== Build thin person ==============>");
            director.CreatePerson();
            Console.WriteLine("<============== Build thin person ==============>");

            Console.ReadKey();
        }
    }
}

```

## .net中建造者模式的实现
**`StringBuilder`**
不过它的实现属于**建造者模式的演化**，此时的建造者模式没有指挥者角色和抽象建造者角色，`StringBuilder`类即扮演着具体建造者的角色，也同时扮演了指挥者和抽象建造者的角色，`StringBuilder`类扮演着建造string对象的具体建造者角色，其中的**ToString()**方法用来返回具体产品给客户端（相当于上面代码中**GetProduct**方法）。其中**Append**方法用来创建产品的组件(相当于上面代码中**BuildPartA**和**BuildPartB**方法)，**因为string对象中每个组件都是字符，所以也就不需要指挥者的角色的代码**（指的是**Construct**方法,用来调用创建每个组件的方法来完成整个产品的组装），因为string字符串对象中每个组件都是一样的,都是字符,所以Append方法也充当了指挥者Construct方法的作用。

