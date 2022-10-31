using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float attack;
    public float speed;
    private Vector3 direction;
    private bool stopMovement = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopMovement)
        {
            direction = Vector3.zero - this.transform.position;
            if (direction != Vector3.zero)
            {
                direction.Normalize();
            }
            Vector3 newPostion = new Vector3(speed * direction.x * Time.deltaTime, speed * direction.y * Time.deltaTime, 0);
            this.transform.position += newPostion;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Hill")
        {
            stopMovement = true;
            AntHillStatus.C.health -= attack;
        }
        if (obj.tag == "ant")
        {
            this.health -= 1;
            Destroy(obj);
        }
    }
}
