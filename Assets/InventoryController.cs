using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject slotPrefab;
    public int numberOfSlots = 24;

    private PlayerInventory playerInventory;

    void Start()
    {
        playerInventory = FindAnyObjectByType<PlayerInventory>();
        RefreshUI();
    }

    public void RefreshUI()
    {
        foreach (Transform child in inventoryPanel.transform)
            Destroy(child.gameObject);

        for (int i = 0; i < numberOfSlots; i++)
        {
            slot slot = Instantiate(slotPrefab, inventoryPanel.transform).GetComponent<slot>();

            if (i < playerInventory.items.Count)
            {
                // Create item UI object
                GameObject itemUI = new GameObject("ItemUI", typeof(RectTransform), typeof(Image), typeof(CanvasGroup), typeof(ItemDragHandler));

                itemUI.transform.SetParent(slot.transform);
                itemUI.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

                // Set sprite
                itemUI.GetComponent<Image>().sprite = playerInventory.items[i].icon;

                // Register item in slot
                slot.currentItem = itemUI;
            }
        }
    }
}


