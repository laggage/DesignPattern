using System;

namespace StatePattern.Sample.Player
{
    public class Media
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime CreateDate { get; set; }
        public TimeSpan Duration { get; set; }


        public Media(string name, string author): this(name, author, DateTime.Now, new TimeSpan(0))
        {
        }

        public Media(string name, string author, DateTime createDate, TimeSpan duration)
        {
            Name = name;
            Author = author;
            CreateDate = createDate;
            Duration = duration;
        }
    }
}
