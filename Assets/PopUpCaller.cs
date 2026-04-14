using UnityEngine;

public class QuestionInteractable : MonoBehaviour
{
    public string question = "What is your favorite color?";
    public ItemData rewardItem;

    public string userawnser;

    public bool isRoom2Console = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (isRoom2Console)
            {
                PopupController.Instance.ShowInputPopup2(question, OnAnswerSubmitted);
            }
            else
            {
                PopupController.Instance.ShowInputPopup(question, OnAnswerSubmitted);
            }
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



