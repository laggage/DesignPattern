namespace SimpleFactoryPattern
{
    using System;
    using SimpleFactoryPattern.Shape;

    class Program
    {
        static void Main(string[] args)
        {
            Person man = Nvwa.CreatePerson(Sex.Man);
            Person woman = Nvwa.CreatePerson(Sex.Woman);
            Person houyi = Nvwa.CreatePerson("后裔", Sex.Man);
            Person kuafu = Nvwa.CreatePerson("夸父", Sex.Man);

            Console.WriteLine(man);
            Console.WriteLine(woman);
            Console.WriteLine(houyi);
            Console.WriteLine(kuafu);

            Shape.Shape circle = ShapeFactory.CreateShape("circle");
            Shape.Shape triangle = ShapeFactory.CreateShape("triangle");
            Console.WriteLine(circle);
            Console.WriteLine(triangle);
            Console.ReadKey();
        }
    }
}
