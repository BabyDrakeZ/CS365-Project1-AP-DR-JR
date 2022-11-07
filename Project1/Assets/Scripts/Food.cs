using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ANTHONY POULIOT
public class Food : MonoBehaviour
{
    public Manager manager;
    public int foodVal = 10;
    public int healthVal = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.tag == "ant")
        {
            Constants.C.food += foodVal; 
            //DR added health replenishment
            if (Constants.C.health + healthVal <= Constants.C.getMaxHealth())
                Constants.C.health += healthVal;
            else
                Constants.C.health = Constants.C.getMaxHealth();
            manager.DecrementNumFood();
            Destroy(this.gameObject);
        }
    }
}
