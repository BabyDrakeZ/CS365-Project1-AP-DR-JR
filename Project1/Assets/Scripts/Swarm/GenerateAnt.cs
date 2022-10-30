using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAnt : MonoBehaviour
{
    public int foodCost;
    public GameObject swarm;
    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        Constants.C.food = 50;
    }

    // Update is called once per frame
    void Update()
    {
        while(Constants.C.food > foodCost)
        {
            SwarmMove data = swarm.GetComponent<SwarmMove>();
            data.addMember(spawnPoint.transform.position);
        }
    }
}
