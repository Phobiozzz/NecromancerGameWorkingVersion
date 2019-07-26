using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject dropItem;
    public float dropSpeed;

    public void DropItem(GameObject drop)
    {

        bool isDead = transform.GetComponentInParent<MonsterStats>().isDead;
        if (isDead == true)
        {
            drop = Instantiate(dropItem, transform);
            drop.GetComponent<Rigidbody2D>().velocity = Vector2.up * dropSpeed;
        }
    }

    public void Update()
    {
        DropItem(dropItem);
    }

}
