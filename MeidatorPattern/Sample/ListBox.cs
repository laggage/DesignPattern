namespace MeidatorPattern.Sample
{
    using System;

    class ListBox : Component
    {
        public override void Update()
        {
            Console.WriteLine("列表框增加一项: 张无忌");
        }

        public void Select()
        {
            Console.WriteLine("列表框选中一项: 张无忌");
        }
    }
}
