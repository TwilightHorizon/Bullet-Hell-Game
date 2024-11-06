using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementRigidbody2D : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Move Horizontal")]
    

    [SerializeField]
    private float               moveSpeed = 8; //movement speed
    private Rigidbody2D         rigid2D;

    private void Awake(){
        rigid2D = GetComponent<Rigidbody2D>();
    }

    public void MoveTo(float x)
    {
        rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
    }
}
