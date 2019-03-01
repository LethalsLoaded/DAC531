using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // UI that will be displayed
    public GameObject inventoryUi;
    // All possible items in the game
    public List<Item> gameItems = new List<Item>();
    // List of items that are inside the inventory
    private List<Item> _inventoryItems = new List<Item>();
    // Needs to have an Image component - where sprite will be displayed
    public List<GameObject> inventorySlots = new List<GameObject>();

    public GameObject objectHoldTransform;

    UnityEvent onOpenInventoryEvent, onCloseInventoryEvent;

    // Opens the inventory
    public void DisplayInventory()
    {
        onOpenInventoryEvent.Invoke();
        inventoryUi.SetActive(true);
        Time.timeScale = 0;
    }

    // Closes the inventory
    public void CloseInventory()
    {
        onCloseInventoryEvent.Invoke();
        inventoryUi.SetActive(false);
        Time.timeScale = 1;
    }

    // Adds an item to the inventory
    public void AddItem(Item itemIn)
    {
        var slot = inventorySlots.FirstOrDefault(x=>x.GetComponent<Image>().sprite != null);
        if (slot == null) return; // Inventory is full.

        // Add new item
        slot.GetComponent<Image>().sprite = itemIn.itemImage;
        itemIn.inventorySlot = slot;
    }

    public void AddItem(string nameIn)
        => AddItem(GetItemByName(nameIn));

    // Removes item from the inventory by Sprite
    public void RemoveItemBySprite(Item itemIn)
    {
        var slot = inventorySlots.FirstOrDefault(x=>x.GetComponent<Image>().sprite == itemIn.itemImage);
        if(slot == null) return; // Item not in inventory.

        // Remove the items
        slot.GetComponent<Image>().sprite = null;
        itemIn.inventorySlot = null;
    }

    // Removes item from the inventory by name
    public void RemoveItem(Item itemIn)
    {
        var slot = _inventoryItems.FirstOrDefault(x=>x.itemName == itemIn.itemName).inventorySlot;
        if(slot == null) return;

        // Remove the items
        slot.GetComponent<Image>().sprite = null;
        itemIn.inventorySlot = null;
    }

    // Finds and item within the inventory
    public GameObject FindItem(Item itemIn)    
        =>  _inventoryItems.FirstOrDefault(x=>x.itemName == itemIn.itemName).inventorySlot;

    public GameObject FindItem(string itemIn)    
        =>  _inventoryItems.FirstOrDefault(x=>x.itemName == itemIn).inventorySlot;

    // Returns item by the name
    public Item GetItemByName(string nameIn)
        => gameItems.FirstOrDefault(x=>x.itemName == nameIn);

    // Returns item by the sprite
    public Item GetItemBySprite(Sprite spriteIn)
        => gameItems.FirstOrDefault(x=>x.itemImage == spriteIn);

    public void SpawnItem(Item itemIn)
    {
        if(!itemIn.canSpawnItem) return;
        if(objectHoldTransform.transform.childCount == 1)
        {
            objectHoldTransform.transform.GetChild(0).parent = null;
            gameObject.transform.parent = objectHoldTransform.transform;
            gameObject.transform.localPosition = Vector3.zero;
            return;
        }

        gameObject.transform.parent = objectHoldTransform.transform;
        gameObject.transform.localPosition = Vector3.zero;
    }
    
}
