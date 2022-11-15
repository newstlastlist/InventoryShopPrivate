using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInventorySection : MonoBehaviour
{
    [SerializeField] private Transform _sectionContent;
    public abstract void AddItemRepresenterToSection(InventoryItem item, ItemRepresenterInUI representer, Transform player);
    protected virtual void SetUpAndAddRepresenter(InventoryItem item, ItemRepresenterInUI representer, Transform player)
    {
        var sectionItem = Instantiate(representer, _sectionContent.transform.position, Quaternion.identity, _sectionContent);

        sectionItem.SetName(item.Name);
        sectionItem.SetImageColor(item.Color);
        sectionItem.SetActionOnClick(player, item);

    }
}
