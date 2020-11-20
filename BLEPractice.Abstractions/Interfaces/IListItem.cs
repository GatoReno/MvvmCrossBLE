using System;
namespace BLEPractice.Abstractions.Interfaces
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
