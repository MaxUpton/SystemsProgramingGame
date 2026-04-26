using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void startGame()
    {
        SceneManager.LoadScene("360Project");
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("main menu");
    }

    // Update is called once per frame
    public void endGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
