using UnityEngine;

public class GoldTestSetter : MonoBehaviour
{
    [SerializeField] private int _gold = 5000;
    private void Awake()
    {
        PlayerPrefsWrapper.Gold = _gold;
    }
}
