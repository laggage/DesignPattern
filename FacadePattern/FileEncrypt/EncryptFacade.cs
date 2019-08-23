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
        public virtual string Encrypt(string text)
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
