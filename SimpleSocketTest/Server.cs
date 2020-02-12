using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocketTest
{
    public class Server
    {

        public void Start()
        {

            //Opretter forbindelse til lokal Ip adresse og opretter en serversocket på given port
            IPAddress localIpAddress = IPAddress.Parse("192.168.24.123");
            TcpListener serverSocket = new TcpListener(localIpAddress, 9999);


            //Starter server
            serverSocket.Start();
            Console.WriteLine("Server started");

            

            


            while (true)
            {
                //Her skaber vi en connection til vores tcpclient(s)
                TcpClient serverClient = serverSocket.AcceptTcpClient();
                Console.WriteLine("Client " + serverClient.Client.RemoteEndPoint + " connected");
                Task.Run(()=>
                {
                    TcpClient tempSocket = serverClient;
                    DoClient(serverClient);
                });
            }

            ////Her skaber vi forbindelse til clientstream så vi kan skrive og læse client/server input og output
            //NetworkStream ns = serverClient.GetStream();

            //StreamReader sr = new StreamReader(ns);
            //StreamWriter sw = new StreamWriter(ns);
            //sw.AutoFlush = true;


            ////Her sender vi beskeeder mellem client og server.
            //string message = sr.ReadLine();
            //string answer = "";

            //while (message != null && message != "")
            //{
            //    Console.WriteLine("Client: " + message);
            //    answer = message.ToUpper();
            //    sw.WriteLine("Server: " + answer);
            //    message = sr.ReadLine();

            //}

            ////Her lukker vi forbindelsen til henholdsvis vores NetworkStream, Vores client og til sidst vores server.
            //ns.Close();
            //serverClient.Close();
            serverSocket.Stop();
        }

        public void DoClient(TcpClient socket)
        {

            NetworkStream ns = socket.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            //sw.WriteLine("Idiot");

            string message = sr.ReadLine();
            string answer = "";

            while (message != null || message != "")
            {
                Console.WriteLine("Client: " + socket.Client.RemoteEndPoint + " " + message);
                answer = message.ToUpper();
                sw.WriteLine("ECHO: " + answer);
                message = sr.ReadLine();

            }
            ns.Close();

        }
    }
}
