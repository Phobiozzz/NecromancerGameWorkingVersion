using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameGUI : MonoBehaviour
{
    
    public GameObject spellBook;
    public GameObject heroGui;
   
    public void Update()
    {


        if (CrossPlatformInputManager.GetButtonDown("SpellBookButton"))
        {
            Time.timeScale = 0f;
            spellBook.SetActive(true);
            heroGui.transform.localScale = new Vector3(0, 0, 0);


        }
        else if(CrossPlatformInputManager.GetButtonDown("CloseBook"))
        {
            spellBook.SetActive(false);
            heroGui.transform.localScale = new Vector3(1, 1, 1);
            Time.timeScale = 1f;
        }

    }
}
