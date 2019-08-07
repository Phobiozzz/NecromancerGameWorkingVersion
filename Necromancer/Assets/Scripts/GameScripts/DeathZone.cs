using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<HeroStats>().curHp = 0;
        }
        if (collision.transform.tag == "Monster")
        {
            collision.transform.GetComponent<MonsterStats>().monsterHp = 0;
        }
    }
}
