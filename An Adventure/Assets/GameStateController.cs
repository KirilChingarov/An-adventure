using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public string MainMenu = "MainMenu";
    public string DemoLevel = "DemoLevel";
    public GameObject mainMenu;
    public GameObject controllsMenu;
    public float playerHealth;
    public float gameOverDelay = 2.0f;
    public static GameStateController Instance { get; private set; }

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
    }

    public void OnTakeDamage(int damage)
    {
        playerHealth -= damage;
    }

    public void OnDie()
    {
        OnLoadMenu();
    }

    public void OnLoadGame()
    {
        mainMenu.SetActive(false);
        SceneManager.LoadScene("DemoLevel");
    }

    public void OnLoadMenu()
    {
        mainMenu.SetActive(true);
        SceneManager.LoadScene("MainMenu");
    }

    public void OnControllsMenu()
    {
        controllsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OnBack()
    {
        controllsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }
}
