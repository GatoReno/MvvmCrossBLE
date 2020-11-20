using System;
using BLEPractice.Abstractions.Interfaces;

namespace BLEPractice.Droid.BLEService
{
    public class BLEScanService : IScanBLE
    {
         
        public void CancelScanning()
        {
            if (BluetoothDeviceReceiver.Adapter.IsDiscovering) BluetoothDeviceReceiver.Adapter.CancelDiscovery();

        }

        public void StartScanning()
        {
            if (!BluetoothDeviceReceiver.Adapter.IsDiscovering) BluetoothDeviceReceiver.Adapter.StartDiscovery();
        }
    }
}
