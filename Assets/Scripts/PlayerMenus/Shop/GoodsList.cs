using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Goods List")]
public class GoodsList : ScriptableObject
{
    [SerializeField] private List<ShopItem> _shopItems;

    public List<ShopItem> ShopItems { get => _shopItems;  }
}
