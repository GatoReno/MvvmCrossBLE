using System;
using BLEPractice.Abstractions.BLEHelpers;

namespace BLEPractice.Abstractions.Interfaces
{
    public interface IBLECastReciver
    {
        void AddDeviceRecived(BLEDataItem dataItem);        
        string Status { get; set; }
    }
}
