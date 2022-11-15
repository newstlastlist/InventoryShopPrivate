using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : AbstractMenuItem, IEquipable
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Vector3 _localPosInPlayerBody;
    [SerializeField] private Vector3 _localEulerInPlayerBody;

    public Vector3 LocalEulerInPlayerBody { get => _localEulerInPlayerBody;  }
    public Vector3 LocalPosInPlayerBody { get => _localPosInPlayerBody; }
    public GameObject Prefab { get => _prefab;  }

    public override void OnClick(Transform player)
    {
        Equip(player);
    }

    public void Equip(Transform player)
    {
        // Debug.Log(player.gameObject.name + "equiped " + Name);
        player.GetComponent<PlayerItemsEquiper>().Equip(this);
    }
    
}
