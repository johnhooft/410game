using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Button startButton;
    public Button creditsButton;
    public Button backButton;

    public GameObject mainMenu;
    public GameObject creditsMenu;

    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("StartUIButton").GetComponent<Button>();
        startButton.onClick.AddListener(() => GoToStart());

        creditsButton = GameObject.Find("CreditsUIButton").GetComponent<Button>();
        creditsButton.onClick.AddListener(() => GoToCredits());

        backButton = GameObject.Find("BackUIButton").GetComponent<Button>();
        backButton.onClick.AddListener(() => GoBackToMain());

        creditsMenu.SetActive(false);
    }

    void Destroy()
    {
        startButton.onClick.RemoveListener(() => GoToStart());
        creditsButton.onClick.RemoveListener(() => GoToCredits());
        backButton.onClick.RemoveListener(() => GoBackToMain());
    }

    void GoToStart() { SceneManager.LoadScene(0); }

    void GoBackToMain()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    void GoToCredits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

}
