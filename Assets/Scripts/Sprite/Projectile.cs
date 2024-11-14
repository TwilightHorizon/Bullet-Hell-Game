using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    private ProjectileData projectileData; // data for projectile
    public Entity targetEntity;

    public float damage
    {
        set => projectileData.damage = value;
        get => projectileData.damage;
    }

    public float speed
    {
        set => projectileData.speed = value;
        get => projectileData.speed;
    }
    
    
}

[System.Serializable]
public struct ProjectileData
{
    [HideInInspector] public float damage;
    [HideInInspector] public float speed; 
}
