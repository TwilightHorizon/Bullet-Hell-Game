using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementProjectile2D : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 10f;
    private Rigidbody2D rb;
    
    public float MoveSpeed => moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveTo(Vector3 dir)
    {
        rb.velocity = dir * moveSpeed;
    }
}
