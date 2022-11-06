using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//DAVID RICHMAN
public class GenerateAnt : MonoBehaviour
{
    public GameObject swarm;
    public GameObject spawnPoint;
    public AudioSource spawnSound;
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
        yield return new WaitForSeconds(Random.Range(0, 3));
        SwarmMove data = swarm.GetComponent<SwarmMove>();
        data.addMember(spawnPoint.transform.position);
        if (!spawnSound.isPlaying)
            spawnSound.PlayOneShot(spawnSound.clip, 0.25f);
    }
}
