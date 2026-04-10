using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    [Header("Starting Items (including keys)")]
    public List<ItemData> startingItems = new List<ItemData>();

    public List<ItemData> items = new List<ItemData>();

    private void Start()
    {
        foreach (var item in startingItems)
            items.Add(item);
    }

    public void AddItem(ItemData item)
    {
        items.Add(item);
    }

    public bool HasKey(string keyID)
    {
        return items.Exists(i => i.itemID == keyID);
    }
}




