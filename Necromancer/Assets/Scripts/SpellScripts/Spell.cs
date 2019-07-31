using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    
    public static string spellName;
    public static string type;
    public static float lifeTime;
    public static float power;
    public static float cost;

    public bool isKnown;


    public void Effect()
    {

    }


    public Spell(string _name, string _type, float _lifeTime, float _power, float _cost)
    {
        spellName = _name;
        type = _type;
        lifeTime = _lifeTime;
        power = _power;
        cost = _cost;


    }

  
}
