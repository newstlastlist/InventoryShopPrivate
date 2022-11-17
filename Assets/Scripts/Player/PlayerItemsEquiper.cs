using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemsEquiper : MonoBehaviour
{
    [SerializeField] private List<ItemBodyProperties> _itemBodyProperies;
    private List<EquipedItemPlaceHolder> _equipedItems;
    private void Awake()
    {
        CreateItemPlaceholders();
    }
    public void TryToEquip(Item item)
    {
        var appropriateItemPlaceHolder = GetAppropriateItemPlaceHolder(item);

        if (!appropriateItemPlaceHolder.isPlaceholderEquiped)
        {
            Equip(item);
        }
        else if (appropriateItemPlaceHolder.isPlaceholderEquiped && IsPlaceholderEquipedBySameItem(appropriateItemPlaceHolder, item))
        {
            UnEquip(item);
        }
        else if (appropriateItemPlaceHolder.isPlaceholderEquiped && !IsPlaceholderEquipedBySameItem(appropriateItemPlaceHolder, item))
        {
            UnEquip(appropriateItemPlaceHolder.itemScriptableObj);
            Equip(item);
        }
    }

    private void Equip(Item item)
    {
        var itemGameobject = CreateAndSetupItemInPartOfBody(item);
        SetupEquipedItemPlaceHolder(item, itemGameobject);
    }
    private void UnEquip(Item item)
    {
        var itemPlaceHolder = GetAppropriateItemPlaceHolder(item);
        Destroy(itemPlaceHolder.itemGameObj);
        itemPlaceHolder.itemScriptableObj = null;
        itemPlaceHolder.isPlaceholderEquiped = false;
    }
    private void SetupEquipedItemPlaceHolder(Item item, GameObject obj)
    {
        var itemPlaceHolder = GetAppropriateItemPlaceHolder(item);
        if (itemPlaceHolder.itemGameObj != null)
        {
            Destroy(itemPlaceHolder.itemGameObj);
        }
        itemPlaceHolder.itemGameObj = obj;
        itemPlaceHolder.itemScriptableObj = item;
        itemPlaceHolder.isPlaceholderEquiped = true;
    }
    private GameObject CreateAndSetupItemInPartOfBody(Item item)
    {
        var obj = Instantiate(item.Prefab, transform.position, Quaternion.identity);
        var itemBodyPropertie = _itemBodyProperies.Where(prop => prop.itemType == item.ItemType).First();

        obj.transform.parent = itemBodyPropertie.playerBodyPart;
        obj.transform.localPosition = item.LocalPosInPlayerBody;
        obj.transform.localRotation = Quaternion.Euler(item.LocalEulerInPlayerBody);

        return obj;
    }
    private void CreateItemPlaceholders()
    {
        _equipedItems = new List<EquipedItemPlaceHolder>();

        foreach (var itemType in Enum.GetValues(typeof(Item.ItemTypeEnum)))
        {
            var newPlaceHolder = new EquipedItemPlaceHolder();
            newPlaceHolder.itemType = (Item.ItemTypeEnum)itemType;
            _equipedItems.Add(newPlaceHolder);
        }
    }
    private EquipedItemPlaceHolder GetAppropriateItemPlaceHolder(Item item)
    {
        return _equipedItems.Where(eq => eq.itemType == item.ItemType).First();
    }
    private bool IsPlaceholderEquipedBySameItem(EquipedItemPlaceHolder holder, Item item)
    {
        if(holder.itemScriptableObj == item)
        {
            return true;
        }
        return false;
    }

    [System.Serializable]
    private struct ItemBodyProperties
    {
        public Item.ItemTypeEnum itemType;
        public Transform playerBodyPart;
    }
}
