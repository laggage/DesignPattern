namespace CompositePattern
{
    using System;
    using CompositePattern.AntiVirus;

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            AbstractFile folder = new Folder("娱乐");
            AbstractFile imageFile = new ImageFile("beauty.bmp");
            AbstractFile videoFile = new VideoFile("黑衣人.rmvb");
            AbstractFile textFile = new TextFile("day.txt");
            AbstractFile imageFile1 = new ImageFile("girl.jpg");

            folder.Add(imageFile);
            folder.Add(videoFile);
            folder.Add(textFile);

            folder.KillVirus();

            imageFile1.KillVirus();

            Console.ReadKey();
        }
    }
}
