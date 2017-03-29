using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquipItem {
    // Created Mar 24, 2017 by rillyths

    
    int LevelRequired { get; set; }     // The level required to equip the item
    int Effect { get; set; }            // The item's normal effect, ex. damage amount
    int MinEffect { get; set; }         // The lowest int the effect can be
    GameObject Prefab { get; set; }     // The GameObject used to represent the item
}
