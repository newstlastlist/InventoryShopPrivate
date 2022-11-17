using System.Collections.Generic;

public class InventoryMenu : AbstractItemsPlayerMenu, IPlayerMenu
{
    private static List<Item> _itemsWaitingForAddingAfterBuying = new List<Item>();
    private bool _isOpened = false;
    public bool IsOpened { get => _isOpened; set => _isOpened = value; }

    public void Close()
    {
        _isOpened = false;

        gameObject.SetActive(false);
    }

    public void Open()
    {
        _isOpened = true;

        gameObject.SetActive(true);
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        
        if(_itemsWaitingForAddingAfterBuying.Count != 0)
        {
            foreach(var item in _itemsWaitingForAddingAfterBuying)
            {
                AddItemToMenu(item);
            }
            _itemsWaitingForAddingAfterBuying.Clear();
        }
    }
    public static void AddItemToQueue(Item item)
    {
        _itemsWaitingForAddingAfterBuying.Add(item);
    }
}
