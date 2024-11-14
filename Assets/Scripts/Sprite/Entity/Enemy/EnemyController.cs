using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : Entity
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        base.Setup();
    }

    private void OnEnable()
    {
        target = GameManager.instance.player; 
        base.Setup();
    }

    private void Update()
    {
        
    }

    public override float MaxHP => 200;
    public override float HPRecovery => 15;
    public override float MaxMP => 0;
    public override float MPRecovery => 0;
    
    public override void TakeDamage(float damage)
    {
        HP -= damage;

        StartCoroutine("HitAnimation");
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
