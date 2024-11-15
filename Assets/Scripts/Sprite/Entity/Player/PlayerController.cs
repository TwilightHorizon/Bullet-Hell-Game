using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        movement2D = GetComponent<MovementRigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid2D = GetComponent<Rigidbody2D>();
        base.Setup();
        
    }
    private void Update()
    {
        UpdateMove();
        UpdateJump();
        MoveDown();
        
        // testing: 
        if (Input.GetKeyDown("1"))
        {
            target.TakeDamage(20);
        }

        // 스킬 공격
        else if (Input.GetKeyDown("2"))
        {
            MP -= 100;
            target.TakeDamage(55);
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
            towerScript1.turnOffPlatformCollision();
            towerScript2.turnOffPlatformCollision();
        }
    }
    private void UpdateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        
        if(x > 0 && !facingRight) Flip();
        else if(x < 0 && facingRight) Flip();
        
        movement2D.MoveTo(x); //x
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
