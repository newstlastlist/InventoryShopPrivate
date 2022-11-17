using UnityEngine;
using TMPro;

public class ShopMenu : AbstractItemsPlayerMenu, IPlayerMenu
{
    [SerializeField] private TextMeshProUGUI _gold;
    private bool _isOpened = false;
    public bool IsOpened { get => _isOpened; set => _isOpened = value; }
    protected override void Start()
    {
        base.Start();
        UpdateGoldText();
    }
    public void UpdateGoldText()
    {
        _gold.text = PlayerPrefsWrapper.Gold.ToString();
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
