using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSection : AbstractItemsSection
{
    public override void AddItemRepresenterToSection(Item item, ItemRepresenterInUI representer)
    {
        if (item.ItemType == sectionType)
        {
            SetUpAndAddRepresenter(item, representer);
        }
    }
    protected override void SetUpAndAddRepresenter(Item item, ItemRepresenterInUI representer)
    {
        base.SetUpAndAddRepresenter(item, representer);
        sectionItem.SetPrice(item.Price);
        sectionItem.SetActionOnClick(() => BuyItem(item));
    }

    private void BuyItem(Item item)
    {
        if (item.Price > PlayerPrefsWrapper.Gold)
        {
            Debug.Log("Earn more money :)");
            return;
        }

        PlayerPrefsWrapper.Gold -= item.Price;

        playerUImenuSystem.ShopMenu.UpdateGoldText();
        playerUImenuSystem.ShopMenu.RemoveItemFromMenu(item);

        if (!playerUImenuSystem.InventoryMenu.gameObject.activeSelf) //inventory menu is closed when player buyed item
        {
            InventoryMenu.AddItemToQueue(item);
        }
        else  //inventory menu is oppened when player buyed item
        {
            playerUImenuSystem.InventoryMenu.AddItemToMenu(item);
        }
    }
}
