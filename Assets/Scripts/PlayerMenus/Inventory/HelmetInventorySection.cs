using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetInventorySection : AbstractInventorySection
{
    public override void AddItemRepresenterToSection(InventoryItem item, ItemRepresenterInUI representer, Transform player)
    {
        if(item is InventoryHelmet)
        {
            SetUpAndAddRepresenter(item, representer, player);
        }
    }
}
