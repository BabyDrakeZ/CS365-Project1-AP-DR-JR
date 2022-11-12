using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public enum AIType { vector, delta, evade, hopper, none };
    public AIType aiType = AIType.none;
    public float speed = 1;
    public float actualSpeed = 1;
    public float lerpConstant = 0.9f;
    private GameObject target;
    private string name;
    // Start is called before the first frame update
    void Start()
    {
        name = "AIEnemy_" + Time.time.ToString();
        target = GameObject.FindGameObjectWithTag("Player");
        if (target == null)
            Debug.Log("AI::Start couldn't find player" + name.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        actualSpeed = Mathf.Lerp(actualSpeed, speed, lerpConstant);
        Vector2 temp = actualSpeed * ProcessAI() * Time.deltaTime;
        transform.position += new Vector3(temp.x, temp.y, 0);
    }

    Vector3 ProcessAI()
    {
        Vector3 rawDir = target.transform.position - this.transform.position;
        Vector2 dir = new Vector2(rawDir.x, rawDir.y);
        switch (aiType)
        {
            case AIType.none:
                break;
            case AIType.vector:
                dir = VectorTrack(dir);
                break;
            case AIType.delta:
                dir = deltaTrack(dir);
                break;
            case AIType.evade:
                dir = Evade(dir);
                break;
            case AIType.hopper:
                HopperMove hopMove = GetComponent<HopperMove>();
                dir = hopMove.RandomMovement(dir);
                StartCoroutine(hopMove.Hop());
                //returnDir = wayPoints.findClosest();
                //returnDir = wayPoints.evaluateWaypoint();
                break;
            default:
                break;
        }
        if (Mathf.Abs(dir.x) < 0.5)
            dir.x = 0;
        if (Mathf.Abs(dir.y) < 0.5)
            dir.y = 0;
        return dir;
    }
    private Vector2 VectorTrack(Vector3 rawDirection)
    {
        Vector2 temp = new Vector2(rawDirection.x, rawDirection.y);
        temp.Normalize();
        return temp;
    }
    private Vector2 deltaTrack(Vector3 rawDirection)
    {
        Vector2 temp = Vector2.zero;
        float deltaX = target.transform.position.x - transform.position.x;
        float deltaY = target.transform.position.y - transform.position.y;

        float threshold = 0.1f;
        if (deltaX > threshold)
        {
            temp.x = 1;
        }
        else if (deltaX < -threshold)
        {
            temp.x = -1;
        }
        else if (deltaY > threshold)
        {
            temp.y = 1;
        }
        else if (deltaY < -threshold)
        {
            temp.y = -1;
        }
        float dist = rawDirection.magnitude;
        if (dist < 2)
            speed *= 2f / 3f;
        else
            speed = 5;
        return temp;
    }
    private Vector2 Evade(Vector3 rawDirection)
    {
        Vector2 temp = Vector2.zero;
        float distance = rawDirection.magnitude;
        if (distance < 2)
        {
            temp = -1 * VectorTrack(rawDirection);
            return temp;
        }
        else if (distance > 3f)
        {
            temp = VectorTrack(rawDirection);
        }
        return temp;
    }

}
