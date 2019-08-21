namespace FactoryMethodPattern.ImageReader
{
    using System;
    using System.IO;

    public interface IImageReader
    {
        void Load(string path);
    }

    public class GifReader : IImageReader
    {
        public void Load(string path)
        {
            if (File.Exists(path))
                Console.WriteLine("Load Gif from \"{0}\". ", path);
            else
                Console.WriteLine("Gif file \"{0}\" not exist. ", path);
        }
    }

    public class JPGReader : IImageReader
    {
        public void Load(string path)
        {
            if (File.Exists(path))
                Console.WriteLine("Load JPG from \"{0}\". ", path);
            else
                Console.WriteLine("JPG file \"{0}\" not exist. ", path);
        }
    }

    public class BMPReader : IImageReader
    {
        public void Load(string path)
        {
            if (File.Exists(path))
                Console.WriteLine("Load BMP from \"{0}\". ", path);
            else
                Console.WriteLine("BMP file \"{0}\" not exist. ", path);
        }
    }
}
