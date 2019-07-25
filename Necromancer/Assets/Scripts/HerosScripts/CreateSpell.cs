using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSpell : MonoBehaviour
{
    public Transform spellstart;
    public GameObject[] SpellBook;
    private GameObject spell;
    public float spellSpeed;
    private Vector3 spellStartPosition;
    public GameObject player;

  
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spellstart = transform.GetComponent <Transform>();
       
        //Debug.Log(spellstart.name);
        
    }

    

    // Update is called once per frame
    void Update()
    {
        spellStartPosition = spellstart.position;
        
        if (Input.GetButtonDown("Fire1"))
        {
           spell = Instantiate(SpellBook[0], spellStartPosition, Quaternion.identity);
          
            
           
            if (player.GetComponent<CharacterMovement>().lookingRight == true)
            {
                spell.GetComponent<Rigidbody2D>().velocity = Vector2.right * spellSpeed;
            }
            else
            {
                spell.GetComponent<Rigidbody2D>().velocity = Vector2.left * spellSpeed;
                spell.transform.GetComponent<SpriteRenderer>().flipX = true;
            }
            
        }
        
       
    }
}
