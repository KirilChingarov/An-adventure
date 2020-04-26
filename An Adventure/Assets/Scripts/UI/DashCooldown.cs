using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCooldown : MonoBehaviour
{
    private HealthBar slider;
    public Dash dash;

    private void Start()
    {
        slider = GetComponent<HealthBar>();
    }

    void Update()
    {
        slider.setHealth(3 - dash.dashCooldown);
    }
}
