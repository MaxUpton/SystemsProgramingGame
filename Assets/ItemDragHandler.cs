using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform originalParent;
    CanvasGroup canvasGroup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent; // Store the original parent of the item
        transform.SetParent(transform.root); // Move the item to the root of the hierarchy to ensure it is on top of other UI elements
        canvasGroup.blocksRaycasts = false; // Disable raycast blocking to allow the item to be dragged over other UI elements
        canvasGroup.alpha = 0.6f; // Make the item semi-transparent while dragging
    }

    public void OnDrag(PointerEventData eventData)
    {
       transform.position = eventData.position; // Move the item to follow the mouse cursor

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // Re-enable raycast blocking
        canvasGroup.alpha = 1f; // Restore the item's opacity

        slot dropslot = eventData.pointerEnter?.GetComponent<slot>(); // Check if the item was dropped on a slot
        if (dropslot == null)
        {
            GameObject item = eventData.pointerEnter; // Get the GameObject that the item was dropped on
            if (item != null)
            {
                dropslot = item.GetComponentInParent<slot>(); // Check if the parent of the dropped GameObject is a slot
            }

        }
        slot originalSlot = originalParent.GetComponent<slot>(); // Get the original slot of the item
        if (dropslot != null)
        {
            if (dropslot.currentItem != null)// Check if the drop slot already has an item
            {
                dropslot.currentItem.transform.SetParent(originalSlot.transform); // Move the existing item back to the original slot
                originalSlot.currentItem = dropslot.currentItem; // Update the original slot to reference the existing item
                dropslot.currentItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Center the existing item in the original slot

            }
            else
            {
                originalSlot.currentItem = null; // Clear the original slot's reference to the item
            }
            transform.SetParent(dropslot.transform); // Move the dragged item to the new slot
            dropslot.currentItem = gameObject; // Update the new slot to reference the dragged item
        }

        else
        {
            // If the item was not dropped on a slot, return it to its original position
            transform.SetParent(originalParent); // Move the item back to its original parent
            

        }
        GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Center the item in its new slot or original slot


    }

  

   
}
