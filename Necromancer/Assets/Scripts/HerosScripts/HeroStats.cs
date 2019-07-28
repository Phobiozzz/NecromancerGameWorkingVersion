using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    public GameObject hero;
    
    public float Hp;
    private float Mp;
    public bool isAlive;

    private void Atack()
    {

    }

    public void Hit(float damage)
    {
        Hp -= damage;
    }

    private void Death()
    {
        if (Hp <= 0)
        {
            isAlive = false;
            Destroy(hero);
        }
        
        Debug.Log("Youre dead");
    }


    public float skulls;
    public float bones;
    public float pages;

    public void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Drop")
        {
            switch (other.name)
            {
                case "Skull(Clone)":
                    skulls++;
                    break;
                case "Bone(Clone)":
                    bones++;
                    break;
                case "SpellBookPage(Clone)":
                    pages++;
                    break;
            }

            Destroy(other.gameObject);
        }
        else if (other.tag == "DeathZone")
        {

            Hp = 0;
        }
        
    }


  

    // Start is called before the first frame update
    void Start()
    {
       
        Hp = 100f;
        Mp = 100f;
        isAlive = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        Death();
    }
}
