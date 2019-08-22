# 桥接模式(Bridge Pattern)

## 定义
将抽象部分与它的实现部分解耦, 使得两者都能够独立的变化.

## 概述
桥接模式中, 将两个独立变化的维度设计为两个独立的继承等级结构, 而不是将两者耦合在一起形成多层继承结构.
桥接模式在抽象层建立起了抽象关联, 该关联关系类似一条连接两个独立继承结构的桥, 故名桥接模式;

## 结构

1. **抽象类(Abstraction)**
2. **扩充抽象类(RefinedAbstraction)**
3. **实现类接口(Implementor)**
4. **具体实现类(ConcreteImplementor)**

![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190822161319560-1934734059.png)

```
namespace BridgePattern.Implement
{
    using System;

    interface IImplementor
    {
        void OperationImpl();
    }

    class ConcreteImplementorA:IImplementor
    {
        public void OperationImpl()
        {
            Console.WriteLine("ConcreteImplementorA implement operation. ");
            //throw new NotImplementedException();
        }
    }

    class ConcreteImplementorB : IImplementor
    {
        public void OperationImpl()
        {
            Console.WriteLine("ConcreteImplementorB implement operation. ");
        }
    }

    abstract class Abstraction
    {
        protected IImplementor _impl;

        public void SetImpl(IImplementor impl)
        {
            _impl = impl;
        }

        public abstract void Operation();
    }

    class RefinedAbstration : Abstraction
    {
        public override void Operation()
        {
            _impl.OperationImpl();
        }
    }
    
    /// <summary>
    /// 客户端, 桥接模式下, 客户端可以针对两个维度的抽象层编程, 在程序运行时动态的缺点两个维度的子类
    /// 动态的组合对象, 将两个独立的变化完全解耦, 以便能够灵活的扩充任一维度而对另一维度不造成任何影响.
    /// </summary>
    class BridgePatternClient
    {
        static void Run()
        {
            Abstraction abstraction = new RefinedAbstration();
            abstraction.SetImpl(new ConcreteImplementorA());
            abstraction.Operation();
        }
    }
}

```

## 应用实例

### 跨平台图像浏览系统

#### 说明
开发一个跨平台图像浏览系统, 要求该系统能够显示BMP,JPG,GIF,PNG等多种格式的文件, 并且能够在Windows, Linux,Unix等多个操作系统上运行.系统首先将各种格式的文件解析为像素矩阵(Matrix), 然后将像素矩阵显示在屏幕上, 在不同的操作系统中调用不同的绘制函数来绘制像素矩阵. 系统需要具有较好的扩展性, 以便在将来支持新的文件格式和操作系统.

#### 实现
![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190822164029353-820356964.png)

```
using System;

namespace BridgePattern.ImageBroswer
{
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
```

