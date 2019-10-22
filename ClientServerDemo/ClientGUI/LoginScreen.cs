using System;
using Avans.TI.BLE;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClientGUI.Bluetooth;
using ClientGUI.Conversion;
using ClientGUI.Utils;
using System.Threading;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace ClientGUI
{
    public partial class LoginScreen : Form
    {

        private static PageConversion pageConversion;
        private BleBikeHandler bleBikeHandler;
        private BleHeartHandler bleHeartHandler;

        private List<string> bleBikeList;
        private Patient patient;

        private int port;
        private TcpClient client;
        private static NetworkStream stream;
        private static byte[] buffer = new byte[1024];
        static string totalBuffer = "";
        private int seconds = 0;
        private int minutes = 0;
        private int phase = 0;
        private int phaseTime = 120;
        private int phaseTimeMin;
        private int phaseTimeSec;
        private int maxHeart;
        private int minHeart;
        private int totalSeconds = 0;
        private bool intensive = false;
        private int resistance = 0;
        private List<int> steadyState = new List<int>();

        public LoginScreen()
        {
            
            InitializeComponent();
            InitializeDeclarations();
            LoadBikes();
            this.port = 80;
            startSession.Enabled = false;
            time = new System.Windows.Forms.Timer();
        }

        private void InitializeDeclarations()
        {
            this.bleBikeHandler = new BleBikeHandler();
            this.bleHeartHandler = new BleHeartHandler();
        }

        private async void LoadBikes()
        {
            this.bleBikeList = await this.bleBikeHandler.RetrieveBleBikes("Tacx");
            await bleHeartHandler.InitBleHeart();
            this.bleBikeList.ForEach(x => selectBike.Items.Add(x));
            comboGender.Items.Add("Man");
            comboGender.Items.Add("Vrouw");
            for (int i = 15; i < 75; i++)
            {
                comboAge.Items.Add(i.ToString());
            }
        }



        private async void Login_Click(object sender, EventArgs e)
        {
            if (selectBike.SelectedItem != null)
            {
                await bleHeartHandler.InitBleHeart();
                bleHeartHandler.Connect("Decathlon Dual HR", "Heartrate");
                bleBikeHandler.Connect(selectBike.SelectedItem.ToString(), "6e40fec1-b5a3-f393-e0a9-e50e24dcca9e");
                ConnectServer();
                name.Enabled = false;
                textWeight.Enabled = false;
                comboAge.Enabled = false;
                comboGender.Enabled = false;
                selectBike.Enabled = false;
                login.Enabled = false;
                startSession.Enabled = true;
                PreInstructions();
                MakePatient();
                startSession.Enabled = true;
                await bleHeartHandler.DataAsync();
                await bleBikeHandler.DataAsync();
                bleBikeHandler.ChangeResistance(0);
            }
            ConnectServer();
            MockData(); 
            }

        private void ConnectServer()
        {
            client = new TcpClient();
            client.Connect("localhost", this.port);

            stream = client.GetStream();
            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);

        }

        private void MockData()
        {
            Patient hanna = new Patient("hanna", 5, "Vrouw", 50, "i");
            Patient hanna1 = new Patient("hanna", 5, "Vrouw", 50, "i");
            Patient hanna2 = new Patient("hanna", 5, "Vrouw", 50, "i");
            Patient hanno = new Patient("hannd", 5, "Vrouw", 50, "i");
            Patient hanno3 = new Patient("hannd", 5, "Vrouw", 50, "i");
            Patient hannb = new Patient("hannf", 5, "Vrouw", 50, "i");
            Patient hanng = new Patient("hanng", 5, "Vrouw", 50, "i");
            List<double> workload = new List<double>();
            List<double> heartate = new List<double>(); 
            for(int i = 0; i < 20; i++)
            {
                workload.Add(i * 4);
                heartate.Add(i * 5); 
            }
            hanna.workload = workload;
            hanna.heartbeat = heartate;
            WritePatient("d", JsonConvert.SerializeObject(hanna));
            hanna1.workload = workload;
            hanna1.heartbeat = heartate;
            WritePatient("d", JsonConvert.SerializeObject(hanna1));
            hanna2.workload = workload;
            hanna2.heartbeat = heartate;
            WritePatient("d", JsonConvert.SerializeObject(hanna2));
            hanno.workload = workload;
            hanno.heartbeat = heartate;
            WritePatient("d", JsonConvert.SerializeObject(hanno));
            hanno3.workload = workload;
            hanno3.heartbeat = heartate;
            WritePatient("d", JsonConvert.SerializeObject(hanno3));
            hannb.workload = workload;
            hannb.heartbeat = heartate;
            WritePatient("d", JsonConvert.SerializeObject(hannb));
            hanng.workload = workload;
            hanng.heartbeat = heartate;
            WritePatient("d", JsonConvert.SerializeObject(hanng));


        }

        private static void WriteHeart(string v)
        {
            Write($"hart\r\n{JsonConvert.SerializeObject(v)}\r\n\r\n");
        }

        private static void WritePatient(string name, string v)
        {
            Write($"patient\r\n{name}\r\n{v}\r\n\r\n");
        }

        private void StartSession_Click(object sender, EventArgs e)
        {
            Initialize_Timer();
        }

        private void Initialize_Timer()
        {
            if (timePassed.Text == "00:00") { WarmingUp(); phase++; }
            time.Interval = 300;
            time.Tick += new EventHandler(Timertick);
            time.Start();
        }

        private void MakePatient()
        {
            patient = new Patient(
               name.Text,
               Int32.Parse(comboAge.Text),
               comboGender.Text,
               Int32.Parse(textWeight.Text),
               selectBike.Text
                );

        }

        private void UpdatePatient()
        {
            WritePatient(name.Text, JsonConvert.SerializeObject(patient));
        }

        private async void UpdataData()
        {
            await bleBikeHandler.DataAsync();
            await bleHeartHandler.DataAsync();
        }

        private void CalculateSteadyState()
        {
            if (maxHeart < Int32.Parse(bleHeartHandler.heartData))
            {
                maxHeart = Int32.Parse(bleHeartHandler.heartData);
            } else if (minHeart > Int32.Parse(bleHeartHandler.heartData))
            {
                minHeart = Int32.Parse(bleHeartHandler.heartData);
            }
        
        }
        
        private void RealSteadyState()
        {
            int diff = maxHeart - minHeart;
            if (diff > 6)
            {
                patient.steadyState = true;
            }
            else
            {
                patient.steadyState = false;
            }
        }

        private async void Timertick(object sender, EventArgs e)
        {
            UpdataData();
            totalSeconds++;
            phaseTime--;
            this.phaseTimeMin = phaseTime / 60;
            this.phaseTimeSec = phaseTime & 60;
            this.seconds = totalSeconds % 60;
            this.minutes = totalSeconds / 60;
            if (totalSeconds % 15 == 0)
            {
                patient.workload.Add(bleBikeHandler.workload);
                patient.heartbeat.Add(Int32.Parse(bleHeartHandler.heartData));
                if (intensive)
                {
                    steadyState.Add(Int32.Parse(bleHeartHandler.heartData));
                }
                realtimeGemHF.Text = bleHeartHandler.heartData;
            }
            if (this.phaseTimeSec < 10) {
                realtimePhaseTime.Text = "0" + this.phaseTimeMin + ":0" + this.phaseTimeSec;
            }
            else if (this.phaseTimeSec == 60)
            {
                realtimePhaseTime.Text = "0" + this.phaseTimeMin + ":00";
            }
            else
            {
                realtimePhaseTime.Text = "0" + this.phaseTimeMin + ":" + this.phaseTimeSec;
            }
            if (this.seconds < 10)
            {
                timePassed.Text = "0" + this.minutes + ":0" + this.seconds;
            }
            else
            {
                timePassed.Text = "0" + this.minutes + ":" + this.seconds;
            }
            if (timePassed.Text == "02:00")
            {
                OnLevel(); phaseTime = 120; phase++; intensive = true;
            }
            if (timePassed.Text == "04:00")
            {
                HoldFrequency(); phaseTime = 120; phase++;       
            }
            if (timePassed.Text == "06:00")
            {
                CoolingDown();    phaseTime = 60; phase++;       intensive = false; ChangeResistanceDown();  RealSteadyState();
            }
                if (timePassed.Text == "07:00")
            {
                time.Stop(); phaseTime = 60; UpdatePatient();
            }
                if (intensive)
            {
                MaxHeartFrequencyHit();
                SteadyState();
            }
                if (intensive && totalSeconds > 240)
            {
                CalculateSteadyState();
            }
            realtimePhase.Text = phase.ToString();
            realtimeRPM.Text = bleBikeHandler.bikeData;
            patient.rotationPerMinute.Add(Int32.Parse(bleBikeHandler.bikeData));
            if (patient.maxheartbeat < Int32.Parse(bleHeartHandler.heartData))
            {
                patient.maxheartbeat = Int32.Parse(bleHeartHandler.heartData);
            }
            realtimeHF.Text = bleHeartHandler.heartData;
            realtimeResistance.Text = bleBikeHandler.percent + "%";
            CheckRPM(Int32.Parse(bleBikeHandler.bikeData));
            drawHeartrate(totalSeconds, Int32.Parse(bleHeartHandler.heartData));
            drawRPM(totalSeconds, Int32.Parse(bleBikeHandler.bikeData));



        }

        private void drawHeartrate(int time, int heart)
        {
            chart1.Series["Heartrate"].Points.AddXY(time, heart);
        }

        private void drawRPM(int time, int RPM)
        {
            chart1.Series["RPM"].Points.AddXY(time, RPM); 
        }

        private void StopSession()
        {
            time.Stop();
            instructions.Clear();
            instructions.AppendText("De sessie is gestopt en wordt afgebroken.");
            startSession.Enabled = false;
        }
        private void MaxHeartFrequencyHit()
        {
            if (Int32.Parse(comboAge.Text) > 14 && Int32.Parse(comboAge.Text) < 24 ) { if (Int32.Parse(bleHeartHandler.heartData) > 210) { StopSession(); } }
            if (Int32.Parse(comboAge.Text) > 25 && Int32.Parse(comboAge.Text) < 34) { if (Int32.Parse(bleHeartHandler.heartData) > 200) { StopSession(); } }
            if (Int32.Parse(comboAge.Text) > 35 && Int32.Parse(comboAge.Text) < 44) { if (Int32.Parse(bleHeartHandler.heartData) > 190) { StopSession(); } }
            if (Int32.Parse(comboAge.Text) > 45 && Int32.Parse(comboAge.Text) < 54) { if (Int32.Parse(bleHeartHandler.heartData) > 180) { StopSession(); } }
            if (Int32.Parse(comboAge.Text) > 55) { if (Int32.Parse(bleHeartHandler.heartData) > 170) StopSession(); }
        }

        private void SteadyState()
        {
            if (Int32.Parse(bleHeartHandler.heartData) < 130)
            {
                if (resistance < 100)
                {
                    resistance++;
                    int resist = resistance * 2;
                    bleBikeHandler.ChangeResistance(resist);
                    resistanceMessage.ForeColor = Color.Black;
                    resistanceMessage.Text = "Weerstand wordt opgevoerd";
                }
            }
            resistanceMessage.Text = "";
        }

        private void CheckRPM(int RPM)
        {
            rotationMessage.ForeColor = Color.Black;
            if (RPM < 50)
            {
                rotationMessage.Text = "U fietst te langzaam. Verhoog uw snelheid";
            }
            else if (RPM > 60)
            {
                rotationMessage.Text = "U fietst te snel. Verlaag uw snelheid";
            }
            else if (RPM > 49 && RPM < 61)
            {
                rotationMessage.Text = "U fietst een goede snelheid. Hou dit tempo aan.";
            }
        }

        private void ChangeResistanceDown()
        {
            if (resistance > 0)
            {
                resistance--;
                bleBikeHandler.ChangeResistance(resistance);
            }
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

        private void handlePacket(string[] data)
        {
            switch (data[0])
            {
                case "login":
                    Console.WriteLine($"Je bent ingelogd: {data[1]}");
                    break;
                case "weerstand":
                    Console.WriteLine($"Nieuwe weerstand ontvangen: {data[1]}");
                    bleBikeHandler.ChangeResistance(Int32.Parse(data[1]));
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

        private static void WriteBike(string v, int sec)
        {
            Write($"fiets\r\n{JsonConvert.SerializeObject(v)}\r\n{JsonConvert.SerializeObject(sec)}\r\n");
        }

        private void PreInstructions()
        {
            instructions.AppendText("De patiënt doet een hartslagband om en neemt plaats op de fiets. Stel het zadel op de juiste hoogte in, zodanig dat in de laagste stand van het pedaal, de knie zeer licht is gebogen (170o). ");

        }

        private void WarmingUp()
        {
            instructions.Clear();
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

        private void StopSession_Click(object sender, EventArgs e)
        {
            StopSession();
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

        private void TextWeight_Leave(object sender, EventArgs e)
        {
            if (textWeight.Text == "")
            {
                textWeight.Text = "Gewicht in kg";
                textWeight.ForeColor = Color.Silver;
            }
        }

        private void TextWeight_Enter(object sender, EventArgs e)
        {
            if (textWeight.Text == "Gewicht in kg")
            {
                textWeight.Text = "";
                textWeight.ForeColor = Color.Black;
            }
        }
    }
}
