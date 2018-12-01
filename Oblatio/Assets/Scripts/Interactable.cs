using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 500f;
    public Item item;
    public Transform player;
    public Camera cam;
 
    

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            float distances = Vector3.Distance(player.position, transform.position);
            if (distances <= 2)
            {
                PickUp();
                Debug.Log("within");
            }          
        }
       
    }

    public void PickUp()
    {
        bool wasPickedUp = InventoryManager.instance.Add(item);

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
