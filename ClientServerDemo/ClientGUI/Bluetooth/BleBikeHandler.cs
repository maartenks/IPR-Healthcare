using Avans.TI.BLE;
using ClientGUI.Sim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClientGUI.Bluetooth
{
    public class BleBikeHandler
    {
        public BLE bleBike { get; private set; }
        public string bikeData { get; set; }

        public event SubscriptionHandler SubscriptionValueChanged;
        public delegate void SubscriptionHandler(BLESubscriptionValueChangedEventArgs args);

        public event SimHandler SimValueChanged;
        public delegate void SimHandler(DataReceivedArgs args);

        public event SimEndedHandler SimEnded;
        public delegate void SimEndedHandler();

        public async Task<bool> InitBleBike()
        {
            return await Task.Run(() =>
            {
                try
                {
                    this.bleBike = new BLE();
                    Thread.Sleep(1000);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public async Task<List<string>> RetrieveBleBikes(string filter = "NO_FILTER")
        {
            if (bleBike == null)
            {
                bool completed = await InitBleBike();
                if (!completed)
                    return null;
            }
            return filter == "NO_FILTER" ? bleBike.ListDevices().ToList() : bleBike.ListDevices().Where(x => x.Contains(filter)).ToList();
        }

        public async Task DataAsync()
        {
            int errorCode = 0;
            errorCode = await bleBike.SetService("6e40fec1-b5a3-f393-e0a9-e50e24dcca9e");
            // __TODO__ error check

            // Subscribe
            bleBike.SubscriptionValueChanged += BleBike_SubscriptionValueChanged;
            errorCode = await bleBike.SubscribeToCharacteristic("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e");
        }

        private void BleBike_SubscriptionValueChanged(object sender, BLESubscriptionValueChangedEventArgs e)
        {
            bikeData = $"{e.Data[0]}, {e.Data[1]}, {e.Data[2]}, {e.Data[3]}, {e.Data[4]}, {e.Data[5]}, {e.Data[6]}, {e.Data[7]}, {e.Data[8]}, {e.Data[9]}, {e.Data[10]}, {e.Data[11]}, {e.Data[12]}";
     //       SimpleLog.Log("FietsData.txt", $"{e.Data[0]}, {e.Data[1]}, {e.Data[2]}, {e.Data[3]}, {e.Data[4]}, {e.Data[5]}, {e.Data[6]}, {e.Data[7]}, {e.Data[8]}, {e.Data[9]}, {e.Data[10]}, {e.Data[11]}, {e.Data[12]}");
        }

        public string sendData()
        {
            return bikeData;
        }

        public async void Connect(string deviceName, string serviceName)
        {
            // "Tacx Flux 00438"
            int errorCode = await this.bleBike.OpenDevice(deviceName);
            errorCode = await this.bleBike.SetService(serviceName);

            // "6e40fec1-b5a3-f393-e0a9-e50e24dcca9e"
            this.bleBike.SubscriptionValueChanged += (s, e) => SubscriptionValueChanged?.Invoke(e);
            errorCode = await this.bleBike.SubscribeToCharacteristic(serviceName);
        }

        public async void ChangeResistance(Byte hex)
        {
                byte[] output = new byte[13];
                output[0] = 0x4A; // Sync bit;
                output[1] = 0x09; // Message Length
                output[2] = 0x4E; // Message type
                output[3] = 0x05; // Message type
                output[4] = 0x30; // Data Type
                output[11] = hex;
                output[12] = 0xFF;
                int i = await this.bleBike.WriteCharacteristic("6e40fec3-b5a3-f393-e0a9-e50e24dcca9e", output);
        }

        public async void EmergencyBreak()
        {
            byte[] output = new byte[13];
            output[0] = 0x4A; // Sync bit;
            output[1] = 0x09; // Message Length
            output[2] = 0x4E; // Message type
            output[3] = 0x05; // Message type
            output[4] = 0x30; // Data Type
            output[11] = 0xFF;
            output[12] = 0xFF;
            int i = await this.bleBike.WriteCharacteristic("6e40fec3-b5a3-f393-e0a9-e50e24dcca9e", output);
        }

        public void ConnectSim(string fileName)
        {
            Simulator bleBikeSim = new Simulator(fileName);
            bleBikeSim.DataReceived += (e) => SimValueChanged?.Invoke(e);
            bleBikeSim.Ended += () => SimEnded?.Invoke();
            bleBikeSim.Start();
        }
    }
}