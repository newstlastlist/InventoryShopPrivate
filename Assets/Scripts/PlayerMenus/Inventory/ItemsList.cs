using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Items List")]
public class ItemsList : ScriptableObject
{
    [SerializeField] private List<InventoryItem> _inventoryItems;

    public List<InventoryItem> InventoryItems { get => _inventoryItems;  }
}
