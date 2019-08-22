namespace CompositePattern.AntiVirus
{
    using System;
    using System.Collections.Generic;

    public abstract class AbstractFile
    {
        public string Name { get; }

        protected AbstractFile(string name)
        {
            Name = name;
        }

        public abstract void Add(AbstractFile c);
        public abstract void Remove(AbstractFile c);
        public abstract AbstractFile GetChild(int i);
        public abstract void KillVirus();
    }

    public class Folder : AbstractFile
    {
        public readonly List<AbstractFile> _fileList;

        public Folder(string name):base(name)
        {
            _fileList = new List<AbstractFile>();
        }

        public override void Add(AbstractFile c)
        {
            _fileList?.Add(c);
        }

        public override void Remove(AbstractFile c)
        {
            _fileList?.Remove(c);
        }

        public override AbstractFile GetChild(int i)
        {
            return _fileList[i];
        }

        public override void KillVirus()
        {
            Console.WriteLine("********** Kill virus in folder {0} **********", Name);
            foreach (AbstractFile file in _fileList)
                file.KillVirus();
            Console.WriteLine("********** Finished kill virus in folder {0} **********", Name);
        }
    }

    public class ImageFile : AbstractFile
    {
        public ImageFile(string name):base(name)
        {
        }

        public override void Add(AbstractFile c)
        {
            throw new NotImplementedException("Can not invoke this method. Because it is a leaf. ");
        }
        public override void Remove(AbstractFile c)
        {
            throw new NotImplementedException("Can not invoke this method. Because it is a leaf. ");
        }
        public override AbstractFile GetChild(int i)
        {
            throw new NotImplementedException("Can not invoke this method. Because it is a leaf. ");
        }
        public override void KillVirus()
        {
            Console.WriteLine("<========== Kill image file {0} virus ==========>",Name);
        }
    }

    public class TextFile : AbstractFile
    {
        public TextFile(string name):base(name)
        {

        }

        public override void Add(AbstractFile c)
        {
            throw new NotImplementedException("Can not invoke this method. Because it is a leaf. ");
        }
        public override void Remove(AbstractFile c)
        {
            throw new NotImplementedException("Can not invoke this method. Because it is a leaf. ");
        }
        public override AbstractFile GetChild(int i)
        {
            throw new NotImplementedException("Can not invoke this method. Because it is a leaf. ");
        }
        public override void KillVirus()
        {
            Console.WriteLine("<========== Kill text file {0} virus ==========>", Name);
        }
    }

    public class VideoFile : AbstractFile
    {
        public VideoFile(string name):base(name)
        {
        }

        public override void Add(AbstractFile c)
        {
            throw new NotImplementedException("Can not invoke this method. Because it is a leaf. ");
        }
        public override void Remove(AbstractFile c)
        {
            throw new NotImplementedException("Can not invoke this method. Because it is a leaf. ");
        }
        public override AbstractFile GetChild(int i)
        {
            throw new NotImplementedException("Can not invoke this method. Because it is a leaf. ");
        }
        public override void KillVirus()
        {
            Console.WriteLine("<========== Kill video file {0} virus ==========>",Name);
        }
    }
}
