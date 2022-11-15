using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryMenu : MonoBehaviour, IPlayerMenu
{
    [SerializeField] private ItemsList _items;
    [SerializeField] private ItemRepresenterInUI _representerPrefab;
    private List<AbstractInventorySection> _sections;
    private Transform _player;

    private bool _isOpened = false;
    public bool IsOpened { get => _isOpened; set => _isOpened = value; }

    [Inject]
    public void Constructor(Transform player)
    {
        _player = player;
    }

    private void Awake()
    {
        _sections = GetComponentsInChildren<AbstractInventorySection>().ToList();

        //Test adding items
        foreach(var item in _items.InventoryItems)
        {
            AddItemToInventory(item);
        }
    }
    public void AddItemToInventory(InventoryItem item)
    {
        foreach(var section in _sections)
        {
            section.AddItemRepresenterToSection(item, _representerPrefab, _player);
        }
    }

    public void Close()
    {
        _isOpened = false;

        gameObject.SetActive(false);
    }

    public void Open()
    {
        _isOpened = true;

        gameObject.SetActive(true);
    }
}
