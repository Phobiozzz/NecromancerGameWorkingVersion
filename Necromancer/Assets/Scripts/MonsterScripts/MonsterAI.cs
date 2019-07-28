using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public string monsterName;
    public float speed;
    public float damage;
    public float attackSpeed;
    public float attackCD;
    public bool canAttack;

    public Transform target;

    float distance;

    private void Follow()
    {

        if (distance < 2 && distance > 0.3)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }


    private void Attack()
    {

        if (attackCD < 0)
        {
            canAttack =true;
        }
        if (distance < 0.4f && canAttack == true)
        {
            target.transform.GetComponent<HeroStats>().Hit(damage);
            canAttack = false;
            attackCD = attackSpeed;
        }
        else
        {
            attackCD -= 1f * Time.deltaTime;
        }

    }


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        name = transform.name;
        damage = 3f;
        canAttack = true;
        attackSpeed = 3f;
    }

    private void Update()
    {

        distance = Vector2.Distance(transform.position, target.position);
        Follow();
        Attack();
        
    }
}
