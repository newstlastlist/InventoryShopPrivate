using System.Collections;
using System.Collections.Generic;
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
        if(Input.GetKeyDown(KeyCode.I))
        {
            _playerUimenuSystem.CallInventoryMenu();

            _inventoryCamera.CallInventoryCamera();
        }
    }
}
