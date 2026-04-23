using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class InteractableKeyDoor : MonoBehaviour
{
    public KeyDoorBehavior behavior;

    private SpriteRenderer sr;
    private Collider2D col;
    private bool isOpen = false;
    private bool playerInRange = false;
    private GameObject currentPlayer;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            currentPlayer = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            currentPlayer = null;
        }
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
    private void Update()
    {
        if (!playerInRange || isOpen)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact(currentPlayer);
        }
    }

}

