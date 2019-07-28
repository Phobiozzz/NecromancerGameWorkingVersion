using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonArrow : MonoBehaviour
{
    public float damage = 3;
    public float speed = 2.5f;

    public void Awake()
    {
       GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player.transform.GetComponent<CharacterMovement>().lookingRight == true)
        {
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
        else if (player.transform.GetComponent<CharacterMovement>().lookingRight == false)
        {
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
            transform.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {

            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("You Hited the ground");
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 0.5f);
        }
    }

}
