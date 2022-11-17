using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class AbstractItemsSection : MonoBehaviour
{
    [SerializeField] protected Item.ItemTypeEnum sectionType;
    [SerializeField] private Transform _sectionContent;
    protected ItemRepresenterInUI sectionItem;
    private List<ItemRepresenterInUI> _sectionItemsList;
    protected PlayerUImenuSystem playerUImenuSystem;
    protected Transform player;

    [Inject]
    public void Constructor(PlayerUImenuSystem playerUimenuSystemArg, Transform playerArg)
    {
        playerUImenuSystem = playerUimenuSystemArg;
        player = playerArg;
    }
    private void Awake()
    {
        _sectionItemsList = new List<ItemRepresenterInUI>();
    }
    public abstract void AddItemRepresenterToSection(Item item, ItemRepresenterInUI representer);
    protected virtual void SetUpAndAddRepresenter(Item item, ItemRepresenterInUI representer)
    {
        sectionItem = Instantiate(representer, _sectionContent.transform.position, Quaternion.identity, _sectionContent);
        _sectionItemsList.Add(sectionItem);

        sectionItem.SetName(item.Name);
        sectionItem.SetImageColor(item.Color);

    }
    public virtual void RemoveRepresenterFromSection(Item item)
    {
        
        for (int i = 0; i < _sectionItemsList.Count; i++)
        {
            if(item.Name == _sectionItemsList[i].Name.text)
            {
                Destroy(_sectionItemsList[i].gameObject);
                _sectionItemsList.RemoveAt(i);
                break;
            }
        }
    }
}
