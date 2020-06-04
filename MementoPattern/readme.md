# 备忘录模式

## 概述

备忘录模式是软件系统中的"**月光宝盒**", 提供了一种对象状态撤销的实现机制.

![image](https://user-images.githubusercontent.com/38829279/64341363-c4250b80-d01a-11e9-803e-f7a0ef080ce5.png)

## 定义

备忘录模式：在不破坏封装的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态，这样就可以在以后将对象恢复到原先保存的状态。

Memento Pattern: Without violating encapsulation, capture and externalize an object's internal state so that the object can be restored to this state later.

## 结构

![image](https://user-images.githubusercontent.com/38829279/64341426-e4ed6100-d01a-11e9-9b42-20d7accc1148.png)

备忘录模式包含以下3个角色：
### Originator（原发器）
### Memento（备忘录)
### Caretaker（负责人）

**代码实现**

<details>
<summary>点击展开查看代码</summary>

```csharp
namespace MementoPattern.BaseImplemnt
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Originator
    {
        public string State { get; set; }

        public Originator(string state)
        {
            State = state;
        }

        /// <summary>
        /// 创建一个备忘录对象
        /// </summary>
        /// <returns>备忘录对象</returns>
        internal Memento CreateMemento()
        {
            return new Memento(this);
        }

        internal void RestoreMemento(Memento m)
        {
            State = m.State;
        }
    }

    /// <summary>
    /// 备忘录类, 默认可见性, 程序集内可见, 确保只能被Origiantor类访问
    /// </summary>
    internal class Memento
    {
        public string State { get; set; }

        public Memento(Originator o)
        {
            State = o.State;
        }
    }

    /// <summary>
    /// 负责人类, 提供GetMementor() 方法用于向客户端返回一个备忘录对象, 原发器通过使用这个备忘录对象
    /// 可以回到某个历史状态.
    /// </summary>
    class CareTaker
    {
        private Memento memento;

        internal Memento GetMemento()
        {
            return memento;
        }

        internal void SetMemonto(Memento m)
        {
            memento = m;
        }
    }

    /// <summary>
    /// Caretaker类不应该直接调用Memento中的状态改变方法, 它的作用仅仅是存储备忘录对象;
    /// 客户端代码中可以通过创建Mementor对象来保存原发器的历史状态, 
    /// 再需要的时候再用历史状态来覆盖当前状态.
    /// </summary>
    class Client
    {
        public static void Run()
        {
            Originator originator = new Originator("状态 - 1");
            Console.WriteLine(originator.State);

            CareTaker careTaker = new CareTaker();
            careTaker.SetMemonto(originator.CreateMemento());

            originator.State = "状态 - 2";
            Console.WriteLine(originator.State);

            // 实现撤销
            originator.RestoreMemento(careTaker.GetMemento());
            Console.WriteLine(originator.State);
        }
    }
}
```
</details>

## 应用实例

### 悔棋功能

Chessman

<details>
<summary>点击展开查看代码</summary>

```csharp
namespace MementoPattern.Sample
{
    using System;

    class Chessman
    {
        internal int X { get; set; }
        internal int Y { get; set; }
        internal string Label { get; set; }

        public Chessman()
        {
        }

        public Chessman(int x, int y, string label)
        {
            X = x;
            Y = y;
            Label = label;
        }

        internal ChessmanMemento Save()
        {
            return new ChessmanMemento(X, Y, Label);
        }

        internal void Restore(ChessmanMemento memento)
        {
            X = memento.X;
            Y = memento.Y;
            Label = memento.Label;
        }

        public void Display()
        {
            Console.WriteLine("{2},X = {0}, Y = {1}", X, Y, Label);
        }
    }
}
```
</details>

ChessmanMemento

<details>
<summary>点击展开查看代码</summary>

```csharp
namespace MementoPattern.Sample
{
    using System.Collections.Generic;

    class ChessmanMemento
    {
        public ChessmanMemento(int x, int y, string label)
        {
            this.X = x;
            this.Y = y;
            this.Label = label;
        }

        public int X { get; }
        public int Y { get; }
        public string Label { get; }
    }

    class ChessmanCareTaker
    {
        private readonly Stack<ChessmanMemento> mementos;
        private int steps;
        // 限制最多存储十个状态
        public int MaxStep { get; set; }

        public ChessmanCareTaker()
        {
            mementos = new Stack<ChessmanMemento>(10);
            MaxStep = 10;
            steps = 0;
        }

        public void Push(ChessmanMemento memento)
        {
            if ((++steps) == 10) return;
            mementos.Push(memento);
        }

        public ChessmanMemento Pop()
        {
            if (mementos.Count <= 0) return null;
            return mementos.Pop();
        }

        public bool HasMemento => mementos.Count > 0;
    }
}
```
</details>

客户端代码

```csharp
namespace MementoPattern.Sample
{
    using System;

    class SampleClient
    {
        public static void Run()
        {
            ChessmanCareTaker careTaker = new ChessmanCareTaker();
            Chessman chess = new Chessman(0,0,"🐎");

            chess.Display();
            careTaker.Push(chess.Save());
            
            chess.X = 3;
            chess.Y = 3;
            chess.Display();
            careTaker.Push(chess.Save());

            chess.X = 5;
            chess.Y = 6;
            chess.Display();

            Console.WriteLine("----- 悔棋 -----");
            chess.Restore(careTaker.Pop());
            chess.Display();

            Console.WriteLine("----- 悔棋 -----");
            chess.Restore(careTaker.Pop());
            chess.Display();
        }
    }
}
```

### 游戏进度的保存


`GameRole` 充当 `Originator` 角色

<details>
<summary>GameRole</summary>

```csharp
using System;

namespace MementoPattern.Sample.GameProcess
{
    public class GameRole
    {
        /// <summary>
        /// 生命力
        /// </summary>
        public int Vatility { get; set; }
        /// <summary>
        /// 攻击力
        /// </summary>
        public int ATK { get; set; }
        /// <summary>
        /// 防御力
        /// </summary>
        public int Defensive { get; set; }

        public GameRole(int vatility, int atk, int defensive)
        {
            Vatility = vatility;
            ATK = atk;
            Defensive = defensive;
        }

        public GameRole()
        {
        }

        public void DisplayState()
        {
            Console.WriteLine(new string('-', 20));
            Console.WriteLine($"生命: {Vatility}; 攻击力: {ATK}; 防御: {Defensive}\r\n");
        }

        public void Fight()
        {
            Console.WriteLine("Fighting...");
            Vatility = Vatility > 10 ? Vatility - 10 : Vatility;
            ATK = ATK > 10 ? ATK - 10 : ATK;
            Defensive = Defensive > 10 ? Defensive - 10 : Defensive;
            DisplayState();
        }

        /// <summary>
        /// 保存状态
        /// </summary>
        /// <returns></returns>
        public RoleStateMemento CreateRoleStateMemento()
        {
            return new RoleStateMemento(Vatility, ATK, Defensive);
        }

        /// <summary>
        /// 恢复状态
        /// </summary>
        public void RestoreState(RoleStateMemento memento)
        {
            Vatility = memento.Vatility;
            ATK = memento.ATK;
            Defensive = memento.Defensive;
        }
    }
}
```
</details>

<details>
<summary>RoleStateMemento</summary>

```csharp
namespace MementoPattern.Sample.GameProcess
{
    public class RoleStateMemento
    {
        /// <summary>
        /// 生命力
        /// </summary>
        public int Vatility { get; set; }
        /// <summary>
        /// 攻击力
        /// </summary>
        public int ATK { get; set; }
        /// <summary>
        /// 防御力
        /// </summary>
        public int Defensive { get; set; }

        public RoleStateMemento(int vatility, int atk, int defensive)
        {
            Vatility = vatility;
            ATK = atk;
            Defensive = defensive;
        }
    }
}
```
</details>

<details>
<summary>RoleStateCareTaker</summary>

```csharp
namespace MementoPattern.Sample.GameProcess
{
    public class RoleStateMemento
    {
        /// <summary>
        /// 生命力
        /// </summary>
        public int Vatility { get; set; }
        /// <summary>
        /// 攻击力
        /// </summary>
        public int ATK { get; set; }
        /// <summary>
        /// 防御力
        /// </summary>
        public int Defensive { get; set; }

        public RoleStateMemento(int vatility, int atk, int defensive)
        {
            Vatility = vatility;
            ATK = atk;
            Defensive = defensive;
        }
    }
}
```
</details>
