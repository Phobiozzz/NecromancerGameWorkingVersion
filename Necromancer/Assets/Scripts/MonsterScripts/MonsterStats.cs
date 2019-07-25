using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{

    public string monsterName;

    public float monsterHp;
    public float monsterMp;
    public float damageTaken;


    void Death()
    {
        if (monsterHp <= 0)
        {
            
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        monsterName = transform.GetComponent<Transform>().name;
        monsterHp = 10f;
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        monsterHp -= collision.gameObject.GetComponent<PoisonArrow>().damage;
    }


  
    // Update is called once per frame
    void Update()
    {
        Death();
    }
}
