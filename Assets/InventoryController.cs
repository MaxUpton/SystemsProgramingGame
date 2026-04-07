using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel; // The panel that contains the inventory UI
    public GameObject slotPrefab;
    public GameObject[] itemPrefab;
    public int numberOfSlots; // Number of inventory slots
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            slot slot = Instantiate(slotPrefab, inventoryPanel.transform).GetComponent<slot>();
            if (i < itemPrefab.Length)
            {
                GameObject item = Instantiate(itemPrefab[i], slot.transform);
                item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Center the item in the slot
                slot.currentItem = item; // Assign the item to the slot
            }
        }
    }

    
}
