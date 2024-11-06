using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MovementRigidbody2D movement2D;

    private void Awake()
    {
        movement2D = GetComponent<MovementRigidbody2D>();

    }
    private void Update()
    {
        UpdateMove();
    }
    
    private void UpdateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        movement2D.MoveTo(x);
    }
}
