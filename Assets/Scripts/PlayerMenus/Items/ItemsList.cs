using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Items List")]
public class ItemsList : ScriptableObject
{
    [SerializeField] private List<Item> _items;

    public List<Item> Items { get => _items;  }
}
