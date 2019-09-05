namespace MeidatorPattern.Sample
{
    using System;

    class TextBox : Component
    {
        public override void Update()
        {
            Console.WriteLine("客户信息增加成功, 文本框清空. ");
        }

        public void SetText()
        {
            Console.WriteLine("文本框显示: 小龙女");
        }
    }
}
