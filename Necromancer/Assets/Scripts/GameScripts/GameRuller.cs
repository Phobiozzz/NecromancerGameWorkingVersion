using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameRuller : MonoBehaviour
{
    public static float spriteSize = 0.32f;
    public GameObject hero;
    public GameObject deathmessage;
    public GameObject Gui;
    public GameObject spellBook;
    public static bool paused;

    public void StopTheGame()
    {
        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

    }

    public void ShowDeathMessage()
    {
        deathmessage.SetActive(true);
    }

    public void Start()
    {
        deathmessage.SetActive(false);
        Gui.SetActive(true);
        spellBook.SetActive(false);

    }

    public void Update()
    {
        if (hero.GetComponent<HeroStats>().curHp <= 0)
        {
            ShowDeathMessage();
            Gui.SetActive(false);
        }
        else
        {
            deathmessage.SetActive(false);
            Gui.SetActive(true);
        }

    }
}
