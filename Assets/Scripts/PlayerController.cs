using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MovementRigidbody2D movement2D;
    [SerializeField]
    private KeyCode         jumpKey = KeyCode.Space;

    private bool facingRight = true;
    

    private void Awake()
    {
        movement2D = GetComponent<MovementRigidbody2D>();

    }
    private void Update()
    {
        UpdateMove();
        UpdateJump();
    }
    
    private void UpdateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        
        if(x > 0 && !facingRight) Flip();
        else if(x < 0 && facingRight) Flip();
        
        movement2D.MoveTo(x);
    }

    private void UpdateJump()
    {
        if(Input.GetKeyDown(jumpKey))
        {
            movement2D.JumpTo();
        }
        else if (Input.GetKey(jumpKey))
        {
            movement2D.IsLongJump = true;
        }
        else if (Input.GetKeyUp(jumpKey))
        {
            movement2D.IsLongJump = false; 
        }
    }

    void Flip()
    {
        Vector3 scale = gameObject.transform.localScale;
        scale.x *= -1;
        gameObject.transform.localScale = scale;
        
        facingRight = !facingRight;
    }

}
