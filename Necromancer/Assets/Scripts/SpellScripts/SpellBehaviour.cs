using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehaviour : MonoBehaviour
{
    public string spellName;
    public float spellDamage;
    public float spellLifetime;

    public bool spellCreated;

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
            Destroy(gameObject, spellLifetime);
        }
    }
}
