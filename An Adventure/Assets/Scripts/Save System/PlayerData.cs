using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float playerHealth;
    public float[] position = new float[3];

    public PlayerData(GameStateController controller)
    {
        playerHealth = controller.playerHealth;
        position = controller.playerPosition;
    }
}
