using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MovementRigidbody2D movement2D;
    [SerializeField]
    private KeyCode         jumpKey = KeyCode.Space;

<<<<<<< Updated upstream
    public InfiniteTowerMovement towerScript1;
    public InfiniteTowerMovement towerScript2;
    private void Awake()
    {
        movement2D = GetComponent<MovementRigidbody2D>();
        towerScript1 = GameObject.Find("Infinite Tower Tilemap").GetComponent<InfiniteTowerMovement>();
        towerScript2 = GameObject.Find("Infinite Tower Tilemap Copy").GetComponent<InfiniteTowerMovement>();

=======
    [Header("Infinite Tower Tilemap")]
    [SerializeField]
    private InfiniteTowerMovement towerScript1;
    
    [Header("Infinite Tower Map Copy")]
    [SerializeField]
    private InfiniteTowerMovement towerScript2;
    private bool facingRight = true;
    
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigid2D;
    private void Awake()
    {
        movement2D = GetComponent<MovementRigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid2D = GetComponent<Rigidbody2D>();
        base.Setup();
        
>>>>>>> Stashed changes
    }
    private void Update()
    {
        UpdateMove();
        UpdateJump();
    }
    
<<<<<<< Updated upstream
    private void UpdateMove()
=======
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
>>>>>>> Stashed changes
    {
        float x = Input.GetAxisRaw("Horizontal");
        movement2D.MoveTo(x);
        MoveDown();
    }

    private void MoveDown()
    {
        //If the player presses/holds down [S], they will be able to move through platforms

        if (Input.GetKey(KeyCode.S) && MovementRigidbody2D.isGrounded)
        {
            print("Test");
            towerScript1.turnOffPlatformCollision();
            towerScript2.turnOffPlatformCollision();
        }
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


}
