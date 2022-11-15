using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//DR
public class EnemyHealthBar : MonoBehaviour
{
    public float lerpConstant = 0.02f;
    public GameObject parentObject;

    private Enemy enemy;

    private RectTransform healthBarTransform;
    private float maximum;
    private float fill;
    private float maxWidth;
    
    void Start()
    {
        healthBarTransform = GetComponent<RectTransform>();
        enemy = parentObject.GetComponent<Enemy>();
        maxWidth = healthBarTransform.rect.width;
        fill = enemy.health;
        maximum = enemy.health;

    }

    // Update is called once per frame
    void Update()
    {
        fill = Mathf.Lerp(fill, enemy.health, lerpConstant);
        healthBarTransform.sizeDelta = new Vector2((fill/maximum)*maxWidth, healthBarTransform.sizeDelta.y);

    }
}
