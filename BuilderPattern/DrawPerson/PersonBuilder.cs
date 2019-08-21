namespace BuilderPattern.DrawPerson
{
    using System;
    using System.Drawing;

    public abstract class PersonBuilder
    {
        private readonly Graphics _graphics;
        private readonly Pen _pen;

        public PersonBuilder(Graphics graphics, Pen pen)
        {
            _pen = pen;
            _graphics = graphics;
        }

        public abstract void BuildArmLeft();
        public abstract void BuildArmRight();
        public abstract void BuildLegLeft();
        public abstract void BuildLegRight();
        public abstract void BuildHead();
        public abstract void BuildBody();
    }

    public class ThinPersonBuilder : PersonBuilder
    {
        public ThinPersonBuilder(Graphics graphics, Pen pen):base(graphics,pen)
        {
        }

        public override void BuildArmLeft()
        {
            Console.WriteLine("Left Arm");
        }

        public override void BuildArmRight()
        {
            Console.WriteLine("Right Arm");
        }

        public override void BuildLegLeft()
        {
            Console.WriteLine("Left Leg");
        }

        public override void BuildLegRight()
        {
            Console.WriteLine("Right Leg");
        }

        public override void BuildHead()
        {
            Console.WriteLine("Head");
        }

        public override void BuildBody()
        {
            Console.WriteLine("Thin body");
        }
    }

    public class FatPersonBuilder : PersonBuilder
    {
        public FatPersonBuilder(Graphics graphics, Pen pen) : base(graphics, pen)
        {
        }

        public override void BuildArmLeft()
        {
            Console.WriteLine("Left Arm");
        }

        public override void BuildArmRight()
        {
            Console.WriteLine("Right Arm");
        }

        public override void BuildLegLeft()
        {
            Console.WriteLine("Left Leg");
        }

        public override void BuildLegRight()
        {
            Console.WriteLine("Right Leg");
        }

        public override void BuildHead()
        {
            Console.WriteLine("Head");
        }

        public override void BuildBody()
        {
            Console.WriteLine("Fat body");
        }
    }  
}
