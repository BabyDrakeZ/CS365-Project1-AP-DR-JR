using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ANTHONY POULIOT
public class Food : MonoBehaviour
{
    public Manager manager;
    public int foodVal = 10;
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
            manager.decrementNumFood();
            Destroy(this.gameObject);
        }
    }
}
