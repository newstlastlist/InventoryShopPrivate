using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemsEquiper : MonoBehaviour
{
    [SerializeField] private ItemProperties _helmet;
    [SerializeField] private ItemProperties _weapon;
    private EquipedItem _currentHelmet;
    private EquipedItem _currentWeapon;
    private void Awake()
    {
        _currentHelmet = new EquipedItem();
        _currentWeapon = new EquipedItem();
    }
    public void Equip(InventoryItem item)
    {


        if (item is InventoryHelmet)
        {
            if (_currentHelmet.itemScriptableObj != null)
            {
                if (_currentHelmet.itemScriptableObj.Name == item.Name)
                {
                    Destroy(_currentHelmet.itemGameObj);
                    _currentHelmet.itemScriptableObj = null;
                    return;
                }
            }


            var obj = CreateAndSetupItemInPartOfBody(item, _helmet);

            SetupCurrentEquipedItem(_currentHelmet, obj, item);

        }
        else if (item is InventoryWeapon)
        {
            if (_currentWeapon.itemScriptableObj != null)
            {
                if (_currentWeapon.itemScriptableObj.Name == item.Name)
                {
                    Destroy(_currentWeapon.itemGameObj);
                    _currentWeapon.itemScriptableObj = null;
                    return;
                }
            }

            var obj = CreateAndSetupItemInPartOfBody(item, _weapon);

            SetupCurrentEquipedItem(_currentWeapon, obj, item);
        }

    }
    private void SetupCurrentEquipedItem(EquipedItem equipedItem, GameObject obj, InventoryItem item)
    {
        if (equipedItem.itemGameObj != null)
        {
            Destroy(equipedItem.itemGameObj);
        }
        equipedItem.itemGameObj = obj;
        equipedItem.itemScriptableObj = item;

    }
    private GameObject CreateAndSetupItemInPartOfBody(InventoryItem item, ItemProperties properties)
    {
        var obj = Instantiate(item.Prefab, transform.position, Quaternion.identity);

        obj.transform.parent = properties.playerBodyPart;
        obj.transform.localPosition = item.LocalPosInPlayerBody;
        obj.transform.localRotation = Quaternion.Euler(item.LocalEulerInPlayerBody);

        return obj;
    }


    [System.Serializable]
    private struct ItemProperties
    {

        public Transform playerBodyPart;

        //here can be other properties
    }
}
