using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseSkeleton : MonoBehaviour
{
    public float damage;
    public float attackTime;
    public float attackCD;
    public bool Attack;

    public float speed = 1.5f;
    public float hp;

    public float lifeTime = 3f;

    public bool isAlive;



    public Transform target;
    public float distance;

    public void Awake()
    {
        Attack = false;
        damage = 3f;
        hp = 5;
        lifeTime = 5f;
        isAlive = true;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
       
    }

    public void Behaviour()
    {
        Vector3 minionPosition = transform.position;
        FindTargetAndFollow();
        Fight();
        BackToHell();
    }

    public void FindTargetAndFollow()
    {
        target = Target();
        distance = transform.position.x - target.position.x;
        if (distance < 0)
        {
            distance *= -1;

        }


        if (distance < 5 && distance > 0.3)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (distance <= 0.3)
        {
            //Debug.Log("PrepairingToAttack " + distance);
            Fight();
        }
        
        if (transform.position.x > target.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void Fight()
    {

        if (attackCD <= 0)
        {
            target.GetComponent<MonsterStats>().TakeDamage(damage);
            attackCD = 1f;
           // Debug.Log("Im attacked monster");
        }
        attackCD -= 1 * Time.deltaTime;
        
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
    }


    public void BackToHell()
    {
        if (hp <= 0)
        {
            hp = 0;
            Destroy(gameObject);
        }

        Destroy(gameObject, lifeTime);
        isAlive = false;
    }

    public Transform Target()
    {
        GameObject[] allTargets = GameObject.FindGameObjectsWithTag("Monster");
        Vector3 closestMonsterpPosition = allTargets[0].GetComponent<Transform>().position;
        int closestEnemyIndex = 0;

        for (int i = 1; i < allTargets.Length; i++)
        {
           int monsterIndex = i;
           Vector3 enemyPosition = allTargets[i].GetComponent<Transform>().position;
            if (Vector3.Distance(transform.position, enemyPosition) < Vector3.Distance(transform.position, closestMonsterpPosition))
            {
                closestMonsterpPosition = enemyPosition;
                closestEnemyIndex = monsterIndex;
            }
        }

        return allTargets[closestEnemyIndex].GetComponent<Transform>();

    }

    public void Update()
    {
        FindTargetAndFollow();
        BackToHell();

       
    }
}
