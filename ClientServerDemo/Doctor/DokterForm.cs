using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Doctor
{
    public partial class DokterForm : Form
    {
        private FlowLayoutPanel panel;
        private List<Patient> selectedPatients;
        private List<Patient> availablePatients;
        private TcpClient client;
        private static byte[] buffer = new byte[1024];
        private int port;
        private static NetworkStream stream;
        static string totalBuffer = "";
        private List<Patient> patients = new List<Patient>();

        private String broadcastMessage { get; set; }

        public DokterForm()
        {
            InitializeComponent();
            
            this.port = 80; 
            selectedPatients = new List<Patient>();
            availablePatients = new List<Patient>();
            //this.patients.Add(new Patient("lili", 5 , "male", 65, "5"));
            ConnectServer();

            // testDataAvailablePatients();
            PatientsInList(); 


        }

        public void PatientsInList()
        {
            availableListBox.Items.Clear();
            foreach (Patient now in patients)
            {

                availableListBox.Items.Add(now.Name);
                
            }
        }

        private void ConnectServer()
        {
            client = new TcpClient();
            client.Connect("localhost", this.port);

            stream = client.GetStream();
            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);

        }

        private void OnRead(IAsyncResult ar)
        {
            //message received
            Console.WriteLine("got data");
            int receivedBytes = stream.EndRead(ar);
            totalBuffer += System.Text.Encoding.ASCII.GetString(buffer, 0, receivedBytes);

            // from bytes to string
            while (totalBuffer.Contains("\r\n\r\n"))
            {
                string packet = totalBuffer.Substring(0, totalBuffer.IndexOf("\r\n\r\n"));
                totalBuffer = totalBuffer.Substring(totalBuffer.IndexOf("\r\n\r\n") + 4);

                string[] data = Regex.Split(packet, "\r\n");
                handlePacket(data);
            }

            // begin waiting for next 
            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);


        }

        private void writechart(History patient, Patient now)
        { int i = 0;
            foreach (double hearbeat in patient.heartbeat)
            {
                chart1.Series["VO2Now"].Points.AddXY(i, calculateVo2(patient.workload[i], hearbeat, now) );
                i++;
                    
            }
            
        }
        private void handlePacket(string[] data)
        {
            switch (data[0])
            {
                case "login":
                    Console.WriteLine($"Je bent ingelogd: {data[1]}");
                    break;
                case "weerstand":
                    Console.WriteLine($"Nieuwe weerstand ontvangen: {data[1]}");
                   // bleBikeHandler.ChangeResistance(Int32.Parse(data[1]));
                    break;
                case "patientData":
                    this.patients.Clear();
                    this.patients = JsonConvert.DeserializeObject<List<Patient>>(data[1]);
                    //PatientsInList(); 
                    /*if (patients.Find(pat => pat.Name == data[1]) != null)
                    {
                        patients.Find(pat => pat == JsonConvert.DeserializeObject<Patient>(data[2]));
                    } else
                    {
                        patients.Add(JsonConvert.DeserializeObject<Patient>(data[2]));
                    }*/
                    break;
                default:
                    Console.WriteLine("Onbekend pakketje");
                    break;
            }

        }

        private static void Write(string v)
        {
            stream.Write(System.Text.Encoding.ASCII.GetBytes(v), 0, v.Length);
            stream.Flush();

        }

        private double calculateVo2(double workload, double HRss, Patient patient)
        {
            double VO2max = 0;
            if (patient.Gender.Equals("Vrouw"))
            {
                VO2max = (0.00193 * workload +0.326) / (0.769 * HRss - 56.1) * 100; 
            }else 
            {
                VO2max = (0.00212 * workload + 0.299) / (0.769 * HRss - 48.5) * 100; 
            }

            if (patient.Age >= 30)
            {
                if (patient.Age < 35)
                {
                    VO2max *= 1;
                }
                else if (patient.Age < 40)
                {
                    VO2max *= 0.87;
                }
                else if (patient.Age < 45)
                {
                    VO2max *= 0.83;
                }
                else if (patient.Age < 50)
                {
                    VO2max *= 0.78;
                }
                else if (patient.Age < 55)
                {
                    VO2max *= 0.75;
                }
                else if (patient.Age < 60)
                {
                    VO2max *= 0.71;
                }
                else if (patient.Age < 65)
                {
                    VO2max *= 0.68;
                }
                else
                {
                    VO2max *= 0.65;
                }
            }

            if (patient.maxheartbeat > 0)
            {
                if (patient.maxheartbeat >= 210)
                {
                    VO2max *= 1.12;
                }
                else if (patient.maxheartbeat >= 200)
                {
                    VO2max *= 1;
                }
                else if (patient.maxheartbeat >= 190)
                {
                    VO2max *= 0.93;
                }
                else if (patient.maxheartbeat >= 180)
                {
                    VO2max *= 0.83;
                }
                else if (patient.maxheartbeat >= 170)
                {
                    VO2max *= 0.75;
                }
                else if (patient.maxheartbeat >= 160)
                {
                    VO2max *= 0.69;
                }
                else if (patient.maxheartbeat >= 150)
                {
                    VO2max *= 10.64;
                }
                else
                {
                    return VO2max;
                }
            }
                return VO2max; 
            
        }






        

        private void testDataAvailablePatients()
        {
            /*availablePatients.Add(new Patient("Pascal", 20, "Man", "0000"));
            availablePatients.Add(new Patient("Maarten", 20, "Man", "0000"));
            availablePatients.Add(new Patient("Thijs", 21, "Man", "0000"));
            availablePatients.Add(new Patient("Joelle", 20, "Vrouw", "0000"));
            availablePatients.Add(new Patient("Marleen", 20, "Vrouw", "0000"));
            availablePatients.Add(new Patient("Kirsten", 20, "Vrouw", "0000"));*/


        }

        private void PatientLabel_Click(object sender, EventArgs e)
        {

        }

        private void AvailableListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AvailableLabel_Click(object sender, EventArgs e)
        {

        }

        private void LayoutPanelClient_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Chart2_Click(object sender, EventArgs e)
        {

        }

        private void Chart1_Click(object sender, EventArgs e)
        {

        }

       

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Determine if text has changed in the textbox by comparing to original text.
            string json = JsonConvert.SerializeObject(patients);
            Write("stop\r\n" + json + "\r\n\r\n"); 
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string json = JsonConvert.SerializeObject(this.patients);
            Write("stop\r\n" + json + "\r\n\r\n");
        }

        private Patient patient; 
        private void AvailableListBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
            int index = availableListBox.SelectedIndex;
            this.patient = this.patients[index];
            clientInfo.Clear();
            clientInfo.AppendText($"Naam: {patient.Name}\r\nGeslacht: {patient.Gender}\r\nLeeftijd: {patient.Age}\r\nGewicht: {patient.weight}\r\nMaximale harstlag: {patient.maxheartbeat}\r\n Steady state: {patient.getSteadyState()}");
            allHistroy.Items.Clear(); 
            foreach(History history in this.patients[index].histories)
            {
                allHistroy.Items.Add(this.patients[index].Name +" "  + index); 
            }
        }

        private void AllHistroy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = allHistroy.SelectedIndex;
            writechart(patient.histories[index], this.patient); 

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            PatientsInList(); 
        }
    }



}