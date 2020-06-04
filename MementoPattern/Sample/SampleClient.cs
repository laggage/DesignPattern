using DesignParttern.Shared;
using System;

namespace MementoPattern.Sample
{
    class SampleClient : ISampleClient
    {
        public void Run()
        {
            var careTaker = new ChessmanCareTaker();
            var chess = new Chessman(0, 0, "🐎");

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

        public override string ToString()
        {
            return "备忘录模式实例 - 悔棋";
        }
    }
}
