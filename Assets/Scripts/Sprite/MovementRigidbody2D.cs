using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementRigidbody2D : MonoBehaviour
{
    [Header("Move Horizontal")]
    [SerializeField]
    private float               moveSpeed = 8;      // basic movement speed in horizontal direction

    [Header("Move Vertical (Jump)")]
    [SerializeField]
    private float               jumpForce = 10;     // the force of upward velocity when jumping

    [SerializeField] 
    private float               lowGravity = 2;     // gravity when you just press space (low jump)

    [SerializeField]
    private float               highGravity = 3;    // gravity when you do long press of space (high jump)
    
    [SerializeField]
    private int                 maxJumpCount = 2;   // default max jump count is 1 
    private int                 currentJumpCount;   // number of remaining jumps
    

    [Header("Collision")]
    [SerializeField]
    private LayerMask           groundLayer;        // layer for checking ground collision
    
    public static bool          isGrounded;         // checking if player is on the ground (if player is on ground --> true)
    private Vector2             footPosition;       // player foot position for checking collision with ground
    private Vector2             footArea;           // the area of collision checking for checking ground collision
    
    private Rigidbody2D         rigid2D;
    private new Collider2D      collider2D;         // 현재 오브젝트의 충돌 범위 정보 

    [SerializeField]
    private InfiniteTowerMovement towerScript1;
    [SerializeField]
    private InfiniteTowerMovement towerScript2;
    public bool IsLongJump { set; get; } = false;

    private void Awake(){
        rigid2D     = GetComponent<Rigidbody2D>();
        collider2D  = GetComponent<Collider2D>();

    }

    private void FixedUpdate()
    {   
        // Player Object's collider2D min, max, and center (location info) 
        Bounds bounds = collider2D.bounds; 
        
        // Setting player foot position
        footPosition = new Vector2(bounds.center.x, bounds.min.y);
        
        // Setting player foot area info
        footArea = new Vector2((bounds.max.x - bounds.min.x) * 0.5f, 0.1f);
        
        // Create a box in the player's foot position with footArea size and check if that box collides with the ground
        isGrounded = Physics2D.OverlapBox(footPosition, footArea,0, groundLayer);
        
        // if player foot has touched the ground and velocity.y < 0, then reset jumpCount
        // if player velocity.y > 0, then it means the player is in a process of jumping
        if (isGrounded && rigid2D.velocity.y <= 0)
        {
            
            currentJumpCount = maxJumpCount;
        }
        
        // change gravity based on highjump or lowjump
        // set gravity lower if it's a high jump, thus jumping higher
        // set gravity high if it's a low jump, thus jumping lower
        if (IsLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = lowGravity;
        }
        else
        {
            rigid2D.gravityScale = highGravity;
        }


    }
    public void MoveTo(float x)
    {
        //rigid2D.velocity = direction * moveSpeed;
        // for float x
        rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
    }

    public bool JumpTo()
    {
        
        
        if (currentJumpCount > 0)
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
            currentJumpCount--;
            return true;
        }

        return false; 
    }


}
