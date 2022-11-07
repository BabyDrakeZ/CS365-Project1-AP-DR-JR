using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//David Richman

public class Constants : MonoBehaviour
{
    static public Constants C;
    public float health = 100;
    private float maxHealth; //^
    public int food = 50;
    public int foodUsed = 0;
    public int unitCost = 15;
    public float boundX = 50;
    public float boundY = 25;

    // Start is called before the first frame update
    void Start()
    {
        C = this;
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }
    public int foodLeft()
    {
        return food - foodUsed;
    }
    public Vector3 notTouching(GameObject obj, float worldBounds = 0.5f)
    {
        //Anthony
        float x = 5;
        float y = 5;
        Vector3 distance = Vector3.zero;
        do
        {
            x = Random.Range(-Constants.C.boundX * worldBounds, Constants.C.boundX * worldBounds);
            y = Random.Range(-Constants.C.boundY * worldBounds, Constants.C.boundY * worldBounds);
            distance = new Vector2(x - obj.transform.position.x, y - obj.transform.position.y);
        } while (distance.magnitude < 3);
        return new Vector3(x, y, 0);
    }
    public Vector3 notTouching(GameObject[] gameObjects, float worldBounds = 0.5f)
    {
        //David (extending notTouching)
        int tries = 0;
        float[] magnitudes = new float[gameObjects.Length];
        Vector3 pos = Vector3.zero;
        float x = Random.Range(-Constants.C.boundX * worldBounds, Constants.C.boundX * worldBounds);
        float y = Random.Range(-Constants.C.boundY * worldBounds, Constants.C.boundY * worldBounds);
        do
        {
            tries++;
            x = Random.Range(-Constants.C.boundX * worldBounds, Constants.C.boundX * worldBounds);
            y = Random.Range(-Constants.C.boundY * worldBounds, Constants.C.boundY * worldBounds);
            for (int i = 0; i < gameObjects.Length; i++)
            {
                GameObject obj = gameObjects[i];
                pos = new Vector3(x - obj.transform.position.x, y - obj.transform.position.y, 0);
                magnitudes[i] = pos.magnitude;
            }
        } while (Mathf.Max(magnitudes) < 3 && tries < 100);
        return new Vector3(x, y, 0);
    }
}
