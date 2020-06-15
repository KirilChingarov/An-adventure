using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
    public PlayerMovement player;

    public void freezePosition()
    {
        player.FreezeMovement();
    }

    public void unfreezePosition()
    {
        player.RenewMovement();
    }
}
