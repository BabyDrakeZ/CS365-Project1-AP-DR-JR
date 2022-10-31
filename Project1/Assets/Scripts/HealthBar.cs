using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float lerpConstant = 0.99f;

    private Image healthBar;
    private float maximum;
    private float fill;

    void Start()
    {
        fill = Constants.C.health / 2;
        healthBar = GetComponent<Image>();
        maximum = Constants.C.health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Constants.C.health == 0)
        {
            fill = 0;
            //gameOver
            return;
        }
        fill = Mathf.Lerp(fill, Constants.C.health, lerpConstant);
        try
        {
            healthBar.fillAmount = fill / maximum;
        } catch
        {
            healthBar = GetComponent<Image>();
        }
            
    }
}
