namespace SimpleFactoryPattern
{
    using System;

    public class Nvwa
    {
        public static Person CreatePerson(Sex sex)
        {
            switch (sex)
            {
                case Sex.Woman:
                    return new Woman();
                case Sex.Man:
                    return new Man();
                default:
                    throw new NotImplementedException();
            }
        }

        public static Person CreatePerson(string Name ,Sex sex)
        {
            Person p = CreatePerson(sex);
            if (p != null) p.Name = Name;
            return p;
        }
    }
}