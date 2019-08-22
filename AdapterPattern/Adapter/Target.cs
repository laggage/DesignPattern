namespace AdapterPattern.Adapter
{
    /// <summary>
    /// 客户所期待的接口, 可以是具体或抽象的类, 也可以是接口
    /// </summary>
    class Target
    {
        public virtual void Request() { }
    }

    /// <summary>
    /// 需要适配的类
    /// </summary>
    class Adaptee
    {
        public void SpecificRequest() { }
    }

    class Adapter:Target
    {
        private Adaptee _adaptee;

        public Adapter()
        {
            _adaptee = new Adaptee();
        }

        public override void Request()
        {
            this._adaptee.SpecificRequest();
        }
    }
}
