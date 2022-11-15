using System;
using System.IO;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AbstractMenuItem : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Color _color;

    public string Name { get => _name; }
    public int Price { get => _price; }
    public Sprite Sprite { get => _sprite;  }
    public Color Color { get => _color; }

    public abstract void OnClick(Transform player);

    public virtual void SaveState()
    {
        var json = JsonUtility.ToJson(this);

        File.WriteAllText(GetFilePath(), json);
    }
    public virtual void LoadState()
    {
        var json = File.ReadAllText(GetFilePath());

        JsonUtility.FromJsonOverwrite(json, this);
    }
    protected string GetFilePath()
    {
        return Application.persistentDataPath + $"/{_name}.so";
    }
    
}
