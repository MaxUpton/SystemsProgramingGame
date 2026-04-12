using UnityEngine;
using TMPro;

public class PopupController : MonoBehaviour
{
    public static PopupController Instance;

    public GameObject popupPanel;
    public TMP_Text messageText;
    public TMP_InputField inputField;

    private System.Action<string> onSubmit;

    private void Awake()
    {
        Instance = this;
        popupPanel.SetActive(false);
        inputField.gameObject.SetActive(false);
    }

    public void ShowInputPopup(string message, System.Action<string> callback)
    {
        messageText.text = message;
        popupPanel.SetActive(true);

        inputField.text = "";
        inputField.gameObject.SetActive(true);
        inputField.Select();
        inputField.ActivateInputField();

        onSubmit = callback;

        // ⭐ Pause the game
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (popupPanel.activeSelf && inputField.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SubmitInput();
            }
        }
    }

    public void SubmitInput()
    {
        string text = inputField.text;

        inputField.gameObject.SetActive(false);
        popupPanel.SetActive(false);

        // ⭐ Unpause the game
        Time.timeScale = 1f;

        onSubmit?.Invoke(text);
    }
}

