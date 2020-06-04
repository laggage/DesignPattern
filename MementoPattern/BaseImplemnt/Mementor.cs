namespace MementoPattern.BaseImplemnt
{
    using System;

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
