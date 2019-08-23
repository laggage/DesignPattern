namespace FlyweightPattern
{
    using FlyweightPattern.Chessman;

    class Program
    {
        static void Main(string[] args)
        {
            Chessman.Chessman blackChess = ChessmanFactory.Instance.GetBlackChessman();
            Chessman.Chessman whiteChess = ChessmanFactory.Instance.GetWhiteChessman();

            blackChess.Display();
            whiteChess.Display();
        }
    }
}
