using UnityEngine;

public class QuestionInteractable : MonoBehaviour
{
    public string question = "What is your favorite color?";
    public ItemData rewardItem;

    public string userAnswer;

    public bool isMultipleChoice = false;
    public string choiceA;
    public string choiceB;
    public string choiceC;
    public string choiceD;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (isMultipleChoice)
            {
                PopupController.Instance.ShowPopup(
                    PopupType.MultipleChoice,
                    question,
                    OnAnswerSubmitted,
                    choiceA, choiceB, choiceC, choiceD
                );
            }
            else
            {
                PopupController.Instance.ShowPopup(
                    PopupType.TextInput,
                    question,
                    OnAnswerSubmitted
                );
            }
        }
    }

    private void OnAnswerSubmitted(string answer)
    {
        PlayerInventory playerInventory = FindAnyObjectByType<PlayerInventory>();
        Debug.Log("Player answered: " + answer);

        if (answer.ToLower().Trim() == userAnswer.ToLower().Trim())
        {
            Debug.Log("Correct answer!");

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
