using UnityEngine;

public class QuestionInteractable : MonoBehaviour
{
    public string question = "What is your favorite color?";
    public ItemData rewardItem;

    public string userAnswer;

    public enum QuestionType
    {
        TextInput,
        MultipleChoice,
        MessageOnly
    }

    public QuestionType questionType = QuestionType.TextInput;

    [Header("Multiple Choice Options")]
    public string choiceA;
    public string choiceB;
    public string choiceC;
    public string choiceD;

    private bool playerInRange = false;
    private bool isPopupOpen = false;

    private void OnTriggerEnter2D(Collider2D other) 
    { 
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }


    private void Update()
    {
        if (!playerInRange || isPopupOpen)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            isPopupOpen = true;

            switch (questionType)
            {
                case QuestionType.TextInput:
                    PopupController.Instance.ShowPopup(
                        PopupType.TextInput,
                        question,
                        OnAnswerSubmitted
                    );
                    break;

                case QuestionType.MultipleChoice:
                    PopupController.Instance.ShowPopup(
                        PopupType.MultipleChoice,
                        question,
                        OnAnswerSubmitted,
                        choiceA, choiceB, choiceC, choiceD
                    );
                    break;

                case QuestionType.MessageOnly:
                    PopupController.Instance.ShowPopup(
                        PopupType.MessageOnly,
                        question
                    );
                    isPopupOpen = false;
                    break;
            }
        }
    }

    private void OnAnswerSubmitted(string answer)
    {
        isPopupOpen = false;

        if (questionType == QuestionType.MessageOnly)
            return;

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