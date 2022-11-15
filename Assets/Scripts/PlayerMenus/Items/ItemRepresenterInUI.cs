using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemRepresenterInUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _cost;
    [SerializeField] private Image _image;
    private int _itemCost;


    public void SetName(string name)
    {
        gameObject.name = name;
        _name.text = name;
    }
    public void SetImageColor(Color color)
    {
        _image.color = new Color(color.r, color.g, color.b, 1);

    }
    public void SetCost(int cost)
    {
        _itemCost = cost;

        _cost.text = _itemCost.ToString();
    }
    public void SetActionOnClick(Transform player, AbstractMenuItem item)
    {
        GetComponent<Button>().onClick.AddListener(() => item.OnClick(player));
    }
   

}
