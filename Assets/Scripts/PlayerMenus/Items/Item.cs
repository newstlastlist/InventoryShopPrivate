using UnityEngine;

[CreateAssetMenu(menuName = "Items/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private ItemTypeEnum _itemType;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Color _color;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Vector3 _localPosInPlayerBody;
    [SerializeField] private Vector3 _localEulerInPlayerBody;
    
    public string Name { get => _name; }
    public int Price { get => _price; }
    public Sprite Sprite { get => _sprite;  }
    public Color Color { get => _color; }
    public Vector3 LocalEulerInPlayerBody { get => _localEulerInPlayerBody;  }
    public Vector3 LocalPosInPlayerBody { get => _localPosInPlayerBody; }
    public GameObject Prefab { get => _prefab;  }
    public ItemTypeEnum ItemType { get => _itemType; }

    public enum ItemTypeEnum
    {
        Weapon,
        Helmet
    }
    
}
