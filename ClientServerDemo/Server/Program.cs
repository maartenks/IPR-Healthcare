using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Doctor;
using Server.IO;

namespace ClientServerDemo
{
    class Program
    {
        public List<Patient> patients_ = new List<Patient>();
        private object sync = new object();
        public List<Patient> patients
        {
            get { lock (sync) { return patients_; } }
            set { lock (sync) { patients_ = value; } }
        }
        static void Main(string[] args)
        {
            new Program();
        }
        public async Task<List<Patient>> LoadClients()
        {
            return await JsonHandler.LoadObject<List<Patient>>("Data.json");
        }

        public void ToevoegenAsync(List<Patient> patients)
        {
            Console.WriteLine("hey");
            patients.ToArray();
            string output = JsonConvert.SerializeObject(patients);
            JsonHandler.SaveFile("Data.json", output);
        }

        public static void delete()
        {
            JsonHandler.DeleteFile("Data.json"); 
        }




        TcpListener listener;
        private List<Server> servers = new List<Server>();
        Program()
        {
            LoadPatients();
            listener = new TcpListener(IPAddress.Any, 80);
            listener.Start();

            listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
            Console.ReadKey();
        }

        private async void LoadPatients()
        {
            this.patients = await LoadClients();
            done = true; 
        }

        public bool done { get; set; }

        public void deleteddata(string filename)
        {
            string saveFolder = Directory.GetCurrentDirectory();
            string savePath = Path.Combine(saveFolder, filename);
            StreamWriter strm = File.CreateText(savePath);
            strm.Flush();
            strm.Close();
        }

        public void save(List<Patient> patients)
        {
            deleteddata("Data.json"); 
            Console.WriteLine(patients.Count + "gaaaaaaaaaaaaaaaaaaaa");
            Console.WriteLine("hello");
            List<Patient> list = new List<Patient>();
            lock (sync)
            {
                foreach (Patient i in this.patients)
                {
                    list.Add(i);
                }
            }

            foreach (Patient now in patients)
            {
                int i = 0;
                Patient b = this.patients.Find(x => x.Name == now.Name); 
                if (b != null)
                {
                    History history = new History();
                    history.workload = now.workload;
                    history.heartbeat = now.heartbeat;
                    history.maxheartbeat = now.maxheartbeat;
                    int index = list.IndexOf(b);
                    Console.WriteLine(index + " index");
                    Console.WriteLine(list.Count + " length");
                    list[index].histories.Add(history);
                }
                else
                {
                    list.Add(now);
                    History history = new History();
                    history.workload = now.workload;
                    history.heartbeat = now.heartbeat;
                    history.maxheartbeat = now.maxheartbeat;
                    list.Last().histories.Add(history);
                }
                    i++;
                
            }
            ToevoegenAsync(list);
            lock (sync)
            {
                this.patients = list;
            }
            WriteDoctor();
            done = true; 
            


        }
        private void OnConnect(IAsyncResult ar)
        {
            var newTcpClient = listener.EndAcceptTcpClient(ar);
            Console.WriteLine("New client connected");
            servers.Add(new Server(newTcpClient, this));

            listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
        }
        

        public void WriteDoctor()
        {
            foreach (Server s in servers)
            {
                string json = JsonConvert.SerializeObject(this.patients); 
                s.Write($"patientData\r\n"+ json + "\r\n\r\n");
            }
        }

        public void SendMessage(Server client, string v)
        {
            client.Write($"Resistance\r\n{v}\r\n\r\n");

        }
    }
}
