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
    public GameObject player;
    public float playerHealth;
    public float[] playerPosition = new float[3];
    public float gameOverDelay = 2.0f;
    public bool loaded;
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

    public void OnSave()
    {
        player = GameObject.FindWithTag("Player");
        playerPosition[0] = player.transform.position.x;
        playerPosition[1] = player.transform.position.y;
        playerPosition[2] = player.transform.position.z;
        SaveSystem.SavePlayer(this);
    }

    public void OnLoad()
    {
        if (SaveSystem.LoadPlayer() != null)
        {
            playerHealth = SaveSystem.LoadPlayer().playerHealth;
            playerPosition[0] = SaveSystem.LoadPlayer().position[0];
            playerPosition[1] = SaveSystem.LoadPlayer().position[1];
            playerPosition[2] = SaveSystem.LoadPlayer().position[2];
            loaded = true;
            OnLoadGame();
        }
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }
}
