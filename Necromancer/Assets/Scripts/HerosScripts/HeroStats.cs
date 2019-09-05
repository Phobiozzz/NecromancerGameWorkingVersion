using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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

    public Transform bonescounter;
    public Transform skullscounter;

    private void Atack()
    {

    }

    public void Hit(float damage)
    {
        transform.GetComponent<CharacterMovement>().animator.SetTrigger("Hit");
        curHp -= damage;
        healthBar.value = curHp;
        //transform.GetComponent<CharacterMovement>().animator.SetTrigger("Idle");

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
            transform.GetComponent<CharacterMovement>().animator.SetTrigger("Dead");
            isAlive = false;
            Destroy(hero, 1f);
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

    public void SetupCounters(string WichCounterSetuping, bool Adding, float howMuch )
    {
        switch (WichCounterSetuping)
        {
            case "pages":
                if (Adding)
                {
                    pages += howMuch;
                }
                else if (Adding != true)
                {
                    pages -= howMuch;
                }

                break;
            case "skulls":
                if (Adding)
                {
                    skulls += howMuch;
                }
                else if (Adding != true)
                {
                    skulls -= howMuch;
                }

                break;
            case "bones":
                if (Adding)
                {
                    bones += howMuch;
                }
                else if (Adding != true)
                {
                    bones -= howMuch;
                }

                break;
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

    public void AdjustCounters()
    {
        skullscounter.GetComponentInChildren<TextMeshProUGUI>().text = skulls.ToString();
        bonescounter.GetComponentInChildren<TextMeshProUGUI>().text = bones.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Death();
        AdjustMana();
        RestoreMana(1);
        AdjustCounters();
        healthBar.value = curHp;
        manaBar.value = curMp;
    }
}
