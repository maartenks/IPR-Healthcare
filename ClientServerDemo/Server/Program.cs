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
            //JsonHandler json = new JsonHandler();
            
           


            new Program();
        }
        public async Task<List<Patient>> LoadClients()
        {
            // Ik ga er hiervan uit dat de data in de clientData.json alleen bestaat uit een json array (JArray) met client objecten.
            // In de file staat een voorbeeldje.
            return await JsonHandler.LoadObject<List<Patient>>("Data.json");
        }

        public void ToevoegenAsync(List<Patient> patients)
        {
            //List<Patient> patients = await LoadClients();
            //List<object> list = clientCollection.clients.ToList<object>();
            //list.Add(client);
            Console.WriteLine("hey");
            patients.ToArray();
            string output = JsonConvert.SerializeObject(patients);
            JsonHandler.SaveFile("Data.json", output);
        }

        public static void delete()
        {
            //List<Patient> patients = await LoadClients();
            //List<object> list = clientCollection.clients.ToList<object>();
            //list.Add(client);
            //patients.ToArray();
            //string output = JsonConvert.SerializeObject(patients);
            JsonHandler.DeleteFile("Data.json"); 
        }




        TcpListener listener;
        private List<Server> servers = new List<Server>();
        Program()
        {
            // make a host and start host
            //var mytask = LoadClients();
            // patients = mytask.Result;

            //delete();
            LoadPatients();
            listener = new TcpListener(IPAddress.Any, 80);
            listener.Start();

            // begin accepting clients to connect to server
            listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
            Console.ReadKey();
        }

        private async void LoadPatients()
        {
            this.patients = await LoadClients();
            done = true; 
            //this.patients.Add(new Patient("lala", 3, "Vrouw", 65, "ta")); 
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
            //delete(); 
            deleteddata("Data.json"); 
            Console.WriteLine(patients.Count + "gaaaaaaaaaaaaaaaaaaaa");
            Console.WriteLine("hello");
            List<Patient> list = new List<Patient>();
            //list = this.patients;
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
                /*foreach (Patient then in this.patients)
                {
                    Console.WriteLine(now.Name);
                    Console.WriteLine(then.Name);
                    if (now.Name.Equals(then.Name))
                    {
                        /*foreach (History history in then.histories)
                        {
                            if (!then.histories.Contains(history))
                            {
                                list[i].histories.Add(history);
                                then.histories.Add(history);
                            }
                        }*/
                       /* History history = new History();
                        history.workload = then.workload;
                        history.heartbeat = then.heartbeat;
                        history.maxheartbeat = then.maxheartbeat;
                        list[i].histories.Add(history); 
                        Console.WriteLine("boooooooooooooooooo");
                    }
                    else
                    {
                        list.Add(now);
                        History history = new History();
                        history.workload = now.workload;
                        history.heartbeat = now.heartbeat;
                        history.maxheartbeat = now.maxheartbeat;
                        list.Last().histories.Add(history); 
                        Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaa");
                    }*/
                    i++;
                
            }
            //this.patients.Add(new Patient("lili", 5, "male", 65, "5"));
            ToevoegenAsync(list);
            lock (sync)
            {
                this.patients = list;
            }
            WriteDoctor();
            done = true; 
            


        }
        // accept new clients, add these to list and keep waiting for other clients
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
