using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CreateSpell : MonoBehaviour
{
    public Transform spellstart;
    public GameObject[] SpellBook;
    private GameObject spell;
    public float spellSpeed;
    private Vector3 spellStartPosition;
    public GameObject player;
    public bool canCast;
    public bool isCasting;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spellstart = transform.GetComponent <Transform>();
        canCast = true;
       
        //Debug.Log(spellstart.name);
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
        spellStartPosition = spellstart.position;
        canCast = player.GetComponent<HeroStats>().canCast;
        if (canCast == true)
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire1") && canCast)
            {
                isCasting = true;
                animator.SetTrigger("Casting");
                
                if (SpellBook[0].GetComponent<PoisonArrow>().manaCost <= player.GetComponent<HeroStats>().curMp)
                {
                    spell = Instantiate(SpellBook[0], spellStartPosition, Quaternion.identity);
                   
                }
                else
                {
                    Debug.Log("Manacost of arrow" + SpellBook[0].GetComponent<PoisonArrow>().manaCost);
                    Debug.Log("Current Heros Mana " + player.GetComponent<HeroStats>().curMp);
                    Debug.Log("Not enougth mana to create spell");
                }
               

            }
            else if (CrossPlatformInputManager.GetButtonDown("Fire2") && canCast)
            {
                spell = Instantiate(SpellBook[1], spellStartPosition, Quaternion.identity);
            }
            animator.SetTrigger("NotCasting");

        }

      
        
       
    }
}
