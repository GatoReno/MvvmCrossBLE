using System;
namespace BLEPractice.Abstractions.Interfaces
{
    public interface IScanBLE
    {
        void StartScanning();
        void CancelScanning();
    }
}
