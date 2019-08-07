using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        SceneManager.LoadScene("Winner_Scene");


    }

    
}
