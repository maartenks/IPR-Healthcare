using Avans.TI.BLE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClientGUI.Bluetooth
{
    public class BleHeartHandler
    {
        public BLE bleHeart { get; private set; }
        public string heartData { get; set; }

        public event SubscriptionHandler SubscriptionValueChanged;
        public delegate void SubscriptionHandler(BLESubscriptionValueChangedEventArgs args);

        public async Task<bool> InitBleHeart()
        {
            return await Task.Run(() =>
            {
                try
                {
                    this.bleHeart = new BLE();
                    Thread.Sleep(1000);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public async Task<List<string>> RetrieveBleBikes(string filter)
        {
            if (bleHeart == null)
            {
                bool completed = await InitBleHeart();
                if (!completed)
                    return null;
            }
            return bleHeart.ListDevices().Where(x => x.Contains(filter)).ToList();
        }

        public async Task DataAsync()
        {
            int errorCode = 0;
            errorCode = await bleHeart.OpenDevice("Decathlon Dual HR");

            await bleHeart.SetService("HeartRate");

            bleHeart.SubscriptionValueChanged += BleHeart_SubscriptionValueChanged;
            await bleHeart.SubscribeToCharacteristic("HeartRateMeasurement");
        }

        private void BleHeart_SubscriptionValueChanged(object sender, BLESubscriptionValueChangedEventArgs e)
        {
            byte[] receivedDataSubset = e.Data;
            if (e.Data.Length == 6)
            {
                heartData = $"Heartrate data received: {receivedDataSubset[0]}, {receivedDataSubset[1]}, {receivedDataSubset[2]}, {receivedDataSubset[3]}, {receivedDataSubset[4]}, {receivedDataSubset[5]}";
                Console.WriteLine($"Heartrate data received: {receivedDataSubset[0]}, {receivedDataSubset[1]}, {receivedDataSubset[2]}, {receivedDataSubset[3]}, {receivedDataSubset[4]}, {receivedDataSubset[5]}");
                sendData();
            }
        }
        
        public string sendData()
        {
            return heartData;
        }

        public async void Connect(string deviceName, string serviceName)
        {
            // "Decathlon Dual HR"
            // "HeartRate"
            try
            {
                int errorCode = await this.bleHeart.OpenDevice(deviceName);
                errorCode = await this.bleHeart.SetService(serviceName);

            // "HeartRateMeasurement"
            this.bleHeart.SubscriptionValueChanged += (s, e) => SubscriptionValueChanged?.Invoke(e);
            errorCode = await this.bleHeart.SubscribeToCharacteristic(serviceName);
            }
            catch (Exception)
            {

            }
        }
    }
}