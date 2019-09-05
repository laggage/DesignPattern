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
