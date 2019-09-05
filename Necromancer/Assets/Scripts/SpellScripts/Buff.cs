using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    public float power;
    public float Cd;
    public float counter;


    public bool isActive;

    public void Awake()
    {
        Cd = 5f;
       
       
    }
    public void Update()
    {
        if (Cd <= 0)
        {
            Cd = 0;
        }
        Cd -= 1 * Time.deltaTime;


        if (Cd > 0)
        {
            HeroStats stats = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroStats>();
            transform.SetParent(GameObject.FindGameObjectWithTag("BuffPos").GetComponent<Transform>());
            transform.localPosition = new Vector3(0.052f, -0.008f, 0f);
            stats.curHp -= power * Time.deltaTime;
            stats.curMp += (power / 2) * Time.deltaTime;
            Debug.Log("Buff is active");
        }
        else if(Cd <=0)
        {
            Destroy(gameObject);
        }
    }

}
