namespace FacadePattern
{
    using System;
    using FacadePattern.FileEncrypt;
    using FacadePattern.FileEncrypt.AbstractFacade;

    class Program
    {
        static void Main(string[] args)
        {
            //EncryptFacade encrypt = new EncryptFacade();
            //encrypt.EncryptFile("./passwd.txt");

            AbstractEncryptFacade shiftEncrypt = new ShiftEncryptFacade();
            shiftEncrypt.EncryptFile("./passwd.txt");

            Console.ReadKey();
        }
    }
}
