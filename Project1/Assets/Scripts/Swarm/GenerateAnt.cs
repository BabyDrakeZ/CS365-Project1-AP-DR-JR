using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//DAVID RICHMAN
public class GenerateAnt : MonoBehaviour
{
    public GameObject swarm;
    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Constants.C.foodLeft() >= Constants.C.unitCost)
        {
            StartCoroutine(Spawn());
        }
    }
    IEnumerator Spawn()
    {
        Constants.C.foodUsed += Constants.C.unitCost;
        yield return new WaitForSeconds(Random.Range(2, 5));
        SwarmMove data = swarm.GetComponent<SwarmMove>();
        data.addMember(spawnPoint.transform.position);
    }
}
