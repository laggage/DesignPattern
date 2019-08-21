namespace FactoryMethodPattern.ImageReader
{
    public interface IImageReaderFactory
    {
        IImageReader GetImageReader();
    }

    public class GifReaderFactory: IImageReaderFactory
    {
        public IImageReader GetImageReader()
        {
            return new GifReader();
        }
    }

    public class JPGReaderFactory: IImageReaderFactory
    {
        public IImageReader GetImageReader()
        {
            return new JPGReader();
        }
    }

    public class BMPReaderFactory:IImageReaderFactory
    {
        public IImageReader GetImageReader()
        {
            return new BMPReader();
        }
    }
}
