namespace SimpleFactoryPattern
{
    public enum Sex
    {
        Woman,
        Man
    }

    public abstract class Person
    {
        public string Name
        {
            get;
            set;
        } = "无名氏";

        public virtual Sex Sex { get; }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Sex, Name);
        }
    }

    public class Woman : Person
    {
        public override Sex Sex => Sex.Woman;
    }

    public class Man : Person
    {
        public override Sex Sex => Sex.Man;
    }
}