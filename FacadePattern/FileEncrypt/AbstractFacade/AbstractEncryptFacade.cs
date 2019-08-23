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
