using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractItemsPlayerMenu : MonoBehaviour
{
    [SerializeField] private ItemsList _items;
    [SerializeField] protected ItemRepresenterInUI _representerPrefab;
    protected List<AbstractItemsSection> sections;

    protected virtual void Start()
    {
        sections = GetComponentsInChildren<AbstractItemsSection>().ToList();
        //Test adding items
        foreach (var item in _items.Items)
        {
            AddItemToMenu(item);
        }
    }
    protected virtual void OnEnable()
    {
        if (sections == null)
        {
            sections = GetComponentsInChildren<AbstractItemsSection>().ToList();
        }
    }
    public virtual void AddItemToMenu(Item item)
    {
        foreach (var section in sections)
        {
            section.AddItemRepresenterToSection(item, _representerPrefab);
        }
    }

    public virtual void RemoveItemFromMenu(Item item)
    {
        foreach (var section in sections)
        {
            section.RemoveRepresenterFromSection(item);
        }
    }
}
