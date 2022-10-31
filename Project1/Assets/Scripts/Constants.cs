using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    static public Constants C;
    public float health = 100;
    public int food = 50;
    public int foodUsed = 0;
    public int unitCost = 15;
    public float boundX = 50;
    public float boundY = 25;

    // Start is called before the first frame update
    void Start()
    {
        C = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int foodLeft()
    {
        return food - foodUsed;
    }
}
