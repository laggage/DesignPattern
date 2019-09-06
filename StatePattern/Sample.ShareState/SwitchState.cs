using System;

namespace StatePattern.Sample.ShareState
{
    abstract class SwitchState
    {
        public abstract void On(Switch s);
        public abstract void Off(Switch s);
    }

    class OnState : SwitchState
    {
        public override void On(Switch s)
        {
            Console.WriteLine("开关已经打开.");
        }

        public override void Off(Switch s) 
        {
            s.SetState(s.GetState("off"));
            Console.WriteLine("开关关闭.");
        }
    }

    class OffState : SwitchState
    {
        public override void On(Switch s)
        {
            s.SetState(s.GetState("on"));
            Console.WriteLine("开关打开.");
        }

        public override void Off(Switch s)
        {
            Console.WriteLine("开关已经关闭.");
        }
    }
}
