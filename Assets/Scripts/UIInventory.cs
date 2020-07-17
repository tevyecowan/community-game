using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> uIItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    public int maxNumberOfSlots = 16;
    public int numberOfSlots = 0;

    private void Awake()
    {

        for(int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uIItems.Add(instance.GetComponentInChildren<UIItem>());
        }
    }

    public void updateNumberOfSlots(int numSlotsToAdd)
    {
       
            for (int i = 0; i < numSlotsToAdd; i++)
            {
                GameObject instance = Instantiate(slotPrefab);
                instance.transform.SetParent(slotPanel);
                uIItems.Add(instance.GetComponentInChildren<UIItem>());

            }
            
        

    }

    public void UpdateSlot(int slot, Item item)
    {
        uIItems[slot].UpdateItem(item);
    }

    public void AddNewItem(Item item)
    {
        UpdateSlot(uIItems.FindIndex(i => i.item == null), item);
    }

    public void RemoveItem(Item item)
    {
        UpdateSlot(uIItems.FindIndex(i => i.item == item), null);
    }




    //end of class
}
