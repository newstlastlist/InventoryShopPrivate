using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMenu
{
    bool IsOpened {get; }
    void Open();
    void Close();
    
}
