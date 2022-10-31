using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float lerpConstant = 0.99f;

    private Image healthBar;
    private float fill;

    void Start()
    {
        fill = Constants.C.health / 2;
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Constants.C.health == 0)
        {
            fill = 0;
            return;
        }
        fill = Mathf.Lerp(fill, Constants.C.health, lerpConstant);
        try
        {
            healthBar.fillAmount = fill / Constants.C.health;
        } catch
        {
            healthBar = GetComponent<Image>();
        }
            
    }
}
