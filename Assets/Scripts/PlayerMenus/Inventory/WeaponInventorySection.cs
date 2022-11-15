using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventorySection : AbstractInventorySection
{
    public override void AddItemRepresenterToSection(InventoryItem item, ItemRepresenterInUI representer, Transform player)
    {
        if(item is InventoryWeapon)
        {
            SetUpAndAddRepresenter(item, representer, player);
        }
    }
}
