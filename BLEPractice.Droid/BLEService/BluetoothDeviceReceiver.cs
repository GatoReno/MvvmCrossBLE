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
         

        public override void OnReceive(Context context, Intent intent)
        {
            var action = intent.Action;
            switch (action)
            {
                case BluetoothDevice.ActionFound:
                    var device = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);

                    
                    if (device.BondState != Bond.Bonded)
                    {
                        BLECastReciver.AddDeviceRecived(new BLEDataItem(device.Name, device.Address));
                    }
                    break;
            }
        }
    }
}
