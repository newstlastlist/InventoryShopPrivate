using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : AbstractMenuItem, IBuyable
{
    [SerializeField] private InventoryItem _item;
    public bool IsBuyed { get ; set ; }
    

    public void Buy(Transform player)
    {
        
    }

    public override void OnClick(Transform player)
    {
        Buy(player);
    }
}
