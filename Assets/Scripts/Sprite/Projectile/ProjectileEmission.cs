using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType {Straight, Homing, QuadraticHoming, CubicHoming}


public class ProjectileEmission : MonoBehaviour
{
    [SerializeField] private ProjectileType projectileType = ProjectileType.Straight; 
    
    [SerializeField] private float cooldownTime = 2f;
    
    [SerializeField] private GameObject[] projectilePrefabs;

    [SerializeField] private Transform projectileSpawnPoint;

    [SerializeField] Transform target;

    private float currentCooldownTime = 0f;
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
        if (!isFireAvailable) return;
        // target = GameManager.instance.player.transform;

        GameObject clone = GameObject.Instantiate(projectilePrefabs[(int)projectileType], projectileSpawnPoint.position, Quaternion.identity);
        clone.GetComponent<ProjectileBase>().Setup(target, 1);

        currentCooldownTime = Time.time;

    }
}
