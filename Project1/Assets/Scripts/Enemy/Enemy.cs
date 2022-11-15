using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DR
public class Enemy : MonoBehaviour
{
    public Manager manager;
    public float health = 50;
    public float attack = 5;
    public float attackSpeed = 1f;
    public AudioSource hillAttack;
    private bool attacking = false;
    private AI ai;
    private AI.AIType initAI;
    public ParticleSystem strikeEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<AI>();
        initAI = ai.aiType;
    }

    // Update is called once per frame
    IEnumerator Attack()
    {
        Constants.C.health -= attack;
        if (!hillAttack.isPlaying)
            hillAttack.PlayOneShot(hillAttack.clip, 0.5f);
        if (!strikeEffect.isPlaying)
        {
            strikeEffect.Play();
        }
        yield return new WaitForSeconds(attackSpeed);
        attacking = false;
        ai.aiType = initAI;
    }
    private void Update()
    {
        if (health < 0)
        {
            Destroy(gameObject);
            manager.DecrementNumEnemies();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "hill" && !attacking)
        {
            attacking = true;
            ai.aiType = AI.AIType.none;
            StartCoroutine(Attack());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "ant")
        {
            ai.aiType = AI.AIType.none;
            StartCoroutine(Attack());
            health -= 2 + obj.GetComponentInParent<SwarmMove>().CollectiveDamage();
            Destroy(obj);
            Debug.Log(health.ToString());
        }
        if (obj.tag == "food")
        {
            Destroy(obj);
        }
    }
}
