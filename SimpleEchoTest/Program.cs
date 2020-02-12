using System;

namespace SimpleEchoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c1 = new Client();
            c1.Start();

            Console.ReadKey();
        }
    }
}
