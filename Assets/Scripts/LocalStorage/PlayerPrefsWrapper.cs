using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsWrapper 
{
    public static int Gold { get => PlayerPrefs.GetInt("Gold"); set => PlayerPrefs.SetInt("Gold", value); } 
    
}
