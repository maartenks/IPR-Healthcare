﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClientServerDemo
{
    class Server
    {
        private TcpClient tcpClient;
        private Program program;
        private NetworkStream stream;

        private byte[] buffer = new byte[1024];

        string totalBuffer = "";

        public string login { get; set; }

        public Server(TcpClient tcpClient, Program program)
        {
            this.tcpClient = tcpClient;
            this.program = program;

            this.stream = tcpClient.GetStream();
            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
        }

        private void OnRead(IAsyncResult ar)
        {
            Console.WriteLine("got data");
            int receivedBytes = stream.EndRead(ar);
            totalBuffer += System.Text.Encoding.ASCII.GetString(buffer, 0, receivedBytes);

            while (totalBuffer.Contains("\r\n\r\n"))
            {
                string packet = totalBuffer.Substring(0, totalBuffer.IndexOf("\r\n\r\n"));
                totalBuffer = totalBuffer.Substring(totalBuffer.IndexOf("\r\n\r\n") + 4);

                string[] data = Regex.Split(packet, "\r\n");
                handlePacket(data);
            }

            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);

        }

        private void handlePacket(string[] data)
        {
            switch (data[0])
            {
                case "login":
                    this.login = data[1];
                    break;
                case "hart":
                    Console.WriteLine(data[1]);
                    break;
                case "bike":
                    Console.WriteLine(data[1]);
                    break;
                case "patient":
                    Console.WriteLine("Naam: " + data[1] + "\r\nGeslacht: " + data[2] + "\r\nLeeftijd: " + data[3] + "\r\nFietsID: " + data[4]);
                    break;
                default:
                    Write("Dat snap ik niet\r\n\r\n");
                    Console.WriteLine("Unknown packet");
                    break;
            }
        }

        public void Write(string v)
        {
            stream.Write(System.Text.Encoding.ASCII.GetBytes(v), 0, v.Length);
            stream.Flush();
        }
    }
}
