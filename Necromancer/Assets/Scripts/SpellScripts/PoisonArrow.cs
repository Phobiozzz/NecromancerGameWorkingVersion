using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonArrow : MonoBehaviour
{
    public float damage = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {

            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Ground")
        {

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 0.5f);
        }
    }

}
