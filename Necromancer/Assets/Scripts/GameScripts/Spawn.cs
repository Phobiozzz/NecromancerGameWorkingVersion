using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] objectsToSpawn;

    public bool canSpawnhere;
    public Vector3 spawnPointPosition;
    public void Awake()
    {
        canSpawnhere = true;
        
    }

    public void SpawnObject()
    {
        if (canSpawnhere)
        {
            Instantiate(objectsToSpawn[0], transform.localPosition, Quaternion.identity);
        }
        
        canSpawnhere = false;
    }

    public void Update()
    {
        
    }
}
