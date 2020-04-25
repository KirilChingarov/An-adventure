using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject controllsMenu;

    public void Awake()
    {
        Time.timeScale = 1f;
        Back();
    }

    public void Play()
    {
        SceneManager.LoadScene("UITestScene");
    }

    public void ControllsMenu()
    {
        controllsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Back()
    {
        controllsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
