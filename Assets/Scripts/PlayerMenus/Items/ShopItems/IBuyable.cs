using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuyable 
{
    public bool IsBuyed { get; set;}
    public void Buy(Transform player);
}
