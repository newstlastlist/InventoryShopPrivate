using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class ItemRepresenterInUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _cost;
    [SerializeField] private Image _image;
    private int _itemCost;

    public TextMeshProUGUI Name { get => _name;  }

    public void SetName(string name)
    {
        gameObject.name = name;
        _name.text = name;
    }
    public void SetImageColor(Color color)
    {
        _image.color = new Color(color.r, color.g, color.b, 1);
    }
    public void SetPrice(int cost)
    {
        _itemCost = cost;

        _cost.text = _itemCost.ToString();
    }
    public void SetActionOnClick(UnityAction action)
    {
        GetComponent<Button>().onClick.AddListener(action);
    }
   

}
