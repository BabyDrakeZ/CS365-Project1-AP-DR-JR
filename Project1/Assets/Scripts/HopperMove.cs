using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopperMove : MonoBehaviour
{
    private AI AIclass;
    public GameObject target;

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
            float tiltX = Random.Range(-rawDir.magnitude / 4, rawDir.magnitude / 4);
            float tiltY = Random.Range(-rawDir.magnitude / 4, rawDir.magnitude / 4);
            //drift toward center
            dir = new Vector2(rawDir.x + tiltX, rawDir.x + tiltY);
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
        yield return new WaitForSeconds(0.5f);
        isTracking = false;
        isHopping = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject == target)
        {

        }
    }

}
