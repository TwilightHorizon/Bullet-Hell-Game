using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MovementRigidbody2D movement2D;
    [SerializeField]
    private KeyCode         jumpKey = KeyCode.Space;

    public InfiniteTowerMovement towerScript1;
    public InfiniteTowerMovement towerScript2;
    private bool facingRight = true;
    

    private void Awake()
    {
        movement2D = GetComponent<MovementRigidbody2D>();
        towerScript1 = GameObject.Find("Infinite Tower Tilemap").GetComponent<InfiniteTowerMovement>();
        towerScript2 = GameObject.Find("Infinite Tower Tilemap Copy").GetComponent<InfiniteTowerMovement>();
    }
    private void Update()
    {
        UpdateMove();
        UpdateJump();
        MoveDown();
    }
    private void MoveDown()
    {
        //If the player presses/holds down [S], they will be able to move through platforms
        if (Input.GetKey(KeyCode.S))
        {
            towerScript1.turnOffPlatformCollision();
            towerScript2.turnOffPlatformCollision();
        }
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
