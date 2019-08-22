namespace PrototypePattern
{
    using System;
    using System.IO;
    using PrototypePattern.Resume.DeepClone;

    class Program
    {
        static void Main(string[] args)
        {
            var r = new Resume.DeepClone.Resume
            {
                Name = "陈畏民",
                Age = 20,
                Sex = "男",
                WorkExperience = new WorkExperience
                {
                    Company = "腾讯",
                    TimeArea = "2000-2005"
                }
            };

            var r1 = r.Clone() as Resume.DeepClone.Resume;
            var r2 = r.Clone() as Resume.DeepClone.Resume;

            r1.Name = "陈翔";
            r2.WorkExperience.Company = "阿里巴巴";
            r2.WorkExperience.TimeArea = "2005-2012";

            r.Display();
            r1.Display();
            r2.Display();
            //Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
