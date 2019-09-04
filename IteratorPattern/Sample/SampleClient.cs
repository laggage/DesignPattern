namespace IteratorPattern.Sample
{
    using System;
    using System.Collections.Generic;

    class SampleClient
    {
        public static void Run()
        {
            Console.WriteLine("自己实现的iterator: ");
            Execute();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("\r\nDotnet中实现好的iterator: ");
            Execute2();
        }


        static void Execute()
        {
            // 自己实现的iterator
            ProductList productList = new ProductList();
            productList.AddObject("建造者模式");
            productList.AddObject("工厂方法模式");
            productList.AddObject("职责链模式");
            productList.AddObject("抽象工厂模式");
            productList.AddObject("解释器模式");
            IIterator iterator = productList.CreateIterator();
            while (iterator.GetNextItem() is string item)
            {
                iterator.MoveToNext();
                Console.WriteLine(item);
            }
        }

        static void Execute2()
        {
            // Dotnet中实现好的iterator
            IList<string> designPatterns =
                new List<string>
                {
                    "建造者模式",
                    "工厂方法模式",
                    "职责链模式",
                    "抽象工厂模式",
                    "解释器模式",
                };

            IEnumerator<string> enumerator = designPatterns.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
    }
}
