using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public enum PopupType
{
    TextInput,
    MessageOnly,
    MultipleChoice
}

public class PopupController : MonoBehaviour
{
    public static PopupController Instance;

    [Header("Main Popup Panel")]
    public GameObject popupPanel;

    [Header("Shared UI")]
    public TMP_Text messageText;
    public TMP_InputField inputField;

    [Header("Multiple Choice UI")]
    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    public Button buttonD;
    public TMP_Text buttonAText;
    public TMP_Text buttonBText;
    public TMP_Text buttonCText;
    public TMP_Text buttonDText;

    private PopupType activeType;
    private Action<string> onSubmit;

    private void Awake()
    {
        Instance = this;

        popupPanel.SetActive(false);
        inputField.gameObject.SetActive(false);

        buttonA.gameObject.SetActive(false);
        buttonB.gameObject.SetActive(false);
        buttonC.gameObject.SetActive(false);
        buttonD.gameObject.SetActive(false);
    }


    // Unified popup entry point

    public void ShowPopup(
        PopupType type,
        string message,
        Action<string> callback = null,
        string a = null, string b = null, string c = null, string d = null)
    {
        activeType = type;
        onSubmit = callback;

        popupPanel.SetActive(true);

        // Reset UI
        inputField.gameObject.SetActive(false);
        buttonA.gameObject.SetActive(false);
        buttonB.gameObject.SetActive(false);
        buttonC.gameObject.SetActive(false);
        buttonD.gameObject.SetActive(false);

        messageText.text = message;

        switch (type)
        {
            case PopupType.TextInput:
                inputField.text = "";
                inputField.gameObject.SetActive(true);
                inputField.Select();
                inputField.ActivateInputField();
                break;

            case PopupType.MessageOnly:
                break;

            case PopupType.MultipleChoice:
                SetupChoiceButtons(a, b, c, d);
                break;
        }

        Time.timeScale = 0f;
    }

    /// Helper to setup multiple choice buttons
    private void SetupChoiceButtons(string a, string b, string c, string d)
    {
        buttonA.gameObject.SetActive(true);
        buttonB.gameObject.SetActive(true);
        buttonC.gameObject.SetActive(true);
        buttonD.gameObject.SetActive(true);

        buttonAText.text = a;
        buttonBText.text = b;
        buttonCText.text = c;
        buttonDText.text = d;

        buttonA.onClick.RemoveAllListeners();
        buttonB.onClick.RemoveAllListeners();
        buttonC.onClick.RemoveAllListeners();
        buttonD.onClick.RemoveAllListeners();

        buttonA.onClick.AddListener(() => SubmitChoice(a));
        buttonB.onClick.AddListener(() => SubmitChoice(b));
        buttonC.onClick.AddListener(() => SubmitChoice(c));
        buttonD.onClick.AddListener(() => SubmitChoice(d));
    }

    //submit for text input
    public void SubmitInput()
    {
        if (activeType != PopupType.TextInput)
            return;

        string text = inputField.text;
        ClosePopup();
        onSubmit?.Invoke(text);
    }

    //submit for multiple choice
    private void SubmitChoice(string choice)
    {
        ClosePopup();
        onSubmit?.Invoke(choice);
    }

    // Common close logic
    private void ClosePopup()
    {
        popupPanel.SetActive(false);
        inputField.gameObject.SetActive(false);

        buttonA.gameObject.SetActive(false);
        buttonB.gameObject.SetActive(false);
        buttonC.gameObject.SetActive(false);
        buttonD.gameObject.SetActive(false);

        Time.timeScale = 1f;
    }

    // Listen for Enter key in text input mode
    private void Update()
    {
        if (activeType == PopupType.TextInput &&
            popupPanel.activeSelf &&
            inputField.gameObject.activeSelf &&
            Input.GetKeyDown(KeyCode.Return))
        {
            SubmitInput();
        }
    }
}

