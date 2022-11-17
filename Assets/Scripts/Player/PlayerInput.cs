using UnityEngine;
using Zenject;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerInventoryCamera _inventoryCamera;
    private PlayerUImenuSystem _playerUimenuSystem;

    [Inject]
    public void Constructor(PlayerUImenuSystem playerUimenuSystem)
    {
        _playerUimenuSystem = playerUimenuSystem;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!_playerUimenuSystem.InventoryMenu.IsOpened)
            {
                _playerUimenuSystem.OpenInventoryMenu();
                _inventoryCamera.GoToInventoryMode();
                return;
            }
            if(_playerUimenuSystem.InventoryMenu.IsOpened)
            {
                _playerUimenuSystem.CloseInventoryMenu();
                _inventoryCamera.GoToMainPlayerCamera();
                return;
            }

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!_playerUimenuSystem.ShopMenu.IsOpened)
            {
                _playerUimenuSystem.OpenShopMenu();
                return;
            }
            if(_playerUimenuSystem.ShopMenu.IsOpened)
            {
                _playerUimenuSystem.CloseShopMenu();
                return;
            }

        }
    }
}
