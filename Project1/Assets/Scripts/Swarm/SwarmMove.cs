using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DAVID RICHMAN

public class SwarmMove : MonoBehaviour
{
    public float speed = 3;
    public float maxSpeed = 15;
    public float lerpConstant = 0.8f;

    public GameObject antHill;

    public GameObject memberPrefab;

    private Queue<GameObject> swarm = new Queue<GameObject>();

    public Vector2 direction = Vector2.zero;
    private float localSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            addMember();
        }
        
    }

    //Instantiates a new member and adds it to the swarm
    public void addMember()
    {
        GameObject member = Instantiate(memberPrefab);
        member.transform.position = Vector3.zero;
        //member.transform.parent = this.transform;
        swarm.Enqueue(member);
    }
    public int Size()
    {
        return swarm.Count;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        localSpeed = Mathf.Clamp(localSpeed, 0, maxSpeed);
        localSpeed = Mathf.Lerp(localSpeed, 0, lerpConstant);
        Vector3 newPostion = new Vector3(localSpeed * direction.x * Time.deltaTime, localSpeed * direction.y * Time.deltaTime, 0);
        this.transform.position += newPostion;
    }

    void GetInput()
    {
        direction = Vector2.zero;
        bool blockMovingUp = this.transform.position.y > 25;
        bool blockMovingDown = this.transform.position.y < -25;
        bool blockMovingRight = this.transform.position.x < -50;
        bool blockMovingLeft = this.transform.position.x > 50;

        bool overloadX = (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow));
        bool overloadY = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.RightArrow));

        bool isMoving = false;

        //basic key handling
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !blockMovingUp)
        {
            direction.y = 1;
            isMoving = true;
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !blockMovingLeft)
        {
            direction.x = -1;
            isMoving = true;
        }
        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !blockMovingDown)
        {
            direction.y = -1;
            isMoving = true;
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !blockMovingRight)
        {
            direction.x = 1;
            isMoving = true;
        }
        //Check mash case: when a player presses oposite keys at once, must come after key basic key handling
        if (overloadX)
        {
            direction.x = 0;
        }
        if (overloadY)
        {
            direction.y = 0;
        }
        if (isMoving)
        {
            localSpeed += speed;
        }
        if (direction == Vector2.zero)
        {
            return;
        }
        direction.Normalize();
    }
}
