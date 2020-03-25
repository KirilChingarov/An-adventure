using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public Transform player;

    void Start()
    {

    }

    void Update()
    {
        if(player.position.x >= 65 || player.position.y <= -5)
        {
            Debug.Log("Game Over!");
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}
