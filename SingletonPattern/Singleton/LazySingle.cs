namespace SingletonPattern.Singleton
{
    class LazySingle
    {
        private LazySingle _instance;
        private readonly object _syncRoot;

        private LazySingle()
        {
            _syncRoot = new object();
        }

        public LazySingle GetInstance()
        {
            ////单重锁定, 每次调用此方法都会加锁, 造成性能损失
            //lock(_syncRoot)
            //{
            //    if (_instance == null)
            //        _instance = new LazySingle();
            //}
           
            // 双重锁定
            if(_instance == null)
            {
                lock(_syncRoot)
                {
                    if (_instance == null)
                        _instance = new LazySingle();
                }
            }

            return _instance;
        }
    }
}
