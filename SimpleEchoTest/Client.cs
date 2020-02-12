using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SimpleEchoTest
{
    public class Client
    {
        public void Start()
        {
            Console.WriteLine("Waiting for server");
            TcpClient client = new TcpClient("192.168.24.224", 1904);
            

            NetworkStream ns = client.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            Console.WriteLine("Connected to server " + client.Client.RemoteEndPoint);


            //sw.WriteLine("Timm Connected");

            string message = "";

            while (message != null || message != "")
            {
                message = Console.ReadLine();
                if (message == "stop") break;
                sw.WriteLine(message);
               Console.WriteLine(sr.ReadLine());
            }
            ns.Close();
            client.Close();

        }
    }
}
