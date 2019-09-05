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
