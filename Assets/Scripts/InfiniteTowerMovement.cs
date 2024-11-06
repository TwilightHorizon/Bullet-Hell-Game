using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteTowerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Vector2 initialPosition;
    [SerializeField]
    private float speed;
    void Start()
    {
        transform.position = initialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if(transform.position.y < -36f){
            transform.position = new Vector3(0,34f,0); 
        }
    }
}
