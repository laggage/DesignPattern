namespace FactoryMethodPattern
{
    using System;
    using FactoryMethodPattern.ImageReader;
    using FactoryMethodPattern.Logger;

    class Program
    {
        static void Main(string[] args)
        {
            ILoggerFactory fileLoggerFactory = new FileLoggerFactory();
            ILoggerFactory databaseLoggerFactory = new DatabaseLoggerFactory(); //针对抽象工厂接口编程
            ILogger fileLogger = fileLoggerFactory.CreateLogger();
            ILogger databaseLogger = databaseLoggerFactory.CreateLogger();
            fileLogger.Log();
            databaseLogger.Log();

            IImageReaderFactory gifReaderFactory = new GifReaderFactory();
            IImageReaderFactory jpgReaderFactory = new JPGReaderFactory();
            IImageReaderFactory bmpReaderFactory = new BMPReaderFactory();
            IImageReader gifReader = gifReaderFactory.GetImageReader();
            IImageReader jpgReader = jpgReaderFactory.GetImageReader();
            IImageReader bmpReader = bmpReaderFactory.GetImageReader();
            gifReader.Load(@"E:\Media\Images\壁纸\ (1).jpg");
            jpgReader.Load(@"E:\Media\Images\壁纸\ (1).jpg");
            bmpReader.Load(@"E:\Media\Images\壁纸\ (1).jpg");

            Console.ReadKey();
        }
    }
}
