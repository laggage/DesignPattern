namespace PrototypePattern.Resume
{
    using System;

    public class Resume:ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string  Sex { get; set; }


        public string Company { get; set; }
        public string TimeArea { get; set; }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }

        public void Display()
        {
            Console.WriteLine("{0},{1}岁,{2};工作经历:{3},{4}", Name, Age, Sex,TimeArea,Company);
        }
    }
}
