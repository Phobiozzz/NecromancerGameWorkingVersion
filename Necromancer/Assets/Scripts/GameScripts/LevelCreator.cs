using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelCreator : MonoBehaviour
{
    public GameObject firstTile;
    public GameObject mainTile;
    public GameObject lastTile;
    public GameObject stairs;
    public GameObject monster;
    public Vector3 StartPosition;

    public Vector3 lastPlatformPosition;
    private readonly System.Random random = new System.Random();


    public GameObject spawnPoint;

    public float floor = GameRuller.spriteSize;

    
    

    public void CreateLevel(int platformsCount)
    {
        
        for (int x = 0; x < platformsCount; x++)
        {

            lastPlatformPosition = new Vector3(lastPlatformPosition.x, random.Next(-5, 3) * (floor / 2));

            if (lastPlatformPosition.y < (floor * 1.5f))
            {
                CreatePlatform(random.Next(2, 7), lastPlatformPosition);
            }
           

            Debug.Log(lastPlatformPosition.y);
        }
        

    }

    public void CreatePlatform(int platformLength, Vector3 startPosition)
    {
        GameObject platform;
        Vector3 currentPosition = startPosition;
        
        for (int x = 0; x < platformLength; x++)
        {
            if (x == 0)
            {
                platform = Instantiate(firstTile, transform);
                platform.transform.position = currentPosition;
                
            }
            else if (x < platformLength - 1)
            {
                platform = Instantiate(mainTile, transform);
                platform.transform.position = currentPosition;
            }
            else if (x == platformLength - 1)
            {
                platform = Instantiate(lastTile, transform);
                platform.transform.position = currentPosition;
            }
            currentPosition.x += GameRuller.spriteSize;
            

        }
        lastPlatformPosition = currentPosition;
       
    }


    

    public void Start()
    {
        StartPosition = gameObject.transform.position;
        CreatePlatform(3, new Vector3(0 * GameRuller.spriteSize,-2.5f * floor));

        CreateLevel(100);
    }
}
