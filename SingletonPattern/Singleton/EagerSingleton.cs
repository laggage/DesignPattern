namespace SingletonPattern.Singleton
{
    class EagerSingleton
    {
        private static readonly EagerSingleton _instance = new EagerSingleton();

        private EagerSingleton() { }

        public EagerSingleton GetInstance() => _instance;
    }
}
