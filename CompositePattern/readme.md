
[TOC]

# 组合模式(Composite Pattern)

## 需求
在软件开发过程中，我们经常会遇到处理简单对象和复合对象的情况，例如对操作系统中目录的处理就是这样的一个例子，因为目录可以包括单独的文件，也可以包括文件夹，文件夹又是由文件组成的，由于简单对象和复合对象在功能上区别，导致在操作过程中必须区分简单对象和复合对象，这样就会导致客户调用带来不必要的麻烦，然而作为客户，它们希望能够始终一致地对待简单对象和复合对象。然而组合模式就是解决这样的问题。下面让我们看看组合模式是怎样解决这个问题的。

## 定义
组合多个对象形成树形结构以表示具有部分-整体关系的层次结构. 组合模式让客户端可以统一对待单个对象和组合对象.

组合模式又称 "**部分-整体**"模式, 将对象组织到树形结构中, 可以用来描述整体与部分的关系.

## 结构

1. **抽象构件(Component)**
2. **叶子构件(Leaf)**
3. **容器构件(Composite)**

![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190822230635621-795067733.png)


```
namespace CompositePattern.BaseImplement
{
    using System;
    using System.Collections.Generic;

    abstract class Component
    {
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract Component GetChild(int i);
        public abstract void Operation();
    }

    /// <summary>
    /// 叶子构件典型结构
    /// </summary>
    class Leaf:Component
    {
        public override void Add(Component c)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Component c)
        {
            throw new NotImplementedException();
        }

        public override Component GetChild(int i)
        {
            return null;
        }

        public override void Operation()
        {
           // 叶子构件具体的业务方法的实现
        }
    }

    class Composite:Component
    {
        private List<Component> _childs;

        public Composite()
        {
            _childs = new List<Component>();
        }

        public override void Add(Component c)
        {
            _childs.Add(c);
        }

        public override void Remove(Component c)
        {
            _childs.Remove(c);
        }

        public override Component GetChild(int i)
        {
            return _childs[i];
        }

        public override void Operation()
        {
            //容器构件具体业务方法的实现
            foreach(Component child in _childs)
            {
                child.Operation();
            }
        }
    }
}
```

## 应用实例
> 杀毒软件(Antivirus), 既可以对某个文件夹(Folder)杀毒,也可以对某个指定的文件(File)杀毒.

![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190823003309563-388855320.png)

```
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
```

## 透明组合模式

抽象构件(Component) 中声明了所有用于管理成员对象的方法, 包括 `Add`, `Remove`, `GetChild` 等方法. 这样做的好处是确保所有的构建类都有相同的接口.在客户端看来, 叶子对象和容器对象所提供的方法是一致的.
透明组合的缺点是不够安全, 因为叶子对象和容器对象在本质上是有区别的. 叶子对象不可能有下一个层次的对象, 即不可能包含成员对象, 因此为其提供 `Add`, `Remove`, `GetChild` 方法是没有意义的, 编译阶段不会出错, 但是如果在运行阶段调用这些方法可能会出错.

## 安全组合模式
安全组合模式中, 抽象构件(Component) 中没有声明任何用于管理成员对象的方法, 而是在Composite类中声明并实现这些方法. 这样做是安全的, 因为根本不向叶子对象提供这些管理成员对象的方法.
安全组合模式的特点是不够透明, 叶子构件和容器构件有不同的方法, 容器构件中用于管理成员对象的方法没有在抽象构件中定义, 因此客户端不能完全针对抽象编程, 必须有区别的对待叶子构件和容器构件.

