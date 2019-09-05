﻿namespace MeidatorPattern.Sample
{
    using System;

    class ComboxBox : Component
    {
        public override void Update()
        {
            Console.WriteLine("组合框增加一项: 张无忌");
        }

        public void Select()
        {
            Console.WriteLine("组合框选中项: 小龙女");
        }
    }
}
