# 外观模式(FacadePattern)

## 需求
软件开发中, 为了完成一个复杂的功能, 一个客户类需要和多个业务类交互, 而这些交互的业务类经常会作为一个整体出现, 由于涉及到较多的类, 导致使用时代码较复杂, 此时需要一个类似服务员一样的角色, 由它负责和多个业务类进行交互.

## 定义
为子系统中的一组接口提供统一的入口. 外观模式定义了一个高层接口, 这个接口使得一个子系统更加容易使用.

## 结构
1. 外观角色
2. 子系统角色

![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190823113646710-1554479973.png)

```
namespace FacadePattern.BaseImplement
{
    class Facade
    {
        public void Method()
        { }
    }

    class SubSystemA
    {
        public void MethodA() { }
    }

    class SubSystemB
    {
        public void MethodB() { }
    }

    class SubSystemC
    {
        public void MethodC() { }
    }
}
```

## 应用实例
> 文件加密模块, 该模块对文件中的数据进行加密, 并将加密后的数据> 存储到新的文件中. 具体流程包括3个部分, 分别是读取源文件, 加> 密, 保存加密之后的文件.

### 实现

![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190823114449348-1008032689.png)


```
namespace FacadePattern.FileEncrypt
{
    using System;
    using System.IO;
    using System.Text;

    class EncryptFacade
    {
        private FileReader _reader;
        private FileWriter _writer;
        private CipherMachine _cipherMachine;

        public EncryptFacade()
        {
            _reader = new FileReader();
            _writer = new FileWriter();
            _cipherMachine = new CipherMachine();
        }

        public EncryptFacade(FileReader reader, FileWriter writer, CipherMachine cipherMachine)
        {
            _reader = reader;
            _writer = writer;
            _cipherMachine = cipherMachine;
        }

        public void EncryptFile(string filePath)
        {
            string text = _reader.Read(filePath);
            text = _cipherMachine.Encrypt(text);
            
            _writer.Write(Path.GetFileNameWithoutExtension(filePath)+"_encrypted.txt", text);
            Console.WriteLine("Encrypt successed. Encrypted Content:{0}",text);
        }
    }

    class FileReader
    {
        public string Read(string filePath)
        {
            FileStream fs = null;
            StringBuilder sb = new StringBuilder();
            byte[] readBuf = new byte[10];
            try
            {
                int count = 11;
                fs = new FileStream(filePath, FileMode.OpenOrCreate);
                
                while (count >= readBuf.Length)
                {
                    Array.Clear(readBuf, 0, readBuf.Length);
                    try
                    {
                        count = fs.Read(readBuf, 0, readBuf.Length);
                        sb.Append(Encoding.Default.GetString(readBuf));
                        
                    }
                    catch
                    {
                        continue;
                    }
                }
                sb.Replace("\0", string.Empty);
                return sb.ToString();
            }
            finally
            {
                fs.Close();
                fs.Dispose();
            }
        }
    }

    class FileWriter
    {
        public void Write(string filePath,string content)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filePath, FileMode.OpenOrCreate);
                fs.Write(Encoding.Default.GetBytes(content));
            }
            finally
            {
                fs.Close();
                fs.Dispose();
            }
        }
    }

    class CipherMachine
    {
        public string Encrypt(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var c in text)
            {
                sb.Append(c % 7);
            }
            return sb.ToString();
        }
    }
}
```

## 抽象外观类
标准的外观模式结构图中, 如果需要增加, 删除或更换与外观类交互的子系统, 必须修改外观类或客户端的源代码, 这将违背开闭原则.
可以通过引入抽象外观类进行编程, 对于新的业务需求, 不需要修改原有外观类, 而对应增加一个新的具体的外观类

对于上面的 **文件加密模块** 更换一个加密类, 不使用原有的求模加密, 改为基于移位运算的新加密类 `ShiftCipherMachine`, 

![](https://img2018.cnblogs.com/blog/1596066/201908/1596066-20190823121727408-1349922954.png)


```
namespace FacadePattern.FileEncrypt.AbstractFacade
{
    using System;
    using System.IO;
    using System.Text;

    abstract class AbstractEncryptFacade
    {
        public abstract void EncryptFile(string filePath);
    }

    /// <summary>
    /// 求模加密
    /// </summary>
    class ModEncryptFacade: AbstractEncryptFacade
    {
        private FileReader _reader;
        private FileWriter _writer;
        private CipherMachine _cipherMachine;

        public ModEncryptFacade()
        {
            _reader = new FileReader();
            _writer = new FileWriter();
            _cipherMachine = new CipherMachine();
        }

        public override void EncryptFile(string filePath)
        {
            string text = _reader.Read(filePath);
            text = _cipherMachine.Encrypt(text);

            _writer.Write(Path.GetFileNameWithoutExtension(filePath) + "_encrypted.txt", text);
            Console.WriteLine("Encrypt successed. Encrypted Content:{0}", text);
        }
    }

    /// <summary>
    /// 移位加密
    /// </summary>
    class ShiftEncryptFacade:AbstractEncryptFacade
    {
        private FileReader _reader;
        private FileWriter _writer;
        private CipherMachine _cipherMachine;

        public ShiftEncryptFacade()
        {
            _reader = new FileReader();
            _writer = new FileWriter();
            _cipherMachine = new ShiftCipherMachine(); //使用移位加密类
        }

        public override void EncryptFile(string filePath)
        {
            string text = _reader.Read(filePath);
            text = _cipherMachine.Encrypt(text);

            _writer.Write(Path.GetFileNameWithoutExtension(filePath) + "_encrypted.txt", text);
            Console.WriteLine("Encrypt successed. Encrypted Content:{0}", text);
        }
    }

    class ShiftCipherMachine:CipherMachine
    {
        public override string Encrypt(string text)
        {
            StringBuilder sb = new StringBuilder();
            int key = 3;
            foreach(var c in text)
            {
                sb.Append(c >> key);
            }
            return base.Encrypt(text);
        }
    }
}
```
