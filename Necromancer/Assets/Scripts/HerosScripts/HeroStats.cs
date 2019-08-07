using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroStats : MonoBehaviour
{
    public GameObject hero;
    
    public float curHp;
    public float maxHp;
    public float curMp;
    public float maxMp;
    public bool isAlive;
    public bool canCast;

    public Slider healthBar;
    public Slider manaBar;

    private void Atack()
    {

    }

    public void Hit(float damage)
    {
        curHp -= damage;
        healthBar.value = curHp;
       
    }

    public void Heal(float healPower)
    {
        curHp += healPower;
    }


    public void ManaSpend(float manaCost)
    {
        curMp -= manaCost;
        manaBar.value = curMp;
    }

    private void Death()
    {
        if (curHp <= 0)
        {
            isAlive = false;
            Destroy(hero);
        }
        
       
    }
    

   

    public float skulls;
    public float bones;
    public float pages;

    public void OnTriggerEnter2D (Collider2D other)
    {
       
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
                case "ManaPotion(Clone)":
                    curMp += 20f;
                    break;
            }

            Destroy(other.gameObject);
        }
        else if (other.tag == "DeathZone")
        {

           curHp = 0;
        }
        
    }


    public void RestoreMana(float bonus)
    {
        curMp += 1 * bonus * Time.deltaTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHp = 100f;
        curHp = maxHp;
        maxMp = 100f;
        curMp = maxMp;
        isAlive = true;
        healthBar.maxValue = maxHp;
        healthBar.minValue = 0;
        healthBar.value = curHp;

        manaBar.minValue = 0;
        manaBar.maxValue = maxMp;
        manaBar.value = curMp;

        canCast = true;
        DontDestroyOnLoad(gameObject);
       
    }

    public void AdjustMana()
    {

        if (curMp <= 0)
        {
            curMp = 0;
            canCast = false;
        }
        else {
            canCast = true;
        }



        if (curMp >= maxMp)
        {
            curMp = maxMp;
        }
        manaBar.value = curMp;
    }
    
    // Update is called once per frame
    void Update()
    {
        Death();
        AdjustMana();
        RestoreMana(1);
    }
}
