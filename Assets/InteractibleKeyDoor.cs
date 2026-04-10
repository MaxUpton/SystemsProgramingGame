using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class InteractableKeyDoor : MonoBehaviour
{
    public KeyDoorBehavior behavior;

    private SpriteRenderer sr;
    private Collider2D col;
    private bool isOpen = false;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    public void Interact(GameObject interactor)
    {
        if (isOpen) return;

        PlayerInventory inv = interactor.GetComponent<PlayerInventory>();
        if (inv == null)
        {
            Debug.Log("Interactor has no inventory.");
            return;
        }

        // Check key
        if (!inv.HasKey(behavior.requiredKeyID))
        {
            Debug.Log("Door locked. Missing key: " + behavior.requiredKeyID);
            return;
        }

        // Open door
        col.enabled = false;
        sr.color = behavior.openedColor;
        gameObject.layer = behavior.openedLayer;

        isOpen = true;

        Debug.Log("Door opened with key: " + behavior.requiredKeyID);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<InteractableKeyDoor>().Interact(other.gameObject);
        }
    }

}

