namespace ProxyPattern.Searcher
{
    using System;

    interface ISearcher
    {
        string DoSearch(string userId, string keyword);
    }

    class Searcher:ISearcher
    {
        public string DoSearch(string userId, string keyword)
        {
            Console.WriteLine("用户'{0}'使用关键字'{1}'查询.", userId, keyword);
            return "具体内容";
        }
    }

    class AccessValidator
    {
        public bool Validate(string userId)
        {
            Console.WriteLine("在数据库中验证用户'{0}'是否合法", userId);
            if (userId.Equals("容儿"))
            {

                Console.WriteLine("用户{0}合法.", userId);
                return true;
            }
            else
            {
                Console.WriteLine("用户{0}非法.", userId);
                return false;
            }
        }
    }

    class Logger
    {
        public void Log(string userId)
        {
            Console.WriteLine("更新数据库, 用户{0}查询次数加一.", userId);
        }
    }

    class ProxySearcher:ISearcher
    {
        private AccessValidator _validator;
        private Logger _logger;
        private Searcher _searcher;

        public ProxySearcher()
        {
            _validator = new AccessValidator();
            _logger = new Logger();
            _searcher = new Searcher();
        }

        public string DoSearch(string userId, string keyword)
        {
            string result = string.Empty;
            if(_validator.Validate(userId))
            {
                result = _searcher.DoSearch(userId, keyword);
                _logger.Log(userId);
            }
            return result;
        }
    }
}
