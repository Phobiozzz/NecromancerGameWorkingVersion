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
    public GameObject[] drop;
    private readonly System.Random random = new System.Random();
   
    void Death()
    {
        
        if (monsterHp <= 0)
        {
            isDead = true;
           
            GameObject dropItem = drop[random.Next(0, drop.Length)];
            Instantiate(dropItem, transform.position, dropItem.transform.rotation);

            Destroy(gameObject);
        }
       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeathZone")
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        monsterName = transform.GetComponent<Transform>().name;
        monsterHp = 10f;
        isDead = false;
       
    }



    public void TakeDamage(float dmg)
    {
        monsterHp -= dmg;
        Debug.Log("TakenDamage  " + dmg);
        Debug.Log("My Current Hp = " + monsterHp);
    }
  
    // Update is called once per frame
    void Update()
    {
        Death();
       
    }
}
