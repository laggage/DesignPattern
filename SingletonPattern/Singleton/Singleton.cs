namespace SingletonPattern.Singleton
{
    class Singleton
    {
        private Singleton _instance;

        private Singleton()
        { }

        public Singleton GetInstance()
        {
            if (_instance == null)
                _instance = new Singleton();
            return _instance;
        }
    }
}
