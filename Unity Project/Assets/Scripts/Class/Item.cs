using UnityEngine;

[System.Serializable]
public class Item {
    // Created Mar 24, 2017 by rillyths

    
    [SerializeField]
    string _name;           // The item's name
    [SerializeField]
    string _description;    // The item's description
    [SerializeField]
    int _buyAt;             // How much it costs to purchase the item from a NPC shop
    [SerializeField]
    int _curStack;          // How many items in the current stack
    [SerializeField]
    int _stacksTo;          // Maximum amount of items in a stack
    [SerializeField]
    Sprite _icon;           // The item's sprite when picked up

    // Constructor for an empty item
    public Item()
    {
        _name = "Unnamed";
        _description = "No description is available.";
        _buyAt = 300;
        _curStack = 1;
        _stacksTo = 30;
        _icon = null;
    }

    // Constructor for an item with set values
    public Item(string name, string desc, int buyAt, int stacksTo, Sprite icon)
    {
        _name = name;
        _description = desc;
        _buyAt = buyAt;
        _curStack = 1;
        _stacksTo = stacksTo;
        _icon = icon;
    }

    // Accessors for the private values
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public int BuyAt
    {
        get { return _buyAt; }
        set { _buyAt = value; }
    }

    public int CurStack
    {
        get { return _curStack; }
        set { _curStack = value; }
    }

    public int StacksTo
    {
        get { return _stacksTo; }
        set { _stacksTo = value; }
    }

    public Sprite Icon
    {
        get { return _icon; }
        set { value = _icon; }
    }
}
