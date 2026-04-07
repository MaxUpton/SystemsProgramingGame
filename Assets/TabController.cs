using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    public Image[] tabImages; // Array of tab images to control
    public GameObject[] pages; // Array of pages corresponding to each tab
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActivateTab(0); // Activate the first tab by default
    }

   
    public void ActivateTab(int tabNo)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
            tabImages[i].color = Color.grey; // Set all tabs to grey


        }
        pages[tabNo].SetActive(true); // Activate the selected page
        tabImages[tabNo].color = Color.white; // Set the selected tab to white
    }
}
