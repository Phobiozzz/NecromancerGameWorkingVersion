using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{

    public string monsterName;

    public float monsterHp;
    public float monsterMp;
    public float damageTaken;
    public bool isDead;
    public GameObject drop;

    void Death()
    {
        
        if (monsterHp <= 0)
        {
            isDead = true;
            Debug.Log(isDead);
            Destroy(gameObject);
        }

    }

    public void OnDestroy()
    {
        Instantiate(drop, transform.position, drop.transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        monsterName = transform.GetComponent<Transform>().name;
        monsterHp = 10f;
        isDead = false;
       
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
