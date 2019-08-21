namespace BuilderPattern
{
    using System;
    using BuilderPattern.DrawPerson;

    class Program
    {
        static void Main(string[] args)
        {
            ThinPersonBuilder thinPersonBuilder = new ThinPersonBuilder(null,null);
            FatPersonBuilder fatPersonBuilder = new FatPersonBuilder(null, null);
            PersonDirector director = new PersonDirector(fatPersonBuilder);
            Console.WriteLine("<============== Build fat person ==============>");
            director.CreatePerson();
            Console.WriteLine("<============== Build fat person ==============>");

            Console.WriteLine();
            director = new PersonDirector(thinPersonBuilder);
            Console.WriteLine("<============== Build thin person ==============>");
            director.CreatePerson();
            Console.WriteLine("<============== Build thin person ==============>");

            Console.ReadKey();
        }
    }
}
