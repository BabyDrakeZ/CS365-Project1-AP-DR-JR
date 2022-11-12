using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopperMove : MonoBehaviour
{
    private AI AIclass;

    public float hopStrength = 50f;
    public float hopDuration = 0.25f;

    private bool isHopping = false;
    private bool isTracking = false;
    private Vector2 dir = Vector2.zero;

    private void Start()
    {
        AIclass = GetComponent<AI>();
    }

    // Start is called before the first frame update
    public Vector2 RandomMovement(Vector2 rawDir)
    {
        if (isTracking)
        {
            int rand = Random.Range(0, 2);
            if (rand == 0) rand = -1;
            //drift toward center
            dir = rawDir + rand*Vector2.Perpendicular(rawDir)/2;
            if (dir != Vector2.zero)
                dir.Normalize();
        }
        return dir;
        
    }


    public IEnumerator Hop()
    {
        if (!isHopping)
        {
            isHopping = true;
            AIclass.speed += hopStrength;
            yield return new WaitForSeconds(hopDuration);
            AIclass.speed -= hopStrength;
            StartCoroutine(Hold());
        }
        else
            yield return new WaitForEndOfFrame();
    }
    IEnumerator Hold()
    {
        isTracking = true;
        yield return new WaitForSeconds(Random.Range(hopDuration/2f, hopDuration));
        isTracking = false;
        isHopping = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
    }

}
