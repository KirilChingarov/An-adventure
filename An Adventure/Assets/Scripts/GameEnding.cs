using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{ 
    void Update()
    {
        if(gameObject.transform.position.x >= 75 || gameObject.transform.position.y <= -5)
        {
            GameStateController.Instance.OnDie();
        }
    }
}
