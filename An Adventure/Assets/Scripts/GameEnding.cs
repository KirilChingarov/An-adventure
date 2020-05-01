using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if(player.position.x >= 65 || player.position.y <= -5)
        {
            GameStateController.Instance.OnDie();
        }
    }
}
