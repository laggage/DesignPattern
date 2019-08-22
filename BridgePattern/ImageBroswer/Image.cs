namespace BridgePattern.ImageBroswer
{
    using System;

    struct Matrix
    {
    }

    abstract class Image
    {
        protected Matrix _imageMatrix;
        protected IImagePainter _imagePainter;

        public Image()
        {
        }

        public Image(IImagePainter imagePainter)
        {
            _imagePainter = imagePainter;
        }

        public void SetImagePainter(IImagePainter imagePainter)
        {
            _imagePainter = imagePainter;
        }

        public abstract void Load(string fileName);

        public abstract void Show();
    }

    class GIFImage:Image
    {
        public GIFImage()
        {
        }

        public override void Show()
        {
            _imagePainter.DrawImage(_imageMatrix);
        }

        public override void Load(string fileName)
        {
            _imageMatrix = new Matrix();
        }
    }

    class BMPImage : Image
    {
        public override void Show()
        {
            _imagePainter.DrawImage(_imageMatrix);
        }

        public override void Load(string fileName)
        {
            _imageMatrix = new Matrix();
        }
    }

    class JPGImage : Image
    {
        public override void Show()
        {
            _imagePainter.DrawImage(_imageMatrix);
        }

        public override void Load(string fileName)
        {
            _imageMatrix = new Matrix();
        }
    }

    class PNGImage : Image
    {
        public override void Show()
        {
            _imagePainter.DrawImage(_imageMatrix);
        }

        public override void Load(string fileName)
        {
            _imageMatrix = new Matrix();
        }
    }

    interface IImagePainter
    {
        void DrawImage(Matrix matrix);
    }

    class WindowsImagePainter:IImagePainter
    {
        public void DrawImage(Matrix matrix)
        {
            Console.WriteLine("Draw image on windows. ");
        }
    }

    class LinuxImagePainter : IImagePainter
    {
        public void DrawImage(Matrix matrix)
        {
            Console.WriteLine("Draw image on Linux. ");
        }
    }

    class UnixImagePainter:IImagePainter
    {
        public void DrawImage(Matrix matrix)
        {
            Console.WriteLine("Draw image on Unix. ");
        }
    }

    class ImageBroswerClient
    {
        private static void Run()
        {
            Image gif = new GIFImage();
            gif.SetImagePainter(new WindowsImagePainter());
            gif.Show();
           
        }
    }
}
