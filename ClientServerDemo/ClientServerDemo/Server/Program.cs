using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Server;
using Newtonsoft.Json;
using System.Windows.Forms;
using Doctor;

namespace ClientServerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            new Program();
        }


        public List<Patient> patients = new List<Patient>(); 
        TcpListener listener;
        private List<Server> servers = new List<Server>();
        Program()
        {
            // make a host and start host
            listener = new TcpListener(IPAddress.Any, 80);
            listener.Start();

            // begin accepting clients to connect to server
            listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
            Console.ReadKey();
        }

        // accept new clients, add these to list and keep waiting for other clients
        private void OnConnect(IAsyncResult ar)
        {
            var newTcpClient = listener.EndAcceptTcpClient(ar);
            Console.WriteLine("New client connected");
            servers.Add(new Server(newTcpClient, this));

            listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
        }



        public void SendMessage(Server client, string v)
        {
            client.Write($"Resistance\r\n{v}\r\n\r\n");

        }
    }
}
