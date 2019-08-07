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

    Vector3 monsterPosition;

    public Transform target;
    public Transform groundDetector;
    public LayerMask layermask;
    public LayerMask monsterMask;

    float distance;
    public bool stopFollowing;

    public bool Stop()
    {
       // print("Started To GroundChek");
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetector.position, Vector2.down, 3.2f, layermask);
        RaycastHit2D monsterInfo = Physics2D.Raycast(groundDetector.position, Vector2.left, 0.001f, monsterMask);
        //Debug.DrawRay(groundDetector.position, Vector2.left, Color.red, 0.01f);
        if (groundInfo.collider == false || monsterInfo.collider == true)
        {
            //print("There is no ground !!!!!");
            return true;
        }
        

        
        //print("There is a ground here!");
        return false;
    }

    private void Follow()
    {
        bool shouldIstop = false;
        shouldIstop = Stop();
        if (shouldIstop != true )
        {
            if (distance < 2 && distance > 0.3)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                
            }
        }
        if (transform.position.x < target.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
       

        if (collision.gameObject.tag == "Minion")
        {
            target = collision.gameObject.GetComponent<Transform>();
            target.GetComponent<RiseSkeleton>().TakeDamage(damage);

        }



    }

   

    private void Attack()
    {

        if (attackCD < 0)
        {
            attackCD = 0;
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

   

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        monsterPosition = transform.position;
        stopFollowing = false;
        name = transform.name;
        damage = 3f;
        canAttack = true;
        attackSpeed = 3f;
    }

   
    private void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        distance =Mathf.Abs(Vector2.Distance(transform.position, target.position));
        Stop();
        Follow();
        Attack();
        
        
    }

    
}
