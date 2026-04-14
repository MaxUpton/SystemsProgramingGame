using UnityEngine;
using TMPro;

public class PopupController : MonoBehaviour
{
    public static PopupController Instance;

    public GameObject popupPanel;
    public GameObject popupPanel2;
    public TMP_Text messageText;
    public TMP_InputField inputField;
    public TMP_InputField inputField2;
    public TMP_Text messageText2;
    
    private System.Action<string> onSubmit;
    private bool usingPopup2 = false;

    private void Awake()
    {
        Instance = this;
        popupPanel.SetActive(false);
        popupPanel2.SetActive(false);
        inputField.gameObject.SetActive(false);
        inputField2.gameObject.SetActive(false);
    }

    public void ShowInputPopup(string message, System.Action<string> callback)
    {
        messageText.text = message;
        popupPanel.SetActive(true);
        popupPanel2.SetActive(false);

        inputField.text = "";
        inputField.gameObject.SetActive(true);
        inputField.Select();
        inputField.ActivateInputField();

        onSubmit = callback;

        // ⭐ Pause the game
        Time.timeScale = 0f;
    }
    
    public void ShowInputPopup2(string message, System.Action<string> callback)
    {
        usingPopup2 = true;
        messageText2.text = message;
        popupPanel2.SetActive(true);
        popupPanel.SetActive(false);
        inputField2.text = "";
        inputField2.gameObject.SetActive(true);
        inputField2.Select();
        inputField2.ActivateInputField();

        onSubmit = callback;

        // ⭐ Pause the game
        Time.timeScale = 0f;
    }
    

    private void Update()
    {
        if (usingPopup2)
        {
            if (popupPanel2.activeSelf && inputField2.gameObject.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SubmitInput();
                }
            }
        }
        else
        {
            if (popupPanel.activeSelf && inputField.gameObject.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SubmitInput();
                }
            }
        }
        // if (popupPanel.activeSelf && inputField.gameObject.activeSelf || popupPanel2.activeSelf && inputField2.gameObject.activeSelf)
        // {
        //     if (Input.GetKeyDown(KeyCode.Return))
        //     {
        //         SubmitInput();
        //     }
        // }
    }

    public void SubmitInput()
    {
        string text = "";

        if (usingPopup2)
        {
            text = inputField2.text;
            inputField2.gameObject.SetActive(false);
            popupPanel2.SetActive(false);
            usingPopup2 = false;
        }
        else
        {
            text = inputField.text;
            inputField.gameObject.SetActive(false);
            popupPanel.SetActive(false);
        }

        inputField.gameObject.SetActive(false);
        popupPanel.SetActive(false);
        popupPanel2.SetActive(false);

        // ⭐ Unpause the game
        Time.timeScale = 1f;

        onSubmit?.Invoke(text);
    }
}

