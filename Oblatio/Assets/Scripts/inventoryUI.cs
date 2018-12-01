using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryUI : MonoBehaviour {

    InventoryManager inventory;

    public Transform itemsList;

    InventorySlot[] slots;

	// Use this for initialization
	void Start () {
        inventory = InventoryManager.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsList.GetComponentsInChildren<InventorySlot>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);

            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
