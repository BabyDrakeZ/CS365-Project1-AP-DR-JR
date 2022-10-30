using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAnt : MonoBehaviour
{
    public int foodCost = 10;
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
        if(Constants.C.food >= foodCost)
        {
            StartCoroutine(Spawn());
        }
    }
    IEnumerator Spawn()
    {
        Constants.C.food -= foodCost;
        yield return new WaitForSeconds(Random.Range(2, 10));
        SwarmMove data = swarm.GetComponent<SwarmMove>();
        data.addMember(spawnPoint.transform.position);
    }
}
