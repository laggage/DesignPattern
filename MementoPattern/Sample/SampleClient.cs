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
