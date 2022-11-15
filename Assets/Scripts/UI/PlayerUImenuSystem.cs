using System.Net.Http.Headers;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUImenuSystem : MonoBehaviour
{
    [SerializeField] private InventoryMenu _inventoryMenu;
    private List<IPlayerMenu> _menus = new List<IPlayerMenu>();
    private void Awake()
    {
        _menus.Add(_inventoryMenu);
    }
    public void CallInventoryMenu()
    {
        ShowMenu<InventoryMenu>();
    }

    public void ShowMenu<T>() where T : IPlayerMenu
    {
        foreach (IPlayerMenu menu in _menus)
        {

            if (menu.IsOpened)
            {
                menu.Close();
                continue;
            }

            if (menu is T)
            {
                menu.Open();
            }
        }
    }
    public void HideMenu<T>() where T : IPlayerMenu
    {
        foreach (IPlayerMenu menu in _menus)
        {
            if (menu is T)
                menu.Close();
        }
    }
}
