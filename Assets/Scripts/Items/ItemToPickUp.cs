using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToPickUp : MonoBehaviour
{

    public Item item;
    public string itemName;
    public PlayerController cont;
    private GameObject thisItem;
    public bool canTake = true;
    public void Awake()
    {
        cont = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

    }

    private void Update()
    { 
        Inventory inventory = GameObject.Find("Player").GetComponent<Inventory>();
        UIInventory uIInventory = GameObject.Find("Player").GetComponent<UIInventory>();


        
    
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventory.numberOfItems < 16)
            {

                if (thisItem == this.gameObject)
                {

                    inventory.GiveItem(thisItem.gameObject.name);
                    //Debug.Log(itemName);
                    Destroy(thisItem);
                }
            }
        }
    }
    


    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            thisItem = this.gameObject;
            itemName = this.gameObject.name;
            
        }
    }
}
