using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName = "Item name";
    public Sprite itemImage;
    public string itemDescription = "Item description";
    public GameObject inventorySlot;
    public bool canSpawnItem = false;
    public GameObject itemPrefab;
}
