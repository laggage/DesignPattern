namespace ProxyPattern.BaseImplement
{
    abstract class Subject
    {
        public abstract void Request();
    }

    class RealSubject:Subject
    {
        public override void Request()
        {
            //业务方法具体实现代码
        }
    }


    class Proxy:Subject
    {
        private RealSubject _realSubject;

        public Proxy()
        {
            _realSubject = new RealSubject();
        }

        public void PreRequest()
        { }

        public override void Request()
        {
            PreRequest();
            _realSubject.Request();
            PostRequest();
        }

        public void PostRequest()
        { }
    }
}
