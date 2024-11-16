using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : Entity
{
    private MovementRigidbody2D movement2D;
    [SerializeField]
    private KeyCode         jumpKey = KeyCode.Space;

    [Header("Infinite Tower Tilemap")]
    [SerializeField]
    private InfiniteTowerMovement towerScript1;
    
    [Header("Infinite Tower Map Copy")]
    [SerializeField]
    private InfiniteTowerMovement towerScript2;
    private bool facingRight = true;
    
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D         rigid2D;
    private bool isGrounded = MovementRigidbody2D.isGrounded; 
    private CapsuleCollider2D collider;
    private Vector2 footPosition;
    private Vector2 footArea;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private float wallWidth;
    [SerializeField]
    private float groundHeight;
    private void Awake()
    {
        movement2D = GetComponent<MovementRigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
        base.Setup();
        
    }
    private void Update()
    {
        Bounds bounds = collider.bounds;

        // Setting player foot position
        footPosition = new Vector2(bounds.center.x, bounds.min.y);

        // Setting player foot area info
        footArea = new Vector2((bounds.max.x - bounds.min.x) * 0.5f, 0.1f);

        // Create a box in the player's foot position with footArea size and check if that box collides with the ground
        isGrounded = Physics2D.OverlapBox(footPosition, footArea, 0, groundLayer);
        UpdateMove();
        UpdateJump();
        MoveDown();
        checkBounds();
        
        if (!isGrounded)
        {
            collider.isTrigger = true;
        }
    }
    
    
    // 기본 체력 + 스탯 보너스 + 버프 등과 같이 계산
    public override float MaxHP => MaxHPBasic + MaxHPAttrBonus;

    // 100 + 현재레벨 * 30
    public float MaxHPBasic => 100 + 1 * 30;

    // 힘 * 10
    public float MaxHPAttrBonus => 10 * 10;

    public override float HPRecovery => 10;
    public override float MaxMP => 200;
    public override float MPRecovery => 25;

    public override void TakeDamage(float damage)
    {
        HP -= damage;
        StartCoroutine("HitAnimation"); // maybe just turning in red highligted
    }
    
    
    private void MoveDown()
    {
        //If the player presses/holds down [S], they will be able to move through platforms
        if (Input.GetKey(KeyCode.S))
        {
            collider.isTrigger = true;
        }
    }
    private void UpdateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        
        if(x > 0 && !facingRight) Flip();
        else if(x < 0 && facingRight) Flip();
        
        movement2D.MoveTo(x); //x
    }

    private void checkBounds()
    { 
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x,
            Globals.WorldBounds.min.x + wallWidth,
            Globals.WorldBounds.extents.x - wallWidth),
            Mathf.Clamp(transform.position.y, groundHeight,1000 ), 0);
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //If player collides with a platform while moving downwards and their feet are above the platform, they will stop at the platform
        if ( collision.tag == "Platform" && rigid2D.velocity.y <= 0)
        {
            if (footPosition.y > collision.ClosestPoint(transform.position).y)
            {
                collider.isTrigger = false;

            }
        }

    }
    void Flip()
    {
        Vector3 scale = gameObject.transform.localScale;
        scale.x *= -1;
        gameObject.transform.localScale = scale;
        
        facingRight = !facingRight;
    }
    
    private IEnumerator HitAnimation()
    {
        Color color = spriteRenderer.color;

        color.a = 0.2f;
        spriteRenderer.color = color;
        
        yield return new WaitForSeconds(0.1f);

        color.a = 1;
        spriteRenderer.color = color;
    }

    

}
