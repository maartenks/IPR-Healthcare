using System;
using Avans.TI.BLE;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientGUI.Bluetooth;
using ClientGUI.Conversion;
using ClientGUI.Utils;
using System.Threading;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace ClientGUI
{
    public partial class LoginScreen : Form
    {

        private static PageConversion pageConversion;
        private BleBikeHandler bleBikeHandler;
        private BleHeartHandler bleHeartHandler;
        private BLE bleBike;
        private BLE bleHeart;

        private List<string> bleBikeList;
        private List<string> bleHeartList;
        private bool started;
        private System.Timers.Timer timer;

        private int port;
        private string patient;
        private TcpClient client;
        private static NetworkStream stream;
        private static byte[] buffer = new byte[1024];
        static string totalBuffer = "";

        public LoginScreen()
        {
            InitializeComponent();
            InitializeDeclarations();
            LoadBikes();
            this.port = 80;
            timer = new System.Timers.Timer();
        }

        private void InitializeDeclarations()
        {
            this.bleBikeHandler = new BleBikeHandler();
            this.bleHeartHandler = new BleHeartHandler();
        }

        private async void LoadBikes()
        {
            this.bleBikeList = await this.bleBikeHandler.RetrieveBleBikes("Tacx");
            this.bleBikeList.ForEach(x => selectBike.Items.Add(x));
        }
        private bool PatientExist(string patientID)
        {
            return true;
        }



        private void Login_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            if (selectBike.SelectedItem != null)
            {
                if (PatientExist(patientNumber.Text))
                {
                    bleHeartHandler.Connect("Decathlon Dual HR", "Heartrate");
                    bleBikeHandler.Connect(selectBike.SelectedItem.ToString(), "6e40fec1-b5a3-f393-e0a9-e50e24dcca9e");
                    // connect.Connect();
                    //connect.sendPatient(new Patient(name.Text, patientNumber.Text));

                }
                else
                {
                    this.unknownNumber.Text = "Patiëntnummer bestaat niet!";
                    this.unknownNumber.Visible = true;
                    
            }
            }
            else
            {
                this.unknownNumber.Text = "     Geen fiets geselecteerd!";
                this.unknownNumber.Visible = true;
=======
 //           if (selectBike.SelectedItem != null)
 //           {
 //               bleHeartHandler.Connect("Decathlon Dual HR", "Heartrate");
 //               bleBikeHandler.Connect(selectBike.SelectedItem.ToString(), "6e40fec1-b5a3-f393-e0a9-e50e24dcca9e");
                this.patient = name.Text;
                ConnectServer();
                name.Enabled = false;
                login.Enabled = false;
                startSession.Enabled = true;
 //               }
>>>>>>> Stashed changes
            }

        private void Name_Enter(object sender, EventArgs e)
        {
            if (name.Text == "Naam")
            {
                name.Text = "";

                name.ForeColor = Color.Black;
            }
        }

        private void Name_Leave(object sender, EventArgs e)
        {
            if (name.Text == "")
            {
                name.Text = "Naam";
                name.ForeColor = Color.Silver;
            }
        }

        private void ConnectServer()
        {
            client = new TcpClient();
            client.Connect("localhost", this.port);

            stream = client.GetStream();
            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);

        }

        private static void Write(string v)
        {
            stream.Write(System.Text.Encoding.ASCII.GetBytes(v), 0, v.Length);
            stream.Flush();

        }

        private static void WriteBike(string v)
        {
            Write($"fiets\r\n{v}\r\n\r\n");
        }

        private static void WriteHeart(string v)
        {
            Write($"hart\r\n{v}\r\n\r\n");
        }


        private static void OnRead(IAsyncResult ar)
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

        private static void handlePacket(string[] data)
        {
            switch (data[0])
            {
                case "login":
                    Console.WriteLine($"Je bent ingelogd: {data[1]}");
                    break;
                case "fiets":
                    break;
                default:
                    Console.WriteLine("Onbekend pakketje");
                    break;
            }

        }

        private void WarmingUp()
        {
            instructions.AppendText("We beginnnen met de warming up. Tijdens deze warming-up houden we de trapfrequentie tussen de 50 en 60 omwentelingen per minuut.");
            
        }

        private void OnLevel()
        {
            instructions.Clear();
            instructions.AppendText("Vanaf nu bouwen we de weerstand op. De trapfrequentie moet rond de 60 blijven liggen. De weerstand wordt opgebouwd totdat de hartfrequentie 130 slagen per minuut is.");
        }

        private void HoldFrequency()
        {
            instructions.Clear();
            instructions.AppendText("Vanaf nu wordt de frequentie twee minuten lang aangehouden.");
        }
        
        private void CoolingDown()
        {
            instructions.Clear();
            instructions.AppendText("De weerstand wordt gedurende een minuut afgebouwd.");
        }


    }
}
