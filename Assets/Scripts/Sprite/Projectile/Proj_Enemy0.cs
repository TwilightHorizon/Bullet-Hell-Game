using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proj_Enemy0 : MonoBehaviour
{

    private GameObject  target;
    private float       timeElapsed;
    private int         bulletType;
    
    
    [Header("Projectiles Data")] 
    [SerializeField] private float[] damage;

    [SerializeField] private float[] speed;

    [SerializeField] private float[] fireRate;

    [SerializeField] private float[] fireDuration;
    

    private void OnEnable()
    {
        target = GameManager.instance.player.gameObject;
        timeElapsed = 0f;
    }

    private IEnumerator Fire()
    {
        
        yield return new WaitForSeconds(1f);
        
        
    }

    private void OnDisable()
    {
        
    }
}
