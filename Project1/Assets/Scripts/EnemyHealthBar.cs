using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public float lerpConstant = 0.02f;
    public GameObject parentObject;

    private Enemy enemy;

    private Image healthBar;
    private float fill;
    private float maximum;
    
    void Start()
    {
        enemy = parentObject.GetComponent<Enemy>();
        healthBar = GetComponent<Image>();
        fill = enemy.health / 2;
        maximum = enemy.health;

    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.health == 0)
        {
            //enemy.manager.gameOver();
            Destroy(parentObject);
            return;
        }
        fill = Mathf.Lerp(fill, enemy.health, lerpConstant);
        try
        {
            healthBar.fillAmount = fill/maximum;
        }
        catch
        {
            healthBar = GetComponent<Image>();
        }

    }
}
