using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DAVID RICHMAN

public class SwarmMember : MonoBehaviour
{
    public float speed = 0.2f;
    public float maxSpeed = 8;
    //public float lerpConstant = 0.9f;
    public float pathRadius = 2f;
    public float pathIntolerance = 4f;
    public Vector3 relativePos = Vector3.zero;
    public float jitterMag = 0.1f;

    public Vector2 direction = Vector2.zero;
    private Vector3 jitter = Vector3.zero;
    private GameObject swarm;
    // Start is called before the first frame update
    void Start()
    {
        relativePos = new Vector3(Random.Range(-pathRadius, pathRadius), Random.Range(-pathRadius, pathRadius));
        swarm = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 path = swarm.transform.position - (this.transform.position + relativePos);
        direction = new Vector2(path.x, path.y);
        if (direction.magnitude < pathRadius / pathIntolerance)
        {
            relativePos = new Vector3(Random.Range(-pathRadius, pathRadius), Random.Range(-pathRadius, pathRadius));
        }
        Vector3 newPostion = new Vector3(speed * direction.x * Time.deltaTime, speed * direction.y * Time.deltaTime, 0);
        this.transform.position += newPostion;
    }
}
