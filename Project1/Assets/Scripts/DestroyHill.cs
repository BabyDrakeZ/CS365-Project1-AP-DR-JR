using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHill : MonoBehaviour
{
    public Manager manager;
    public float speed = 1;
    private bool destroyed = false;
    public ParticleSystem dust;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.gameOver)
        {
            if (!destroyed)
            {
                destroyed = true;
                dust.Play();
            }
            this.gameObject.transform.position += Vector3.down * speed * Time.deltaTime;
        }  
    }
}
