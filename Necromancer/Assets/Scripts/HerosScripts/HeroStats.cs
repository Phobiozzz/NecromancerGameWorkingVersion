﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    public GameObject hero;
    public float Hp;
    private float Mp;

    private void Atack()
    {

    }

    public void Hit(float damage)
    {
        Hp -= damage;
    }

    private void Death()
    {


    }


    public float skulls;

    public void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Drop")
        {
            skulls++;
            Destroy(other.gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
       
        Hp = 100f;
        Mp = 100f;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
