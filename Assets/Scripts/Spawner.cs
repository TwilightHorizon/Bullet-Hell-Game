using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    [SerializeField] private Transform[] spawnPoints;
    private float timer; 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameManager.instance.pool.Get(0);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameManager.instance.pool.Get(1);
        }
    }
}
