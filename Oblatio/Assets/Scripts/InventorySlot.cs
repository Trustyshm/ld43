using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    Item item;
    public Button removeButton;
    public Image icon;
    public Transform player;

    public void AddItem (Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        if (InventoryManager.instance.items.Contains(item) != false)
        {
            Debug.Log(item);
            InventoryManager.instance.Remove(item);
        }
        
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
