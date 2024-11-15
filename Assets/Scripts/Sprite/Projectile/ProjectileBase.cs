using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    protected MovementProjectile2D movementProjectile2D;

    public virtual void Setup(Transform target, float damage, int maxCount = 1, int index = 0)
    {
        movementProjectile2D = GetComponent<MovementProjectile2D>();
    }

    private void Update()
    {
        Process();
    }

    public abstract void Process();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity); 
            gameObject.SetActive(false);
        }
    }
}
