using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject Food;
    public GameObject swarm;
    public int numFood = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numFood < 5)
            StartCoroutine(spawnFood());
    }
    IEnumerator spawnFood()
    {
        numFood++;
        yield return new WaitForSeconds(Random.Range(2, 10));
        Vector2 distance;
        do
            {
                int x = Random.Range(-10, 10);
                int y = Random.Range(-6, 6);
                distance = new Vector2(x - swarm.transform.position.x, y - swarm.transform.position.y);
            } while (distance.magnitude < 3);
        GameObject instance = Instantiate(Food);
        instance.transform.position = new Vector3(distance.x, distance.y, 0);
        Food food = instance.GetComponent<Food>();
        food.manager = this;
    }
}
