using UnityEngine;

public class QuestionInteractable : MonoBehaviour
{
    public string question = "test change of message";
    public ItemData rewardItem;

    public string userawnser;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            PopupController.Instance.ShowInputPopup(question, OnAnswerSubmitted);
        }
    }

    private void OnAnswerSubmitted(string answer)
    {
        PlayerInventory playerInventory = FindAnyObjectByType<PlayerInventory>();
        Debug.Log("Player answered: " + answer);

        if (answer.ToLower() == userawnser.ToLower())
        {
            Debug.Log("Correct answer!");
            // Do something: open door, give item, etc.
            if (rewardItem != null)
            {
                playerInventory.items.Add(rewardItem);
                
            }
        }
        else
        {
            Debug.Log("Incorrect answer.");
        }
        FindAnyObjectByType<InventoryController>().RefreshUI();

    }
}



