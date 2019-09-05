using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
public class SpellBookGUI : MonoBehaviour
{
    public GameObject player;

    public Button LearnButton;
    public GameObject spellBook;
    public TextMeshProUGUI skullscounter;
    public TextMeshProUGUI bonescounter;
    public TextMeshProUGUI pagescounter;


    public void Start()
    {
        LearnButton.interactable = false;
        skullscounter.text = "0";
        bonescounter.text = "0";
        pagescounter.text = "0";
    }

    public void AdjustCounters()
    {
        skullscounter.text = player.GetComponent<HeroStats>().skulls.ToString();
        bonescounter.text = player.GetComponent<HeroStats>().bones.ToString();
        pagescounter.text = player.GetComponent<HeroStats>().pages.ToString();
    }

    public void ChekingPages()
    {
        float pages = float.Parse(pagescounter.text);
        if (pages >= 5)
        {
            LearnButton.interactable = true;
        }
        else
        {
            LearnButton.interactable = false;
        }
    }

    public void LearnSkill()
    {
        ChekingPages();
        if (LearnButton.IsInteractable())
        {
            if (CrossPlatformInputManager.GetButtonDown("Learn"))
            {
                player.GetComponent<HeroStats>().pages -= 5;
				
               
                Debug.Log("You Just Learned Skill");
            }

        }
        else
        {
            Debug.Log("You dont have enougth pages to learn this skill");

        }
        
    }

    public void Update()
    {
        AdjustCounters();
        LearnSkill();

        
    }
}
