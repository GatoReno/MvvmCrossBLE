using System;
namespace BLEPractice.Abstractions.Interfaces.BLE_Interfaces
{
    public interface IListItem
    {
        ListItemType GetListItemType();

        string Text { get; set; }
    }

    public enum ListItemType
    {
        Header = 0,
        DataItem = 1,
        Status = 2
    }
}
