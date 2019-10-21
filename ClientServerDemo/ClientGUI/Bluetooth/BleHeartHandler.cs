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
            if(e.Data[1] == 8)
            {
                heartData = $"{e.Data[6]}";
            }
        }
        
        public string sendData()
        {
            return heartData;
        }

        public async void Connect(string deviceName, string serviceName)
        {
            int errorCode = await this.bleHeart.OpenDevice("Decathlon Dual HR");
            errorCode = await this.bleHeart.SetService("HeartRate");

            // "HeartRateMeasurement"
            bleHeart.SubscriptionValueChanged += BleHeart_SubscriptionValueChanged;
            await this.bleHeart.SubscribeToCharacteristic("HeartRateMeasurement");
        }
    }
}