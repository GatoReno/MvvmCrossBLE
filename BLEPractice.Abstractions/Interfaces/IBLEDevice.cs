using System;
using BLEPractice.Abstractions.BLEHelpers;

namespace BLEPractice.Abstractions.Interfaces
{
    public interface IBLEDevice
    {
        void AddDevice(BLEDataItem dataItem);
    }
}
