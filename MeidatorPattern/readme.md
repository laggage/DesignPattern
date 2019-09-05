# 中介者模式(MediatorPattern)

## 概述

软件系统中, 某些类/对象之间的相互调用关系错综复杂, 需要一个中间类来协调这些类, 以降低系统的耦合度. 中介者模式为此而诞生;

![image](https://user-images.githubusercontent.com/38829279/64312756-ec414a00-cfdb-11e9-9afb-6924dee1e89e.png)


## 定义

中介者模式：定义一个对象来封装一系列对象的交互。中介者模式使各对象之间不需要显式地相互引用，从而使其耦合松散，而且让你可以独立地改变它们之间的交互。

Mediator Pattern: Define an object that encapsulates how a set of objects interact. Mediator promotes loose coupling by keeping objects from referring to each other explicitly, and it lets you vary their interaction independently.

## 结构

![image](https://user-images.githubusercontent.com/38829279/64312773-01b67400-cfdc-11e9-85f5-9e52fa4f85f3.png)

### Mediator（抽象中介者）
### ConcreteMediator（具体中介者）
### Colleague（抽象同事类）
### ConcreteColleague（具体同事类）

### 典型中介者代码

```
using System.Collections.Generic;
abstract class Mediator
{
    protected List<Colleague> colleagues = new List<Colleague>(); //用于存储同事对象
    //注册方法，用于增加同事对象
    public void Register(Colleague colleague)
    {
        colleagues.Add(colleague);
    }
    //声明抽象的业务方法
    public abstract void Operation();
}
```

### 典型具体中介者代码

```
class ConcreteMediator : Mediator
{
    //实现业务方法，封装同事之间的调用
    public override void Operation() 
    {
	......
	((Colleague)(colleagues[0])).Method1(); //通过中介者调用同事类的方法
	......
    }
}
```

### 典型抽象同事类代码

```
abstract class Colleague
{
    protected Mediator mediator; //维持一个抽象中介者的引用
    public Colleague(Mediator mediator)
    {
        this.mediator = mediator;
    }
    public abstract void Method1(); //声明自身方法，处理自己的行为
    //定义依赖方法，与中介者进行通信
    public void Method2()
    {
        mediator.Operation();
    }
}
```

### 典型具体同事类代码

```
class ConcreteColleague : Colleague
{
    public ConcreteColleague(Mediator mediator)
        : base(mediator)
    {
    }
    //实现自身方法
    public override void Method1() 
    {
	......
    }
}
```

## 应用

某软件公司要开发一套CRM系统，其中包含一个客户信息管理模块，所设计的“客户信息管理窗口”界面效果图如下图所示：
 
![image](https://user-images.githubusercontent.com/38829279/64312949-99b45d80-cfdc-11e9-846c-174cca634cc0.png)
“客户信息管理窗口”界面效果图

通过分析发现，在上图中，界面组件之间存在较为复杂的交互关系：如果删除一个客户，将从客户列表(List)中删掉对应的项，客户选择组合框(ComboBox)中的客户名称也将减少一个；如果增加一个客户信息，则客户列表中将增加一个客户，且组合框中也将增加一项。
为了更好地处理界面组件之间的交互，现使用中介者模式设计该系统
<br/>

![image](https://user-images.githubusercontent.com/38829279/64312977-acc72d80-cfdc-11e9-8fa5-7e69b5b50f2b.png)

![image](https://user-images.githubusercontent.com/38829279/64340209-32b49a00-d018-11e9-9c22-1af6d9fa1410.png)

中介者 `Mediator` `ConcreteMediator`

<details>
<summary>点击展开查看代码</summary>

```
namespace MeidatorPattern.Sample
{
    using System;

    abstract class Mediator
    {
        public ListBox List { get; set; }
        public Button Button { get; set; }
        public ComboxBox ComboBox { get; set; }
        public TextBox TextBox { get; set; }


        public abstract void ComponentChanged(Component component);
    }

    class ConcreteMediator: Mediator
    {
        public override void ComponentChanged(Component component)
        {
            if (component == Button)
            {
                Console.WriteLine("----- 单击增加按钮 -----");
                ComboBox.Update();
                List.Update();
                TextBox.Update();
            }
            else if (component == List)
            {
                Console.WriteLine("----- 列表框选择客户 -----");
                ComboBox.Select();
                TextBox.SetText();
            }
            else if (component == ComboBox)
            {
                Console.WriteLine("----- 组合选择客户 -----");
                List.Select();
                TextBox.SetText();
            }
        }
    }
}
```
</details>

抽象同事类和同事类

<details>
<summary>点击展开查看代码</summary>

```
namespace MeidatorPattern.Sample
{
    abstract class Component
    {
        protected Mediator mediator;

        public void SetMediator(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public void Changed()
        {
            mediator.ComponentChanged(this);
        }

        public abstract void Update();
    }
}

namespace MeidatorPattern.Sample
{
    class Button : Component
    {
        public override void Update()
        {
            //Console.WriteLine("");
        }
    }
}

namespace MeidatorPattern.Sample
{
    class Button : Component
    {
        public override void Update()
        {
            //Console.WriteLine("");
        }
    }
}

namespace MeidatorPattern.Sample
{
    using System;

    class TextBox : Component
    {
        public override void Update()
        {
            Console.WriteLine("客户信息增加成功, 文本框清空. ");
        }

        public void SetText()
        {
            Console.WriteLine("文本框显示: 小龙女");
        }
    }
}
```
</details>
