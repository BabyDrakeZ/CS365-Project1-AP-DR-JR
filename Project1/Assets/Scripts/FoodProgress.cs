using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FoodProgress : MonoBehaviour
{
    public float lerpConstant = 0.99f;
    private Image progress;
    private float fill = 1;
    // Start is called before the first frame update
    void Start()
    {
        progress = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Constants.C.foodLeft() == 0)
        {
            progress.fillAmount = 0.1f;
            return;
        }
        if (Constants.C.foodLeft() < fill)
        {
            fill = 0.05f;
        }
        fill = Mathf.Lerp(fill, Constants.C.foodLeft(), lerpConstant);
        progress.fillAmount = fill / Constants.C.unitCost;
    }
}
