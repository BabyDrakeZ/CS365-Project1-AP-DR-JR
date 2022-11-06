using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DR
public class Enemy : MonoBehaviour
{
    public Manager manager;
    public float health = 50;
    public float attack = 5;
    public float attackSpeed = 1f;
    public float speed = 0.75f;
    public AudioSource hillAttack;
    private Vector3 direction;
    private bool stopMovement = false;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.zero - this.transform.position;
        if (direction != Vector3.zero)
        {
            direction.Normalize();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopMovement)
        {
            Vector3 newPostion = new Vector3(speed * direction.x * Time.deltaTime, speed * direction.y * Time.deltaTime, 0);
            this.transform.position += newPostion;
        }
        else {
            StartCoroutine(Attack());
        }
        
    }
    IEnumerator Attack()
    {
        direction = this.transform.position - Vector3.zero;
        if (direction != Vector3.zero)
        {
            direction.Normalize();
        }
        stopMovement = false;
        yield return new WaitForSeconds(attackSpeed);
        direction = Vector3.zero - this.transform.position;
        if (direction != Vector3.zero)
        {
            direction.Normalize();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "hill")
        {
            stopMovement = true;
            Constants.C.health -= attack;
            if (!hillAttack.isPlaying)
                hillAttack.PlayOneShot(hillAttack.clip, 0.5f);
        }
        if (obj.tag == "ant")
        {
            this.health -= 5;
            Destroy(obj);
        }
    }
}
