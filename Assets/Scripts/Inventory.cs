using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;
    public UIInventory inventoryUI;
    public int numberOfItems = 0;
    public int maxNumberOfItems;
    public float displayTime = 4.0f;
    public GameObject notifTextBox;
    public GameObject notifOverlay;
    float timerDisplay;
    Text notifText;
    private bool canTake;


    private void Start()
    {
        inventoryUI.gameObject.SetActive(false);
    
        maxNumberOfItems = inventoryUI.numberOfSlots;
        notifTextBox.SetActive(false);
        notifOverlay.SetActive(false);
        timerDisplay = -1.0f;
        notifText = notifTextBox.GetComponent<Text>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
        }

        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                notifOverlay.SetActive(false);
                notifTextBox.SetActive(false);
            }
        }
    }

    public void DisplayNotif()
    {
        timerDisplay = displayTime;
        notifOverlay.SetActive(true);
        notifTextBox.SetActive(true);
    }

    public void EditNotifText(string txt)
    {
        notifText.text = txt;
    }



    public void GiveItem(int id)
    {
        
        Item itemToAdd = itemDatabase.GetItem(id);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        numberOfItems++;
        DisplayNotif();
        EditNotifText("Added Item: " + itemToAdd.title + ",  number Of Items: " + numberOfItems);
        Debug.Log("Added Item: " + itemToAdd.title + ",  number O fItems: " + numberOfItems);

    }

    public void GiveItem(string itemName)
    {
        if (numberOfItems < 16)
        {

            canTake = true;
        }
        else
        {
            canTake = false; Debug.Log("didn't work");
        }
        if (canTake == true)
        {
            Item itemToAdd = itemDatabase.GetItem(itemName);
            characterItems.Add(itemToAdd);
            inventoryUI.AddNewItem(itemToAdd);
            numberOfItems++;
            DisplayNotif();
            EditNotifText(("Added Item: " + itemToAdd.title + "\nNumber Of Items: " + numberOfItems));
            Debug.Log("Added Item: " + itemToAdd.title + "\nNumber Of Items: " + numberOfItems);
        }
        else
        {
            DisplayNotif();
            EditNotifText(("Bag already full, can't carry any more."));
        }
    }


    public Item CheckForItem(int id)
    {
        return characterItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);
        if(itemToRemove != null)
        {
            characterItems.Remove(itemToRemove);
            inventoryUI.RemoveItem(itemToRemove);
            Debug.Log("Item removed: " + itemToRemove.title);
        }
    }




//end of class
}
