namespace FlyweightPattern.Chessman
{
    using System;
    using System.Collections;

    public abstract class Chessman
    {
        public abstract ChessmanColor Color { get; }
        public abstract void Display();
    }

    public class WhiteChessman : Chessman
    {
        public override ChessmanColor Color { get; }

        public override void Display()
        {
            Console.WriteLine("-- White chessman --");
        }
    }

    public class BlackChessman :Chessman
    {
        public override ChessmanColor Color => ChessmanColor.Black;

        public override void Display()
        {
            Console.WriteLine("-- Black chessman --");
        }
    }

    public enum ChessmanColor
    {
        White,
        Black
    }

    public interface IChessmanFactory
    {
        Chessman GetBlackChessman();
        Chessman GetWhiteChessman();
    }

    public class ChessmanFactory : IChessmanFactory
    {
        #region ImplementSingleton

        private static ChessmanFactory _instance;
        private static object _syncRoot;
        public static ChessmanFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null) _instance = new ChessmanFactory();
                    }
                }
                return _instance;
            }
        }

        #endregion

        private Hashtable _chessman;
        private const string BlackChessmanKey = "Black";
        private const string WhiteChessmanKey = "White";

        #region Constructor

        static ChessmanFactory()
        {
            _syncRoot = new object();
        }

        public ChessmanFactory()
        {
            _chessman = new Hashtable();
        }

        #endregion

        public Chessman GetBlackChessman()
        {
            return GetOrCreateChessman(ChessmanColor.Black);
        }

        public Chessman GetWhiteChessman()
        {
            return GetOrCreateChessman(ChessmanColor.White);
        }

        private Chessman GetOrCreateChessman(ChessmanColor color)
        {
            string key = color == ChessmanColor.Black ? BlackChessmanKey : WhiteChessmanKey;
            if (_chessman.ContainsKey(key)) return _chessman[key] as Chessman;
            else
            {
                Chessman chessman;
                if (color == ChessmanColor.Black) chessman = new BlackChessman();
                else chessman = new WhiteChessman();
                _chessman.Add(key, chessman);
                return chessman;
            }
        }
    }
}
