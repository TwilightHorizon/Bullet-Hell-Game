using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType {Straight, Homing, QuadraticHoming, CubicHoming, Circular} 
// add the different types of projectile type as you add more 


public class ProjectileEmission : MonoBehaviour
{
    [SerializeField] private ProjectileType projectileType = ProjectileType.Straight; //decides the type of the projectile among ProjectileType
    [SerializeField] private float damage = 50f;
    [SerializeField] private int projectileCount = 1; // number of projectiles that it shoots (default = 1)
    [SerializeField] private float attackRate = 0.1f; // (default = 0.1) 
    
    [SerializeField] private float cooldownTime = 2f; // cooldown time for each fire (default = 2)
    
    [SerializeField] private GameObject[] projectilePrefabs; // stores all the projectile prefabs for different types of projectile

    [SerializeField] private Transform projectileSpawnPoint; // the position where the projectile is spawned

    [SerializeField] Transform target; // the position of the target (not defaulted because it can be set as updated or just set when var is defined)

    
    
    private float currentCooldownTime = 0f;
    private int currentProjectileIndex = 0;
    private float currentAttackRate = 0;
    
    
    public bool isFireAvailable => (Time.time - currentCooldownTime) > cooldownTime; 

    private void Awake()
    {
    }

    private void Update()
    {
        OnFire();
    }

    public void OnFire()
    {
        if (isFireAvailable == false) return;
        // target = GameManager.instance.player.transform;

        /*GameObject clone = GameObject.Instantiate(projectilePrefabs[(int)projectileType], projectileSpawnPoint.position, Quaternion.identity);
        clone.GetComponent<ProjectileBase>().Setup(target, 50);
        
        currentCooldownTime = Time.time;*/

        if (Time.time - currentAttackRate > attackRate)
        {
            GameObject clone = GameObject.Instantiate(projectilePrefabs[(int)projectileType], projectileSpawnPoint.position, Quaternion.identity);
            clone.GetComponent<ProjectileBase>().Setup(target, damage, projectileCount, currentProjectileIndex);
            currentProjectileIndex++;

            currentAttackRate = Time.time;
        }

        if (currentProjectileIndex >= projectileCount)
        {
            currentProjectileIndex = 0;
            currentCooldownTime = Time.time;
        }
        

    }
}
