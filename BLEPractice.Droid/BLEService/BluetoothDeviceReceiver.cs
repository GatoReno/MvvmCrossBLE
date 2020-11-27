using System;
using Android.Bluetooth;
using Android.Content;
using BLEPractice.Abstractions.BLEHelpers;
using BLEPractice.Abstractions.Interfaces;

namespace BLEPractice.Droid.BLEService
{
    public class BluetoothDeviceReceiver : BroadcastReceiver 
    {
        public static BluetoothAdapter Adapter => BluetoothAdapter.DefaultAdapter;
        public IBLECastReciver BLECastReciver { get; set; }
        private BluetoothManager _manager;

        public BluetoothDeviceReceiver(IBLECastReciver receiver)
        {
            BLECastReciver = receiver;
        }

        public override void OnReceive(Context context, Intent intent)
        {
            _manager = (BluetoothManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.BluetoothService);
            _manager.Adapter.Enable();

            var action = intent.Action;
            switch (action)
            {
                case BluetoothDevice.ActionFound:
                    var device = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);

                    
                    if (device.BondState != Bond.Bonded)
                    {
                        
                        if (!string.IsNullOrEmpty(device.Name))
                        {                            
                            BLECastReciver.AddDeviceRecived(new BLEDataItem(device.Name, device.Address));
                        }
                        
                    }
                    break;
                case BluetoothAdapter.ActionDiscoveryStarted:
                    BLECastReciver.Status = "Discovery Started...";
                   // MainActivity.GetInstance().UpdateAdapterStatus("Discovery Started...");
                    break;
                case BluetoothAdapter.ActionDiscoveryFinished:
                    BLECastReciver.Status = "Discovery Finished.";
                    //MainActivity.GetInstance().UpdateAdapterStatus("Discovery Finished.");
                    break;
            }
        }



        private void BindBLEViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
