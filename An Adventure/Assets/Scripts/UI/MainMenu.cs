using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Time.timeScale = 1f;
    }

    public void Play()
    {
        GameStateController.Instance.OnLoadGame();
    }

    public void LoadGame()
    {
        GameStateController.Instance.OnLoad();
    }

    public void ControllsMenu()
    {
        GameStateController.Instance.OnControllsMenu();
    }

    public void Quit()
    {
        GameStateController.Instance.OnQuitGame();
    }

    public void Back()
    {
        GameStateController.Instance.OnBack();
    }
}
