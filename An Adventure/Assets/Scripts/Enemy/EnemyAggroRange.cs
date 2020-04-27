using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroRange : MonoBehaviour
{
    private bool targetInRange = false;

    public bool isTargetInRange()
    {
        return targetInRange;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            targetInRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            targetInRange = false;
        }
    }
}
