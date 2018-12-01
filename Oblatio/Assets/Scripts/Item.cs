using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool feedToRabbit;
    public bool feedToCat;
    public bool feedToDog;
    public bool feedToSheep;
    public bool feedToCow;
    public bool feedToHorse;
    public bool feedToTiger;

    public virtual void Use()
    {
        //Use the item
        Debug.Log("Used" + " " + name);
    }
}
