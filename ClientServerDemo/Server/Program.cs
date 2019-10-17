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
        public List<Patient> patients = new List<Patient>();
        static void Main(string[] args)
        {
            //JsonHandler json = new JsonHandler();
            
           


            new Program();
        }
        public static async Task<List<Patient>> LoadClients()
        {
            // Ik ga er hiervan uit dat de data in de clientData.json alleen bestaat uit een json array (JArray) met client objecten.
            // In de file staat een voorbeeldje.
            return await JsonHandler.LoadObject<List<Patient>>("PatientData.json");
        }

        public void ToevoegenAsync(List<Patient> patients)
        {
            //List<Patient> patients = await LoadClients();
            //List<object> list = clientCollection.clients.ToList<object>();
            //list.Add(client);
            Console.WriteLine("hey");
            patients.ToArray();
            string output = JsonConvert.SerializeObject(patients);
            JsonHandler.SaveFile("PatientData.json", output);
        }

        public static void delete()
        {
            //List<Patient> patients = await LoadClients();
            //List<object> list = clientCollection.clients.ToList<object>();
            //list.Add(client);
            //patients.ToArray();
            //string output = JsonConvert.SerializeObject(patients);
            JsonHandler.DeleteFile("PatientData.json"); 
        }




        TcpListener listener;
        private List<Server> servers = new List<Server>();
        Program()
        {
            // make a host and start host
            //var mytask = LoadClients();
           // patients = mytask.Result;
           
            //delete();
            listener = new TcpListener(IPAddress.Any, 80);
            listener.Start();

            // begin accepting clients to connect to server
            listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
            Console.ReadKey();
        }

        public void save(List<Patient> patients)
        {
            Console.WriteLine("hello");
            foreach(Patient now in patients) {
                foreach(Patient then in this.patients)
                {
                    if (now.Name.Equals(then.Name))
                    {
                        foreach(History history in now.histories)
                        {
                            if (!then.histories.Contains(history))
                            {
                                then.histories.Add(history);
                            }
                        }
                    }
                    else
                    {
                        this.patients.Add(now);
                    }
                }
            }
            this.patients.Add(new Patient("lili", 5, "male", 65, "5"));
            ToevoegenAsync(this.patients); 

        }
        // accept new clients, add these to list and keep waiting for other clients
        private void OnConnect(IAsyncResult ar)
        {
            var newTcpClient = listener.EndAcceptTcpClient(ar);
            Console.WriteLine("New client connected");
            servers.Add(new Server(newTcpClient, this));

            listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
        }


        public void WriteDoctor(string name, string v)
        {
            foreach (Server s in servers)
            {
                s.Write($"patientData\r\n{name}\r\n{s}\r\n\r\n");
            }
        }

        public void SendMessage(Server client, string v)
        {
            client.Write($"Resistance\r\n{v}\r\n\r\n");

        }
    }
}
