using System.Collections.Generic;
using UnityEngine;

public class PlayerUImenuSystem : MonoBehaviour
{
    [SerializeField] private InventoryMenu _inventoryMenu;
    [SerializeField] private ShopMenu _shopMenu;
    private List<IPlayerMenu> _menus = new List<IPlayerMenu>();

    public ShopMenu ShopMenu { get => _shopMenu;  }
    public InventoryMenu InventoryMenu { get => _inventoryMenu; }


    private void Awake()
    {
        _menus.Add(_inventoryMenu);
        _menus.Add(_shopMenu);
    }
    public void OpenInventoryMenu()
    {
        ShowMenu<InventoryMenu>();
        // HideAllOtherMenusExceptThis<InventoryMenu>();
    }
    public void CloseInventoryMenu()
    {
        HideMenu<InventoryMenu>();
    }
    public void OpenShopMenu()
    {
        ShowMenu<ShopMenu>();
        // HideAllOtherMenusExceptThis<ShopMenu>();
    }
    public void CloseShopMenu()
    {
        HideMenu<ShopMenu>();
    }

    public void ShowMenu<T>() where T : IPlayerMenu
    {
        foreach (IPlayerMenu menu in _menus)
        {

            if (menu.IsOpened)
            {
                // menu.Close();
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
            if ((menu is T) && menu.IsOpened)
                menu.Close();
        }
    }
    public void HideAllOtherMenusExceptThis<T>() where T : IPlayerMenu
    {
        foreach (IPlayerMenu menu in _menus)
        {
            if (!(menu is T) && menu.IsOpened)
                menu.Close();
        }
    }
}
