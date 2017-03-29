using System;
using UnityEngine;

[Serializable]
public class Tool : Item, IEquipItem
{
    // Created Mar 24, 2017 by rillyths

    [SerializeField]
    public EquipmentSlot equipmentSlot; // The equipment slot
    [SerializeField]
    ToolType _type;                     // The type of tool

    [SerializeField]
    int _lvlRequired;                   // Private int for IEquipItem
    [SerializeField]
    int _effect;                        // Private int for IEquipItem
    [SerializeField]
    int _minEffect;                     // Private int for IEquipItem
    [SerializeField]
    GameObject _prefab;                 // Private GameObject for IEquipItem
    
    
    // Constructor for an empty tool
    public Tool()
    {
        _effect = 1;
        _minEffect = 0;
    }

    public Tool(string name)
    {
        Name = name;
        _effect = 1;
        _minEffect = 0;
    }

    // Accessors for the private values
    public int Effect
    {
        get { return _effect; }
        set { _effect = value; }
    }

    public int MinEffect
    {
        get { return _minEffect; }
        set { _minEffect = value; }
    }

    public int LevelRequired
    {
        get { return _lvlRequired; }
        set { _lvlRequired = value; }
    }

    public GameObject Prefab
    {
        get { return _prefab; }
        set { _prefab = value; }
    }

    public ToolType Type
    {
        get { return _type; }
        set { _type = value; }
    }
}

public enum ToolType
{
    Sword,
    Dagger,
    Shield,
    Bow,
    Hoe,
    Bowl
}