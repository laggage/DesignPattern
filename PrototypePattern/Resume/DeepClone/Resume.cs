namespace PrototypePattern.Resume.DeepClone
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    [Serializable]
    public class WorkExperience:ICloneable
    {
        public string Company { get; set; }
        public string TimeArea { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    [Serializable]
    public class Resume : ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }

        public WorkExperience WorkExperience { get; set; }

        //public object Clone()
        //{
        //    Resume clone = null;

        //    Stream ms = new MemoryStream(100);
        //    BinaryFormatter matter = new BinaryFormatter();

        //    try
        //    {
        //        matter.Serialize(ms, this);
        //        ms.Position = 0;
        //        clone = matter.Deserialize(ms) as Resume;
        //    }
        //    finally
        //    {
        //        ms.Close();
        //        ms.Dispose();
        //    }

        //    return clone;
        //}

        public void Display()
        {
            Console.WriteLine(
                "{0},{1}岁,{2};工作经历:{3},{4}", 
                Name, Age, Sex, WorkExperience.TimeArea, WorkExperience.Company);
        }

        public object Clone()
        {
            Resume clone = this.MemberwiseClone() as Resume;
            clone.WorkExperience = this.WorkExperience.Clone() as WorkExperience;
            return clone;
        }
    }
}
